import { NgModule } from '@angular/core';
import { DropdrowComponent } from './dropdow.component';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@NgModule({
    declarations: [DropdrowComponent],
    imports: [CommonModule,
        FormsModule],
    exports: [
        DropdrowComponent
    ]
})
export class DropDownModule {
}