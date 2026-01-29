import { useEffect, useState } from "react";
import { api } from "./api/locadoraApi";
import type { Veiculo, Locacao, OrdemServico } from "./api/locadoraApi";

const CLIENTE_ID = "b0a0b37a-fb8c-11f0-8da9-d412dc1cf57a";

function hojeISO() {
  return new Date().toISOString().slice(0, 10);
}

function addDiasISO(dias: number) {
  const d = new Date();
  d.setDate(d.getDate() + dias);
  return d.toISOString().slice(0, 10);
}

export default function App() {
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const [veiculos, setVeiculos] = useState<Veiculo[]>([]);
  const [locacoesAtivas, setLocacoesAtivas] = useState<Locacao[]>([]);
  const [os, setOs] = useState<OrdemServico[]>([]);

  async function refreshAll() {
    try {
      setLoading(true);
      setError(null);

      const [v, l, o] = await Promise.all([
        api.listarVeiculos(),
        api.listarLocacoes({ status: "Ativa", page: 1, pageSize: 20 }),
        api.listarOS(),
      ]);

      setVeiculos(v);
      setLocacoesAtivas(l.items);
      setOs(o);
    } catch (e) {
      setError(e instanceof Error ? e.message : "Erro desconhecido");
    } finally {
      setLoading(false);
    }
  }

  useEffect(() => {
    refreshAll();
  }, []);

  async function alugar(veiculoId: string) {
    await api.abrirLocacao({
      clienteId: CLIENTE_ID,
      veiculoId,
      retirada: hojeISO(),
      prevista: addDiasISO(1),
    });
    await refreshAll();
  }

  async function devolver(locacaoId: string) {
    await api.devolverLocacao(locacaoId, { devolucao: hojeISO() });
    await refreshAll();
  }

  async function concluir(id: string) {
    await api.concluirOS(id);
    await refreshAll();
  }

  return (
    <div style={{ padding: 20, maxWidth: 1100, margin: "0 auto" }}>
      <header style={{ display: "flex", alignItems: "center", gap: 12 }}>
        <h1 style={{ margin: 0 }}>Locadora</h1>
        <span style={{ opacity: 0.7 }}>Painel</span>

        <div style={{ marginLeft: "auto" }}>
          <button onClick={refreshAll} disabled={loading}>
            {loading ? "Atualizando..." : "Atualizar"}
          </button>
        </div>
      </header>

      <hr />

      {error && (
        <div style={{ padding: 12, border: "1px solid #ddd", marginBottom: 16 }}>
          <strong>Erro</strong>
          <div style={{ whiteSpace: "pre-wrap" }}>{error}</div>
        </div>
      )}

      <div style={{ display: "grid", gridTemplateColumns: "1fr 1fr", gap: 16 }}>
        <section style={{ border: "1px solid #ddd", padding: 12 }}>
          <h2 style={{ marginTop: 0 }}>Veículos disponíveis</h2>

          {veiculos.length === 0 ? (
            <p>Nenhum disponível.</p>
          ) : (
            <ul style={{ paddingLeft: 18 }}>
              {veiculos.map(v => (
                <li key={v.id} style={{ marginBottom: 8 }}>
                  <strong>{v.modelo}</strong> ({v.placa}) — R$ {v.valorDiaria}
                  <button style={{ marginLeft: 10 }} onClick={() => alugar(v.id)}>
                    Alugar
                  </button>
                </li>
              ))}
            </ul>
          )}
        </section>

        <section style={{ border: "1px solid #ddd", padding: 12 }}>
          <h2 style={{ marginTop: 0 }}>Locações ativas</h2>

          {locacoesAtivas.length === 0 ? (
            <p>Nenhuma ativa.</p>
          ) : (
            <ul style={{ paddingLeft: 18 }}>
              {locacoesAtivas.map(l => (
                <li key={l.id} style={{ marginBottom: 8 }}>
                  <code>{l.id.slice(0, 8)}…</code> — veículo{" "}
                  <code>{l.veiculoId.slice(0, 8)}…</code>
                  <button style={{ marginLeft: 10 }} onClick={() => devolver(l.id)}>
                    Devolver
                  </button>
                </li>
              ))}
            </ul>
          )}
        </section>

        <section style={{ border: "1px solid #ddd", padding: 12, gridColumn: "1 / span 2" }}>
          <h2 style={{ marginTop: 0 }}>Ordens de Serviço</h2>

          {os.length === 0 ? (
            <p>Nenhuma OS.</p>
          ) : (
            <ul style={{ paddingLeft: 18 }}>
              {os.map(o => (
                <li key={o.id} style={{ marginBottom: 8 }}>
                  <strong>{o.tipo}</strong> — {o.status} — veículo{" "}
                  <code>{o.veiculoId.slice(0, 8)}…</code>
                  {o.status === "Aberta" && (
                    <button style={{ marginLeft: 10 }} onClick={() => concluir(o.id)}>
                      Concluir
                    </button>
                  )}
                </li>
              ))}
            </ul>
          )}
        </section>
      </div>
    </div>
  );
}
