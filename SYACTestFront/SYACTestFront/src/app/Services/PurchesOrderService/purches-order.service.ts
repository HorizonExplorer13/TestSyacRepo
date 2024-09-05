import { HttpClient, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { createPurchesOrder } from '../../interfaces/PurchesOrders/ICreatePurchesOrder';
import { Observable, tap } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PurchesOrderService {

  constructor(private httpcall: HttpClient) { }

  createPurchesOrder(orderToCreate:createPurchesOrder):Observable<HttpResponse<any>>{
    return this.httpcall.post('https://localhost:44300/Api/PurchesOrders/CreateOrder',orderToCreate,{observe:'response'}).pipe(tap((response)=>console.log(response)))

  }
}
