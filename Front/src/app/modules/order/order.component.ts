import { Component, OnInit, ViewChild, TemplateRef } from '@angular/core';
import { OrderBLCL, OrderBLCreate } from 'src/app/models/order';
import { OrderService } from 'src/app/services/order.service';
import { CarBLCL } from 'src/app/models/car';
import { UserBLCL } from 'src/app/models/user';
import { UserService } from 'src/app/services/user.service';
import { CarService } from 'src/app/services/car.service';
import { OrderBLFilter } from 'src/app/models/filters';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.css']
})
export class OrderComponent implements OnInit {

  @ViewChild('readOnlyTemplate', {static: true}) readOnlyTemplate: TemplateRef<any>;
  @ViewChild('editTemplate', {static: false}) editTemplate: TemplateRef<any>;

  private editedOrder: OrderBLCL;
  private orders: OrderBLCL[] = [];
  private isNewRecord: boolean;
  private statusMessage: string;
  // tslint:disable-next-line: variable-name
  constructor(private _orderService: OrderService, private _userService: UserService, private _carService: CarService) {

  }

  loadTemplate() {
    if (this.editedOrder) {
        return this.editTemplate;
    } else {
        return this.readOnlyTemplate;
    }
  }

addOrder() {
  this.editedOrder = new OrderBLCL();
  this.editedOrder.car = new CarBLCL();
  this.editedOrder.user = new UserBLCL();

  this.orders.push(this.editedOrder);
  this.isNewRecord = true;
}
editOrder(user: OrderBLCL) {
  this.editedOrder = user;

}
saveOrder() {
  if (this.isNewRecord) {
    // this.create = new OrderBLCreate();
    // this.create.carId = this.editedOrder.carId;
    // this.create.userId = this.editedOrder.userId;
    // this.create.information = this.editedOrder.information;
    // this.create.timeStart = this.editedOrder.timeStart;
    // this.create.timeEnd = this.editedOrder.timeEnd;

    this._orderService.create(this.editedOrder).subscribe(data => {
          this.statusMessage = 'Данные успешно добавлены',
          this.loadOrder();
      });
    this.isNewRecord = false;
    this.editedOrder = null;
  } else {
      this._orderService.update(this.editedOrder).subscribe(data => {
          this.statusMessage = 'Данные успешно обновлены',
          this.loadOrder();
      });
      this.editedOrder = null;
  }
}
cancel() {
  if (this.isNewRecord) {
      this.orders.pop();
      this.isNewRecord = false;
  }
  this.editedOrder = null;
}

deleteOrder(order: OrderBLCL) {
  this._orderService.delete(order.id).subscribe(data => {
      this.statusMessage = 'Данные успешно удалены',
      this.loadOrder();
  });
}

private loadOrder(filter?: OrderBLFilter) {
  // filter= new OrderBLFilter();
  // filter.nameCar="фольц";
  // filter.moderlCar="";
  // filter.nameUser="";
  // filter.nameCar="";
  // filter.nameCar="";
  this._orderService.getAllFilter(filter).subscribe((orders: OrderBLCL[]) => this.orders = orders);
}
  ngOnInit() {
    this.loadOrder();
  }
  dateChanged(eventDate: string): Date | null {
    return !!eventDate ? new Date(eventDate) : null;
  }
}
