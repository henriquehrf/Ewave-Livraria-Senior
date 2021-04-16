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
    private usuarioSelecionado: Usuario;
    private termoPesquisa: string;

    @Input() exibeFormularioNovo: boolean;

    constructor(private usuarioService: UsuarioService) { }

    ngOnInit(): void {
        this.termoPesquisa = "";
        this.buscarDados();
    }

    buscarDados() {
        this.usuarioService.buscarUsuarioPorNome(this.termoPesquisa).pipe(debounceTime(500)).subscribe(
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
    }

    editar(usuario) {
        this.usuarioSelecionado = usuario;
        this.exibeFormularioNovo = true;
    }

    remover(usuario) {
        this.usuarioService.removerUsuario(usuario.id).subscribe(
            () => {
                alert("Removido com sucesso!");
                this.buscarDados();
            },
            err => {
                alert(err.error.toString());
            }
        );
    }

    preencherTermoPesquisa(valor) {
        this.termoPesquisa = valor;
    }
}
