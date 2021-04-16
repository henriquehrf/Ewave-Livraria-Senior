import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { InstituicaoEnsinoListComponent } from './instituicao-ensino-list.component';
import { InstituicaoEnsinoFormModule } from '../instituicao-ensino/instituicao-ensino-form.module';
import { SearchModule } from 'app/shared/components/search/search.module';

@NgModule({
    declarations: [InstituicaoEnsinoListComponent],
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        InstituicaoEnsinoFormModule,
        SearchModule],
    exports: [
        InstituicaoEnsinoListComponent
    ]
})
export class InstituicaoEnsinoListModule { }