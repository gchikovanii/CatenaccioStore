import { Routes } from '@angular/router';
import { OffersComponent } from './Offers/offers.component';
import { ProductsComponent } from './products/products.component';
import { AdminpanelComponent } from './adminpanel/adminpanel.component';
import { ContactComponent } from './contact/contact.component';
import { OrdersComponent } from './orders/orders.component';
import { BasketComponent } from './basket/basket.component';
import { AccountComponent } from './account/account.component';


export const routes: Routes = [
    { path: '', component: OffersComponent },
    { path: 'product', component: ProductsComponent }, 
    { path: 'orders', component: OrdersComponent }, 
    { path: 'contact', component: ContactComponent }, 
    { path: 'adminpanel', component: AdminpanelComponent },
    { path: 'basket', component: BasketComponent },
    { path: 'account', component: AccountComponent },
  ];
