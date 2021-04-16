import { NgModule } from '@angular/core';
import { UsuarioFormComponent } from './usuario-form.component';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DropDownModule } from 'app/shared/components/dropdown/dropdown.module';

@NgModule({
    declarations: [UsuarioFormComponent],
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        DropDownModule],
    exports: [
        UsuarioFormComponent
    ]
})
export class UsuarioFormModule { }