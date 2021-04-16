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
                API_URL + '/api/livro',
                livro,
                { observe: 'response' },
            );
    }

    emprestarLivro(emprestimo) {
        return this.http
            .post(
                API_URL + '/api/emprestimo',
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
                API_URL + '/api/livro',
                livro,
                { observe: 'response' },
            );
    }

    buscarLivroPoTitulo(titulo) {
        return this.http
            .get(
                API_URL + '/api/livro/' + titulo
            );
    }

    retornarTodosLivro() {
        return this.http
            .get(
                API_URL + '/api/livro'
            );
    }

    removerLivro(id) {
        return this.http
            .delete(
                API_URL + '/api/livro/' + id
            );
    }

    uploadCapa(file) {
        const formData = new FormData();
        formData.append('file', file);

        return this.http.post(API_URL + '/api/imagem', formData);

    }

    removerCapa(guid) {
        return this.http.delete(API_URL + '/api/imagem' + guid);
    }
}


