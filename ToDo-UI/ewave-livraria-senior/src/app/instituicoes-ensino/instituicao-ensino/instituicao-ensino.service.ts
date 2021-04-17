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
                API_URL + '/api/instituicao-ensino',
                instituicao,
                { observe: 'response' },
            );
    }

    alterarInstituicaoEnsino(instituicao: InstituicaoEnsino) {
        return this.http
            .put(
                API_URL + '/api/instituicao-ensino',
                instituicao,
                { observe: 'response' },
            );
    }

    buscarInstituicaoEnsinoPorNome(nome) {
        return this.http
            .get(
                API_URL + '/api/instituicao-ensino/' + nome
            );
    }

    retornarInstituicaoEnsinoDropdown() {
        return this.http
            .get(
                API_URL + '/api/instituicaoensino/instituicao-ensino-dropdown'
            );
    }

    removerInstituicaoEnsino(id) {
        return this.http
            .delete(
                API_URL + '/api/instituicao-ensino/' + id
            );
    }
}


