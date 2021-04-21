import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { UsuarioService } from './usuario.service';
import { Usuario } from './usuario';
import { InstituicaoEnsinoService } from 'app/instituicoes-ensino/instituicao-ensino/instituicao-ensino.service';
import { BehaviorSubject } from 'rxjs';

@Component({
  selector: 'todo-usuario',
  templateUrl: './usuario-form.component.html'
})
export class UsuarioFormComponent implements OnInit {

  @Input() usuario: Usuario;
  @Output() exibeMenuNovo = new EventEmitter<boolean>();
  private instituicoesDeEnsino = new BehaviorSubject<any>(null);

  usuarioForm: FormGroup;
  constructor(private usuarioService: UsuarioService, private instituicaoEnsinoService: InstituicaoEnsinoService) {
  }

  ngOnInit(): void {
    this.novoFormulario();
    this.limparFormulario();
    this.carregarDropdonw();
  }

  novoFormulario() {
    this.usuarioForm = new FormGroup({
      id: new FormControl(),
      nome: new FormControl(),
      endereco: new FormControl(),
      cpf: new FormControl(),
      telefone: new FormControl(),
      email: new FormControl(),
      tipoUsuario: new FormControl(),
      instituicaoEnsinoId: new FormControl(),
      perfilUsuario: new FormControl(),
      login: new FormControl(),
      senha: new FormControl(),
      ativo: new FormControl()
    });
  }

  salvar() {
    const ehAlteracao = (this.usuario.id > 0);
    if (!ehAlteracao) {
      const usuario = this.usuarioForm.value;
      usuario.id = 0;
      usuario.instituicaoEnsinoId = parseInt(this.usuario.idInstituicaoEnsino.toString());
      usuario.perfilUsuario = this.usuario.perfilUsuario;
      this.usuarioService.inserirUsuario(usuario).subscribe(
        () => {
          alert("Salvo com Sucesso!!!")
          this.voltar();
        },
        err => {
          alert(err.error[0] != null ? err.error[0].Mensagem : err.error.mensagem);
        }
      )
    } else {
      const usuario = this.usuarioForm.value;
      usuario.instituicaoEnsinoId = parseInt(this.usuario.idInstituicaoEnsino.toString());
      usuario.id = this.usuario.id;
      usuario.perfilUsuario = this.usuario.perfilUsuario;
      this.usuarioService.alterarUsuario(usuario).subscribe(
        () => {
          alert("Salvo com Sucesso!!!")
          this.voltar();
        },
        err => {
          alert(err.error[0] != null ? err.error[0].Mensagem : err.error.mensagem);
        }
      )
    }
  }

  limparFormulario() {
    this.usuario = {
      id: 0,
      nome: "",
      cpf: "",
      telefone: "",
      endereco: "",
      email: "",
      instituicaoEnsinoDescricao: "",
      idInstituicaoEnsino: 0,
      perfilUsuario: 1,
      login: "",
      senha: "",
      dataSuspencao: null,
      ativo: false
    };
  }

  carregarDropdonw() {
    this.instituicaoEnsinoService.retornarInstituicaoEnsinoDropdown().subscribe(
      (response) => {
        if (this.usuario.idInstituicaoEnsino > 0) {
          this.definirInstituicao(this.usuario.idInstituicaoEnsino);
        }
        return this.instituicoesDeEnsino.next(response);
      },
      (err) => {
        alert(err);
      }
    )
  }

  definirInstituicao(valor) {
    this.usuario.idInstituicaoEnsino = valor;
  }

  definirPerfilUsuario(valor) {
    this.usuario.perfilUsuario = valor;
  }

  voltar() {
    this.limparFormulario();
    this.exibeMenuNovo.emit(false);
  }
}
