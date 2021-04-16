import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { EmprestimoComponent } from './emprestimo.component';

@NgModule({
    declarations: [EmprestimoComponent],
    imports: [
        CommonModule,
        HttpClientModule,
    ],
    exports: [ EmprestimoComponent ]
})
export class EmprestimoModule { }