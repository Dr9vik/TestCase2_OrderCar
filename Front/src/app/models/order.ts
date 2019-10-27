import { DatePipe } from '@angular/common';
import { CarBLCL } from './car';
import { UserBLCL } from './user';


export class OrderBLCL {
    id: string;
    carId: string;
    car: CarBLCL;
    userId: string;
    user: UserBLCL;
    information: string;
    timeStart: DatePipe ;
    timeEnd: DatePipe ;
}

export class OrderBLCreate {
    carId: string;
    userId: string;
    information: string;
    timeStart: DatePipe ;
    timeEnd: DatePipe ;
}

export class OrderBLUpdate {
    id: string;
    carId: string;
    userId: string;
    information: string;
    timeStart: DatePipe ;
    timeEnd: DatePipe ;
}
