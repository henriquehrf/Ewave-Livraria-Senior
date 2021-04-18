import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '@env/environment';
import { InstituicaoEnsino } from './instituicao-ensino'

const API_URL = environment.todo_api;

@Injectable({ providedIn: 'root' })
export class InstituicaoEnsinoService {

    constructor(private http: HttpClient) { }

    inserirInstituicaoEnsino(instituicao: InstituicaoEnsino) {
        return this.http
            .post(
                API_URL + '/api/instituicaoensino/inserir',
                instituicao,
                { observe: 'response' },
            );
    }

    alterarInstituicaoEnsino(instituicao: InstituicaoEnsino) {
        return this.http
            .put(
                API_URL + '/api/instituicaoensino/alterar',
                instituicao,
                { observe: 'response' },
            );
    }

    buscarInstituicaoEnsinoPorNome(nome: string, pagina:number) {
        return this.http
            .get(
                API_URL + '/api/instituicaoensino/buscar-por-nome?nome=' + nome + '&pagina=' + pagina + '&tamanhoPagina=12'
            );
    }

    retornarInstituicaoEnsinoDropdown() {
        return this.http
            .get(
                API_URL + '/api/instituicaoensino/instituicao-ensino-dropdown'
            );
    }
}


