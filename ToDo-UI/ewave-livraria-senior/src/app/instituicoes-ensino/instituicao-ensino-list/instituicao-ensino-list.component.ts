import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormGroup, ReactiveFormsModule, FormControl } from '@angular/forms';
import { InstituicaoEnsinoService } from '../instituicao-ensino/instituicao-ensino.service';
import { InstituicaoEnsino } from '../instituicao-ensino/instituicao-ensino';
import { BehaviorSubject, Observable } from 'rxjs';
import { Router } from '@angular/router';
import { debounceTime } from 'rxjs/operators';

@Component({
  selector: 'todo-instituicao-ensino-list',
  templateUrl: './instituicao-ensino-list.component.html'
})
export class InstituicaoEnsinoListComponent implements OnInit {

  private instituicoes = new BehaviorSubject<any>(null);
  private instituicaoSelecionada: InstituicaoEnsino;
  private termoPesquisa: string;

  @Input() exibeFormularioNovo: boolean;

  constructor(private instituicaoEnsinoService: InstituicaoEnsinoService) {
  }

  ngOnInit(): void {
    this.termoPesquisa = "";
    this.buscarDados();
  }

  buscarDados() {
    this.instituicaoEnsinoService.buscarInstituicaoEnsinoPorNome(this.termoPesquisa).pipe(debounceTime(500)).subscribe(
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
  }

  editar(instituicao) {
    this.instituicaoSelecionada = instituicao;
    this.exibeFormularioNovo = true;
  }

  remover(instituicao) {
    this.instituicaoEnsinoService.removerInstituicaoEnsino(instituicao.id).subscribe(
      () => {
        alert("Removido com sucesso!");
        this.buscarDados();
      },
      err => {
        alert(err);
      }
    );
  }

  preencherTermoPesquisa(valor) {
    this.termoPesquisa = valor;
  }
}
