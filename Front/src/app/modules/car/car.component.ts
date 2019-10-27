import { Component, OnInit } from '@angular/core';
import { CarService } from 'src/app/services/car.service';
import { CarBLCL } from 'src/app/models/car';

@Component({
  selector: 'app-car',
  templateUrl: './car.component.html',
  styleUrls: ['./car.component.css']
})
export class CarComponent implements OnInit {

  private cars: CarBLCL[] = [];
  // tslint:disable-next-line: variable-name
  constructor(private _carService: CarService) {
  }

  ngOnInit() {
    this._carService.getAll().subscribe((cars: CarBLCL[]) => this.cars = cars);
  }
}
