export interface Usuario {
    id: number,
    nome: string,
    cpf: string,
    endereco:string,
    instituicaoEnsinoId: number,
    instituicaoEnsinoDescricao: string,
    telefone: string,
    email: string,
    perfilUsuario: number,
    login: string,
    senha: string,
    dataSuspencao: Date
}