export interface Livro {
    id: number,
    titulo: string,
    genero: string,
    autor: string,
    sinopse: string,
    disponibilidade: boolean,
    guidCapa: string,
    reservado: boolean,
    ativo: boolean,
    arquivoCapa: string | ArrayBuffer | null
}