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
  private indicePagina: number;
  private termoPesquisa: string;

  @Input() exibeFormularioNovo: boolean;

  constructor(private instituicaoEnsinoService: InstituicaoEnsinoService) {
  }

  ngOnInit(): void {
    this.termoPesquisa = "";
    this.indicePagina = 1;
    this.buscarDados("", 1);
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
