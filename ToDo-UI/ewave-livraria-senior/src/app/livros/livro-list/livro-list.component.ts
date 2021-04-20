import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { BehaviorSubject, Observable, Subject } from 'rxjs';
import { debounceTime, distinctUntilChanged } from 'rxjs/operators';
import { LivroService } from '../livro/livro.service';
import { UserService } from 'app/core/user/usuario.service';
import { User } from 'app/core/user/usuario';
import { Livro } from '../livro/livro';

@Component({
  selector: 'todo-livro-list',
  templateUrl: './livro-list.component.html'
})
export class LivroListComponent implements OnInit {

  private livros = new BehaviorSubject<any>(null);
  user$: Observable<User>;
  private termoPesquisa$ = new Subject<string>();
  private termoPesquisa: string;
  private indicePagina: number;
  private livroSelecionado: Livro;

  @Input() exibeFormularioNovo: boolean;

  constructor(private livroService: LivroService, private userService: UserService) {
    this.user$ = userService.getUser();
  }

  ngOnInit(): void {
    this.indicePagina = 1;
    this.buscarDados("", 1);
    this.termoPesquisa = "";

    this.termoPesquisa$.pipe(debounceTime(500),
      distinctUntilChanged())
      .subscribe((termo: string) => {
        this.indicePagina = 1;
        this.buscarDados(termo, this.indicePagina)
        this.termoPesquisa = termo;
      });
  }

  buscarDados(termoPesquisa: string, pagina: number) {
    this.livroService.buscarLivroPoTitulo(termoPesquisa, pagina).subscribe(
      (response) => {
        this.livros.next(response);
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
    this.buscarDados("", 1);
    this.exibeFormularioNovo = false;
  }

  emprestar(livro) {
    this.user$.subscribe(
      (usuario) => {
        let emprestimo = { idLivro: livro.id, idUsuario: usuario.id };
        this.livroService.emprestarLivro(emprestimo).subscribe(
          () => {
            alert("Emprestimo feito com sucesso!");
            this.buscarDados("", 1);
          },
          err => {
            alert(err.error.toString());
          }
        )
      }
    );
  }

  preencherTermoPesquisa(valor) {
    this.termoPesquisa$ = valor;
  }

  editar(livro) {
    this.livroSelecionado = livro;
    this.exibeFormularioNovo = true;
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
