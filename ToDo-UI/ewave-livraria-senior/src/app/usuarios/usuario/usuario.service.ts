import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '@env/environment';
import { Usuario } from './usuario'

const API_URL = environment.todo_api;

@Injectable({ providedIn: 'root' })
export class UsuarioService {

    constructor(private http: HttpClient) { }

    inserirUsuario(usuario: Usuario) {
        return this.http
            .post(
                API_URL + '/api/usuario',
                usuario,
                { observe: 'response' },
            );
    }

    alterarUsuario(usuario: Usuario) {
        return this.http
            .put(
                API_URL + '/api/usuario',
                usuario,
                { observe: 'response' },
            );
    }

    buscarUsuarioPorNome(nome) {
        return this.http
            .get(
                API_URL + '/api/usuario/' + nome
            );
    }

    retornarTodasUsuario() {
        return this.http
            .get(
                API_URL + '/api/usuario'
            );
    }

    removerUsuario(id) {
        return this.http
            .delete(
                API_URL + '/api/usuario/' + id
            );
    }
}


