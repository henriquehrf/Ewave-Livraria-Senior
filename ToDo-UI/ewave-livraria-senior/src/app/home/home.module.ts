import { NgModule } from '@angular/core';
import { SignInComponent } from './signin/signin.component';
import { ReactiveFormsModule }  from '@angular/forms';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';


@NgModule({
    declarations: [ SignInComponent, ],
    imports: [ 
        CommonModule, 
        ReactiveFormsModule,
        RouterModule
    ]
})
export class HomeModule { }