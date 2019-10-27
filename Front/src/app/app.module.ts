import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { OrderComponent } from './modules/order/order.component';
import { CarComponent } from './modules/car/car.component';
import { CarService } from './services/car.service';
import { UserService } from './services/user.service';
import { OrderService } from './services/order.service';
import { UserComponent } from './modules/user/user.component';
import { Routes, RouterModule } from '@angular/router';
import {FormsModule} from '@angular/forms';
import { EditComponent } from './modules/order/edit/edit.component';
import { FooterComponent } from './modules/footer/footer.component';
import { HeaderComponent } from './modules/header/header.component';

const appRoutes: Routes = [
  { path: 'car', component: CarComponent},
  { path: 'user', component: UserComponent},
  { path: 'order', component: OrderComponent, pathMatch: 'full' },
  { path: 'order/create', component: EditComponent },
  { path: 'order/update', component: EditComponent },
  { path: '**', redirectTo: '/'}
];
@NgModule({
  declarations: [
    AppComponent,
    OrderComponent,
    CarComponent,
    UserComponent,
    EditComponent,
    FooterComponent,
    HeaderComponent
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    AppRoutingModule,
    RouterModule.forRoot(appRoutes),
    FormsModule,
  ],
  providers: [
    CarService,
    UserService,
    OrderService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
