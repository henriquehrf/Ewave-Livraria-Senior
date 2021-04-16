import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormGroup, ReactiveFormsModule } from '@angular/forms';
import { LivroListComponent } from './livro-list.component';
import { SearchModule } from 'app/shared/components/search/search.module';
import { LivroFormModule } from '../livro/livro-form.module';

@NgModule({
    declarations: [LivroListComponent],
    imports: [
        CommonModule,
        SearchModule,
        LivroFormModule
    ],
    exports: [LivroListComponent, LivroFormModule]
})
export class LivroListModule { }