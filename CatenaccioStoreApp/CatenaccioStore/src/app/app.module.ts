import { NgModule } from '@angular/core';
import { BrowserModule, provideClientHydration } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AdminpanelComponent } from './adminpanel/adminpanel.component';
import { PanelCategoryComponent } from './adminpanel/panel-category/panel-category.component';
import { PanelProductsComponent } from './adminpanel/panel-products/panel-products.component';
import { PanelUsersComponent } from './adminpanel/panel-users/panel-users.component';
import { BasketComponent } from './basket/basket.component';
import { ContactComponent } from './contact/contact.component';
import { FooterComponent } from './footer/footer.component';
import { NavigationComponent } from './navigation/navigation.component';
import { OffersComponent } from './offers/offers.component';
import { PaymentComponent } from './payment/payment.component';
import { ProductsComponent } from './products/products.component';
import { AccountComponent } from './account/account.component';
import {MatIconModule} from '@angular/material/icon';
import { RouterLink, RouterOutlet } from '@angular/router';
import {MatMenuModule} from '@angular/material/menu';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatSidenavModule} from '@angular/material/sidenav';
import { OrdersComponent } from './orders/orders.component';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import {FormsModule, ReactiveFormsModule } from '@angular/forms';
import {MatStepperModule} from '@angular/material/stepper';
import {MatPaginatorModule} from '@angular/material/paginator';
import {MatRadioModule} from '@angular/material/radio';
import {MatButtonModule} from '@angular/material/button';
import { CommonModule } from '@angular/common';
import { FlexLayoutModule } from '@angular/flex-layout';
import {FlexLayoutServerModule} from '@angular/flex-layout/server';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'; 
import { HttpClientModule } from '@angular/common/http'; 
@NgModule({
  declarations: [
    AppComponent,
    AdminpanelComponent,
    PanelCategoryComponent,
    PanelProductsComponent,
    PanelUsersComponent,
    BasketComponent,
    ContactComponent,
    FooterComponent,
    NavigationComponent,
    OffersComponent,
    PaymentComponent,
    ProductsComponent,
    AccountComponent,
    OrdersComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterLink,
    RouterOutlet,
    MatIconModule,
    MatMenuModule,
    MatToolbarModule,
    MatSidenavModule,
    MatInputModule,
    MatFormFieldModule,
    FormsModule,
    ReactiveFormsModule,
    MatStepperModule,
    MatPaginatorModule,
    MatRadioModule,
    MatButtonModule,
    CommonModule,
    FlexLayoutModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FlexLayoutServerModule
  ],
  providers: [
    provideClientHydration()
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
