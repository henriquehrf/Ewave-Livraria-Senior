import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormGroup, ReactiveFormsModule, FormControl } from '@angular/forms';
import { BehaviorSubject, Observable } from 'rxjs';
import { Router } from '@angular/router';
import { debounceTime } from 'rxjs/operators';
import { LivroService } from '../livro/livro.service';
import { UserService } from 'app/core/user/usuario.service';
import { User } from 'app/core/user/usuario';
import { Emprestimo } from 'app/emprestimos/emprestimo';

@Component({
  selector: 'todo-livro-list',
  templateUrl: './livro-list.component.html'
})
export class LivroListComponent implements OnInit {

  private livros = new BehaviorSubject<any>(null);
  user$: Observable<User>;
  private termoPesquisa: string;

  @Input() exibeFormularioNovo: boolean;

  constructor(private livroService: LivroService, private userService: UserService) {
    this.user$ = userService.getUser();
  }

  ngOnInit(): void {
    this.termoPesquisa = "";
    this.buscarDados();
  }

  buscarDados() {
    this.livroService.buscarLivroPoTitulo(this.termoPesquisa).pipe(debounceTime(500)).subscribe(
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
    this.exibeFormularioNovo = false;
  }

  emprestar(livro) {
    this.user$.subscribe(
      (usuario) => {
        let emprestimo  = {idLivro:livro.id, idUsuario:usuario.id};
        this.livroService.emprestarLivro(emprestimo).subscribe(
          () => {
            alert("Emprestimo feito com sucesso!");
            this.buscarDados();
          },
          err => {
            alert(err.error.toString());
          }
        )
      }
    );
  }

  preencherTermoPesquisa(valor) {
    this.termoPesquisa = valor;
  }
}
