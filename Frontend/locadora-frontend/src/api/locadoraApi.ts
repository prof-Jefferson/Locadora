const API_URL = "http://localhost:5176";

export type Veiculo = {
  id: string;
  placa: string;
  modelo: string;
  ano: number;
  categoria: string;
  valorDiaria: number;
  ativo: boolean;
  disponivel: boolean;
};

export type Locacao = {
  id: string;
  clienteId: string;
  veiculoId: string;
  status: string; // ex: "Ativa", "Encerrada"
  retirada: string;
  prevista: string;
  devolucao?: string | null;
  criadoEmUtc: string;
};

export type Paged<T> = {
  page: number;
  pageSize: number;
  total: number;
  items: T[];
};

export type OrdemServico = {
  id: string;
  veiculoId: string;
  tipo: string;
  status: string;
  criadoEmUtc: string;
  concluidoEmUtc?: string | null;
};

async function http<T>(path: string, init?: RequestInit): Promise<T> {
  const res = await fetch(`${API_URL}${path}`, init);
  if (!res.ok) {
    const txt = await res.text().catch(() => "");
    throw new Error(`${res.status} ${res.statusText} ${txt}`.trim());
  }
  return (await res.json()) as T;
}

export const api = {
  listarVeiculos: () => http<Veiculo[]>("/veiculos"),

  listarLocacoes: (params: { page?: number; pageSize?: number; status?: string }) => {
    const qs = new URLSearchParams();
    qs.set("page", String(params.page ?? 1));
    qs.set("pageSize", String(params.pageSize ?? 20));
    if (params.status) qs.set("status", params.status);
    return http<Paged<Locacao>>(`/locacoes?${qs.toString()}`);
  },

  abrirLocacao: (payload: {
    clienteId: string;
    veiculoId: string;
    retirada: string;
    prevista: string;
  }) =>
    http<any>("/locacoes", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(payload),
    }),

  devolverLocacao: (locacaoId: string, payload?: { devolucao?: string }) =>
    http<any>(`/locacoes/${locacaoId}/devolver`, {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(payload ?? {}),
    }),

  listarOS: () => http<OrdemServico[]>("/os"),

  concluirOS: (id: string) => http<void>(`/os/${id}/concluir`, { method: "POST" }),
};
