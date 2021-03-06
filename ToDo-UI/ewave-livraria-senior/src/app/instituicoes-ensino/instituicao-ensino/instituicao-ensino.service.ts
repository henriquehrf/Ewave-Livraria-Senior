import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '@env/environment';
import { InstituicaoEnsino } from './instituicao-ensino'

const API_URL = environment.todo_api;
const TAMANHO_PAGINA_PADRAO = environment.tamanho_pagina_padrao

@Injectable({ providedIn: 'root' })
export class InstituicaoEnsinoService {

    constructor(private http: HttpClient) { }

    inserirInstituicaoEnsino(instituicao: InstituicaoEnsino) {
        return this.http
            .post(
                API_URL + '/api/instituicoes-ensino/inserir',
                instituicao,
                { observe: 'response' },
            );
    }

    alterarInstituicaoEnsino(instituicao: InstituicaoEnsino) {
        return this.http
            .put(
                API_URL + '/api/instituicoes-ensino/alterar',
                instituicao,
                { observe: 'response' },
            );
    }

    buscarInstituicaoEnsinoPorNome(nome: string, pagina:number) {
        return this.http
            .get(
                API_URL + '/api/instituicoes-ensino/buscar-por-nome?nome=' + nome + '&pagina=' + pagina + '&tamanhoPagina='+TAMANHO_PAGINA_PADRAO
            );
    }

    retornarInstituicaoEnsinoDropdown() {
        return this.http
            .get(
                API_URL + '/api/instituicoes-ensino/dropdown'
            );
    }
}


