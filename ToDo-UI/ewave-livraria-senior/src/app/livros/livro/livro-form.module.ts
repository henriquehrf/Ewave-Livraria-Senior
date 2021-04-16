import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormGroup, ReactiveFormsModule, FormsModule } from '@angular/forms';
import { LivroFormComponent } from './livro-form.component';

@NgModule({
    declarations: [LivroFormComponent],
    imports: [ 
        CommonModule,
        FormsModule,
        ReactiveFormsModule
    ],
    exports: [LivroFormComponent]
})
export class LivroFormModule {}