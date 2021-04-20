import { Component, OnInit, Input } from '@angular/core';
import { InstituicaoEnsinoService } from '../instituicao-ensino/instituicao-ensino.service';
import { InstituicaoEnsino } from '../instituicao-ensino/instituicao-ensino';
import { BehaviorSubject, Observable, Subject } from 'rxjs';
import { debounceTime, distinctUntilChanged } from 'rxjs/operators';
import { UserService } from 'app/core/user/usuario.service';
import { User } from 'app/core/user/usuario';

@Component({
  selector: 'todo-instituicao-ensino-list',
  templateUrl: './instituicao-ensino-list.component.html'
})
export class InstituicaoEnsinoListComponent implements OnInit {

  user$: Observable<User>;
  private instituicoes = new BehaviorSubject<any>(null);
  private instituicaoSelecionada: InstituicaoEnsino;
  private indicePagina: number;
  private termoPesquisa: string;
  private termoPesquisa$ = new Subject<string>();

  @Input() exibeFormularioNovo: boolean;

  constructor(private instituicaoEnsinoService: InstituicaoEnsinoService, userService: UserService) {
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
    this.instituicaoEnsinoService.buscarInstituicaoEnsinoPorNome(termoPesquisa, pagina).pipe(debounceTime(500)).subscribe(
      (response) => {
        this.instituicoes.next(response);
      },
      err => {
        alert(err);
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

  editar(instituicao) {
    this.instituicaoSelecionada = instituicao;
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
function Debounce(arg0: number) {
  throw new Error('Function not implemented.');
}

