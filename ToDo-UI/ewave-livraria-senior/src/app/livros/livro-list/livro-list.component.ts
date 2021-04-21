import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { BehaviorSubject, Observable, Subject } from 'rxjs';
import { debounceTime, distinctUntilChanged } from 'rxjs/operators';
import { LivroService } from '../livro/livro.service';
import { UserService } from 'app/core/user/usuario.service';
import { User } from 'app/core/user/usuario';
import { Livro } from '../livro/livro';
import { EmprestimoService } from 'app/emprestimos/emprestimo.service';
import { environment } from '@env/environment';

@Component({
  selector: 'todo-livro-list',
  templateUrl: './livro-list.component.html',
  styleUrls: ['./livro-list.component.css']
})
export class LivroListComponent implements OnInit {

  private livros = new BehaviorSubject<any>(null);
  user$: Observable<User>;
  private termoPesquisa$ = new Subject<string>();
  private termoPesquisa: string;
  private indicePagina: number;
  livroSelecionado: Livro;
  tamanhoPaginaPadrao:number;
  endPointImagem:string;

  @Input() exibeFormularioNovo: boolean;

  constructor(private livroService: LivroService,
             private userService: UserService,
             private emprestimoService: EmprestimoService) {
    this.user$ = userService.getUser();
  }

  ngOnInit(): void {
    this.indicePagina = 1;
    this.buscarDados("", 1);
    this.termoPesquisa = "";
    this.tamanhoPaginaPadrao = environment.tamanho_pagina_reduzida;
    this.endPointImagem = environment.endPointImagem;

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
        alert(err.error[0] != null ? err.error[0].Mensagem : err.error.mensagem);
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
        this.emprestimoService.emprestarLivro(emprestimo).subscribe(
          () => {
            alert("Empréstimo feito com sucesso!");
            this.buscarDados(this.termoPesquisa, 1);
          },
          err => {
            alert(err.error[0] != null ? err.error[0].Mensagem : err.error.mensagem);
            this.buscarDados(this.termoPesquisa, 1);
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
