import { Component, OnInit, Input } from '@angular/core';
import { OrderBLCL } from 'src/app/models/order';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {

    @Input() editedOrder: OrderBLCL;

  constructor() { }

  ngOnInit() {
  }

}
