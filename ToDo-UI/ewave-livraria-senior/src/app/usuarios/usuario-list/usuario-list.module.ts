import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SearchModule } from 'app/shared/components/search/search.module';
import { UsuarioListComponent } from './usuario-list.component';
import { UsuarioFormModule } from '../usuario/usuario-form.module';

@NgModule({
    declarations: [UsuarioListComponent],
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        SearchModule,
        UsuarioFormModule
    ],
    exports: [
        UsuarioListComponent
    ]
})
export class UsuarioListModule { }