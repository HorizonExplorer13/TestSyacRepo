import { HttpClient, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ProductsrequestedList } from '../../interfaces/Products/IProductsRequestedListDTO';
import { Observable, tap } from 'rxjs';
import { Servicerresponse } from '../../interfaces/IServiceResponse';
import { ProductCreate } from '../../interfaces/Products/IProductCreate';

@Injectable({
  providedIn: 'root'
})
export class ProductsServiceService {

  constructor(private httpcall : HttpClient) { }

  public getProducts(): Observable<HttpResponse<Servicerresponse<ProductsrequestedList[]>>> {
    return this.httpcall.get<Servicerresponse<ProductsrequestedList[]>>('https://localhost:44300/Api/Products/getproductslist',{
      observe:'response'
    }).pipe(tap((Response) => console.log('serviceresponse:',Response)
            
            ))
  }

  public createProductList (productList:ProductCreate[]): Observable<HttpResponse<any>>{
    return this.httpcall.post('https://localhost:44300/Api/',productList,{observe:'response'}).pipe(tap((response)=>console.log(response)))
  }
}
