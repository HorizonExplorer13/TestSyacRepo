import { Routes } from '@angular/router';

export const routes: Routes = [
    {path:'',loadComponent: () => import('./BaseTable/base-table/base-table.component').then(c => c.BaseTableComponent)},
    {path:'Form',loadComponent:() => import('./PurchesOrder/PurchesOrderForm/form/form.component').then(c => c.FormComponent)},
    {path:'createProducts',loadComponent:() => import('./Products/products/products.component').then(c=>c.ProductsComponent)},
    {path:'productsToRequest', loadComponent: () => import('./PurchesOrder/PurchesOrderForm/form/ProductToOrderFormList/products-order-form-list/products-order-form-list.component').then(c =>c.ProductsOrderFormListComponent)}
];
