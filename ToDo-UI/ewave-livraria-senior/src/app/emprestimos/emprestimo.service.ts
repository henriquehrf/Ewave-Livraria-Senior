import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '@env/environment';
import { Emprestimo } from '../emprestimos/emprestimo';

const API_URL = environment.todo_api;

@Injectable({ providedIn: 'root' })
export class EmprestimoService {

    constructor(private http: HttpClient) { }


    uploadCapa(file) {
        const formData = new FormData();
        formData.append('file', file);

        return this.http.post(API_URL + '/api/imagem', formData);

    }

    emprestarLivro(emprestimo) {
        return this.http
            .post(
                API_URL + '/api/emprestimos/inserir',
                emprestimo,
                { observe: 'response' },
            );
    }

    devolverLivro(emprestimo: Emprestimo) {
        return this.http
            .put(
                API_URL + '/api/emprestimos/devolver',
                emprestimo,
                { observe: 'response' },
            );
    }

    retornarEmprestimosAtivoPorIdUsuario(id) {
        return this.http
            .get(
                API_URL + '/api/emprestimos/buscar-por-usuario?idUsuario=' + id,
            );
    }

    retornarTodosEmprestimoAtivo() {
        return this.http
            .get(
                API_URL + '/api/emprestimos/todos-ativos',
            );
    }

   
}


