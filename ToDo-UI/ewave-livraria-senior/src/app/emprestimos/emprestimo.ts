export interface Emprestimo {
    id: number,
    idUsuario: number,
    idLivro: number,
    dataPrevistaDevolucao: Date,
    dataEmprestimo: Date,
    livroTitulo:string,
    livroAutor:string,
    livroGenero:string,
    livroSinopse:string
}