import { NgModule } from '@angular/core';
import { HeaderComponent } from './header.component';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

@NgModule({
    declarations: [HeaderComponent],
    imports: [
        CommonModule,
        HttpClientModule,
        RouterModule
    ],
    exports: [ HeaderComponent ]
})
export class HeaderModule { }