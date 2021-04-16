import { NgModule } from '@angular/core';
import { InstituicaoEnsinoFormModule } from './instituicao-ensino/instituicao-ensino-form.module';
import { InstituicaoEnsinoListModule } from './instituicao-ensino-list/instituicao-ensino-list.module';
import { CommonModule } from '@angular/common';
import { FormGroup, ReactiveFormsModule } from '@angular/forms';

@NgModule({
    imports: [
        CommonModule,
        InstituicaoEnsinoFormModule,
        InstituicaoEnsinoListModule
    ],
    exports: [InstituicaoEnsinoFormModule, InstituicaoEnsinoListModule]
})
export class InstituicoesEnsinoModule { }