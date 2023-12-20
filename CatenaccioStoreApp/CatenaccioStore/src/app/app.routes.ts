import { Routes } from '@angular/router';
import { OffersComponent } from './Offers/offers.component';
import { ProductsComponent } from './products/products.component';
import { AdminpanelComponent } from './adminpanel/adminpanel.component';
import { ContactComponent } from './contact/contact.component';
import { OrdersComponent } from './orders/orders.component';
import { BasketComponent } from './basket/basket.component';
import { AccountComponent } from './account/account.component';
import { PaymentComponent } from './payment/payment.component';
import { PanelProductsComponent } from './adminpanel/panel-products/panel-products.component';
import { PanelUsersComponent } from './adminpanel/panel-users/panel-users.component';
import { PanelCategoryComponent } from './adminpanel/panel-category/panel-category.component';


export const routes: Routes = [
    { path: '', component: OffersComponent },
    { path: 'product', component: ProductsComponent }, 
    { path: 'orders', component: OrdersComponent }, 
    { path: 'contact', component: ContactComponent }, 
    { path: 'adminpanel', component: AdminpanelComponent },
    { path: 'basket', component: BasketComponent },
    { path: 'account', component: AccountComponent },
    { path: 'payment', component: PaymentComponent },
    { path: 'adminpanel/panel-products', component: PanelProductsComponent },
    { path: 'adminpanel/panel-users', component: PanelUsersComponent },
    { path: 'adminpanel/panel-category', component: PanelCategoryComponent },
  ];
