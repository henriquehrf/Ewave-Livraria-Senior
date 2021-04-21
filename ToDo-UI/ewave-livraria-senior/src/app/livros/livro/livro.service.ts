import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '@env/environment';
import { Livro } from './livro';
import { Emprestimo } from '../../emprestimos/emprestimo';

const API_URL = environment.todo_api;
const TAMANHO_PAGINA_PADRAO = environment.tamanho_pagina_reduzida

@Injectable({ providedIn: 'root' })
export class LivroService {

    constructor(private http: HttpClient) { }

    inserirLivro(livro: Livro) {
        return this.http
            .post(
                API_URL + '/api/livros/inserir',
                livro,
                { observe: 'response' },
            );
    }

    alterarLivro(livro: Livro) {
        return this.http
            .put(
                API_URL + '/api/livros/alterar',
                livro,
                { observe: 'response' },
            );
    }

    buscarLivroPoTitulo(titulo: string, pagina: number) {
        return this.http
            .get(
                API_URL + '/api/livros/buscar-por-titulo?titulo=' + titulo + '&TamanhoPagina='+ TAMANHO_PAGINA_PADRAO +'&Pagina=' + pagina
            );
    }

    uploadCapa(file) {
        const formData = new FormData();
        formData.append('file', file);

        return this.http.post(API_URL + '/api/imagens/salvar', formData);

    }

    removerCapa(guid) {
        return this.http.delete(API_URL + '/api/imagens/remover?guid=' + guid);
    }
}


