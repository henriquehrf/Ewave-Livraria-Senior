import { Component, OnInit, Input } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { UsuarioService } from '../usuario/usuario.service';
import { debounceTime } from 'rxjs/operators';
import { Usuario } from '../usuario/usuario';

@Component({
    selector: 'todo-usuario-list',
    templateUrl: './usuario-list.component.html'
})
export class UsuarioListComponent implements OnInit {

    private usuarios = new BehaviorSubject<any>(null);
    private usuarioSelecionado: Usuario
    private termoPesquisa: string;
    private indicePagina: number;

    @Input() exibeFormularioNovo: boolean;

    constructor(private usuarioService: UsuarioService) { }

    ngOnInit(): void {
        this.termoPesquisa = "";
        this.indicePagina = 1;
        this.buscarDados("", 1);
    }

    buscarDados(termoPesquisa: string, pagina: number) {
        this.usuarioService.buscarUsuarioPorNome(termoPesquisa, pagina).pipe(debounceTime(500)).subscribe(
            (response) => {
                this.usuarios.next(response);
            },
            err => {
                alert(err.error.toString());
            }
        )
    }

    novo() {
        this.exibeFormularioNovo = true;
    }

    voltar() {
        this.exibeFormularioNovo = false;
        this.buscarDados("", 1);
    }

    editar(usuario) {
        this.usuarioSelecionado = usuario; 
        this.exibeFormularioNovo = true;
    }

    preencherTermoPesquisa(valor) {
        this.termoPesquisa = valor;
    }

    proximaPagina() {
        this.indicePagina++;
        this.buscarDados(this.termoPesquisa, this.indicePagina);
    }

    paginaAnterior() {
        this.indicePagina--;
        this.buscarDados(this.termoPesquisa, this.indicePagina);
    }
}
