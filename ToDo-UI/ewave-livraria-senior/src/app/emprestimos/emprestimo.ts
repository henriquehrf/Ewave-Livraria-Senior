import { Usuario } from "app/usuarios/usuario/usuario";
import { Livro } from "app/livros/livro/livro";

export interface Emprestimo {
    id: number,
    idUsuario: number,
    idLivro: number,
    dataPrevistaDevolucao: Date,
    dataEmprestimo: Date,
    status: number,
    usuario: Usuario,
    livro: Livro
}