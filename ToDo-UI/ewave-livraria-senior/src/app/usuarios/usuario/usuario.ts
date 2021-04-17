export interface Usuario {
    id: number,
    nome: string,
    cpf: string,
    endereco:string,
    idInstituicaoEnsino: number,
    instituicaoEnsinoDescricao: string,
    telefone: string,
    email: string,
    perfilUsuario: number,
    login: string,
    senha: string,
    dataSuspencao: Date,
    ativo:boolean
}