import { Component, OnInit, Input, Output, EventEmitter  } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Dropdown } from './dropdown';

@Component({
  selector: 'todo-dropdown',
  templateUrl: './dropdown.component.html'
})
export class DropdrowComponent implements OnInit {

  @Input() dados: BehaviorSubject<Dropdown>;
  @Input() selecionaValor: BehaviorSubject<string>
  @Output() valorSelecionado = new EventEmitter<string>();

  constructor() { }

  ngOnInit(): void {
  }


  onChange(valor) {
    this.valorSelecionado.emit(valor);
  }

}
