import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '@env/environment';
import { Livro } from './livro';
import { Emprestimo } from '../../emprestimos/emprestimo';

const API_URL = environment.todo_api;

@Injectable({ providedIn: 'root' })
export class LivroService {

    constructor(private http: HttpClient) { }

    inserirLivro(livro: Livro) {
        return this.http
            .post(
                API_URL + '/api/livro/inserir',
                livro,
                { observe: 'response' },
            );
    }

    emprestarLivro(emprestimo) {
        return this.http
            .post(
                API_URL + '/api/emprestimo/inserir',
                emprestimo,
                { observe: 'response' },
            );
    }

    devolverLivro(emprestimo: Emprestimo) {
        return this.http
            .put(
                API_URL + '/api/emprestimo',
                emprestimo,
                { observe: 'response' },
            );
    }

    alterarLivro(livro: Livro) {
        return this.http
            .put(
                API_URL + '/api/livro/alterar',
                livro,
                { observe: 'response' },
            );
    }

    buscarLivroPoTitulo(titulo: string, pagina: number) {
        return this.http
            .get(
                API_URL + '/api/livro/buscar-por-titulo?titulo=' + titulo + '&TamanhoPagina=6&Pagina=' + pagina
            );
    }

    uploadCapa(file) {
        const formData = new FormData();
        formData.append('file', file);

        return this.http.post(API_URL + '/api/imagem/salvar', formData);

    }

    removerCapa(guid) {
        return this.http.delete(API_URL + '/api/imagem/remover?guid=' + guid);
    }
}


