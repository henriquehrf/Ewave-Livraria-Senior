import { NgModule } from '@angular/core';
import { InstituicaoEnsinoFormComponent } from './instituicao-ensino-form.component';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DropDownModule } from 'app/shared/components/dropdown/dropdown.module';

@NgModule({
    declarations: [InstituicaoEnsinoFormComponent],
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        DropDownModule],
    exports: [
        InstituicaoEnsinoFormComponent
    ]
})
export class InstituicaoEnsinoFormModule { }