import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { Livro } from './livro';
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';
import { LivroService } from './livro.service';

@Component({
  selector: 'todo-livro',
  templateUrl: './livro-form.component.html',
  styleUrls: ['./livro-form.component.css']
})
export class LivroFormComponent implements OnInit {


  @Input() livro: Livro;
  @Output() exibeMenuNovo = new EventEmitter<boolean>();
  file: File;

  livroForm: FormGroup;
  constructor(private livroService: LivroService, private formBuilder: FormBuilder) {
  }

  ngOnInit(): void {
    this.novoFormulario();
    this.limparFormulario();
    this.livroForm = this.formBuilder.group({
      titulo: ['', Validators.required],
      genero: ['', Validators.required],
      sinopse: ['', Validators.required],
      autor: ['', Validators.required]
    });
  }

  novoFormulario() {
    this.livroForm = new FormGroup({
      id: new FormControl(),
      titulo: new FormControl(),
      genero: new FormControl(),
      autor: new FormControl(),
      sinopse: new FormControl(),
      disponibilidade: new FormControl(),
      guidCapa: new FormControl(),
      ativo: new FormControl()
    });
  }

  salvar() {
    if (!this.livroForm.valid)
      return alert("Formulário inválido");

    let livro = this.livroForm.getRawValue();
    livro.id = this.livro.id;
    livro.disponibilidade = true;
    if (this.livro.arquivoCapa) {
      this.livroService.removerCapa(this.livro.guidCapa).subscribe(
        () => {console.log("Imagem removida!")}
      )
      this.livroService.uploadCapa(this.file).subscribe(
        (guid) => {
          livro.guidCapa = guid['guid'];
          this.salvarLivro(livro);
        },
        err => alert(err.error.toString())
      )
    } else {
      this.salvarLivro(livro);
    }



  }

  salvarLivro(livro) {
    if (livro.id > 0) {
      this.livroService.alterarLivro(livro).subscribe(
        () => {
          alert("Salvo com sucesso!");
          this.voltar();
        },
        err => alert(err.error.toString())
      )
    } else {

      this.livroService.inserirLivro(livro).subscribe(
        () => {
          alert("Salvo com sucesso!");
          this.voltar();
        },
        err => alert(err.error.toString())
      )
    }
  }

  preVisualizarCapa(file) {
    this.file = file;
    var reader = new FileReader();
    reader.readAsDataURL(file);
    reader.onload = (_event) => {
      this.livro.arquivoCapa = reader.result;
    }
  }

  limparFormulario() {
    this.livroForm.reset();
    this.livro = {
      id: 0,
      titulo: "",
      genero: "",
      autor: "",
      sinopse: "",
      disponibilidade: true,
      guidCapa: "",
      reservado: false,
      ativo: true,
      arquivoCapa: null
    };
    this.file = null;
  }

  voltar() {
    this.limparFormulario();
    this.exibeMenuNovo.emit(false);
  }

}
