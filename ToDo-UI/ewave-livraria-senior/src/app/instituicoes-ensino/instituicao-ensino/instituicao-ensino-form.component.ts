import { Component, OnInit, Input, Output, EventEmitter, OnDestroy } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { InstituicaoEnsinoService } from './instituicao-ensino.service';
import { InstituicaoEnsino } from './instituicao-ensino';

@Component({
  selector: 'todo-instituicao-ensino',
  templateUrl: './instituicao-ensino-form.component.html'
})
export class InstituicaoEnsinoFormComponent implements OnInit {

  @Input() instituicao: InstituicaoEnsino;
  @Output() exibeMenuNovo = new EventEmitter<boolean>();

  instituicaoForm: FormGroup;
  constructor(private instituicaoEnsinoService: InstituicaoEnsinoService) {
  }

  ngOnInit(): void {
    this.novoFormulario();
    this.limparFormulario();
  }

  novoFormulario() {
    this.instituicaoForm = new FormGroup({
      id: new FormControl(),
      nome: new FormControl(),
      endereco: new FormControl(),
      cnpj: new FormControl(),
      telefone: new FormControl(),
      ativo: new FormControl()
    });
  }

  salvar() {
    const ehAlteracao = (this.instituicao.id > 0);
    if (!ehAlteracao) {
      const instituicao = this.instituicaoForm.value;
      instituicao.id = 0;
      this.instituicaoEnsinoService.inserirInstituicaoEnsino(instituicao).subscribe(
        () => {
          alert("Salvo com Sucesso!!!")
          this.voltar();
        },
        err => {
          if (err.status === 400)
            alert(err.error[0].Mensagem);
          else
            alert(err.message);
        }
      )
    } else {
      const instituicao = this.instituicaoForm.value;
      instituicao.id = this.instituicao.id;
      this.instituicaoEnsinoService.alterarInstituicaoEnsino(instituicao).subscribe(
        () => {
          alert("Salvo com Sucesso!!!")
          this.voltar();
        },
        err => {
          if (err.status === 400)
            alert(err.error[0].Mensagem);
          else
            alert(err.message);
        }
      )
    }
  }

  limparFormulario() {
    this.instituicao = { id: 0, nome: "", cnpj: "", telefone: "", endereco: "", ativo: true };
  }


  voltar() {
    this.limparFormulario();
    this.exibeMenuNovo.emit(false);
  }
}
