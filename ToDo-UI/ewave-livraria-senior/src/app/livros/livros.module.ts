import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormGroup, ReactiveFormsModule } from '@angular/forms';
import { LivroFormModule } from './livro/livro-form.module';
import { LivroListModule } from './livro-list/livro-list.module';

@NgModule({
    imports: [
        CommonModule,
        LivroFormModule,
        LivroListModule
    ],
    exports: [LivroFormModule, LivroListModule]
})
export class LivrosModule { }