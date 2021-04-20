import { Component, OnInit, Input } from '@angular/core';
import { BehaviorSubject, Observable, Subject } from 'rxjs';
import { UsuarioService } from '../usuario/usuario.service';
import { debounceTime, distinctUntilChanged } from 'rxjs/operators';
import { Usuario } from '../usuario/usuario';
import { User } from 'app/core/user/usuario';
import { UserService } from 'app/core/user/usuario.service';

@Component({
    selector: 'todo-usuario-list',
    templateUrl: './usuario-list.component.html'
})
export class UsuarioListComponent implements OnInit {

    private usuarios = new BehaviorSubject<any>(null);
    user$: Observable<User>;
    private usuarioSelecionado: Usuario
    private termoPesquisa$ = new Subject<string>();
    private termoPesquisa: string;
    private indicePagina: number;

    @Input() exibeFormularioNovo: boolean;

    constructor(private usuarioService: UsuarioService, userService: UserService) {
        this.user$ = userService.getUser();

    }

    ngOnInit(): void {
        this.termoPesquisa = "";
        this.indicePagina = 1;

        this.user$.subscribe(
            (usuario) => {
                const usuarioAdministrador = 1;
                if (usuario && usuario.idPerfil == usuarioAdministrador) {
                    this.buscarDados("", 1);

                    this.termoPesquisa$.pipe(debounceTime(500),
                        distinctUntilChanged())
                        .subscribe((termo: string) => {
                            this.indicePagina = 1;
                            this.buscarDados(termo, this.indicePagina)
                            this.termoPesquisa = termo;
                        });
                }
            }
        )

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
