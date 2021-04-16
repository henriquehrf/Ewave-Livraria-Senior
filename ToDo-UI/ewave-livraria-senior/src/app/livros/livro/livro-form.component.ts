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
      autor: ['', Validators.required],
      guidCapa: ['', Validators.required],
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
    });
  }

  salvar() {
    if (!this.livroForm.valid)
      return alert("Formulário inválido");

    let livro = this.livroForm.getRawValue();
    livro.id = 0;
    livro.disponibilidade = true;

    this.livroService.uploadCapa(this.file).subscribe(
      (guid) => {
        livro.guidCapa = guid['guid'];
        this.salvarLivro(livro);
      },
      err => alert(err.error.toString())
    )

  }

  salvarLivro(livro) {
    this.livroService.inserirLivro(livro).subscribe(
      () => {
        alert("Salvo com sucesso!");
        this.voltar();
      },
      err => alert(err.error.toString())
    )
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
      guidCapa: ""
    };
  }

  voltar() {
    this.limparFormulario();
    this.exibeMenuNovo.emit(false);
  }

}
