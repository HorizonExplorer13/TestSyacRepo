import { Component, inject, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ProductsServiceService } from '../../../Services/ProductService/products-service.service';
import { ProductsrequestedList } from '../../../interfaces/Products/IProductsRequestedListDTO';
import { HttpErrorResponse, HttpResponse } from '@angular/common/http';
import { Servicerresponse } from '../../../interfaces/IServiceResponse';
import { __values } from 'tslib';
import { createPurchesOrder } from '../../../interfaces/PurchesOrders/ICreatePurchesOrder';
import { OrderProductsDTO } from '../../../interfaces/AuxInterfaces/OrderProductsDTO';
import { PurchesOrderService } from '../../../Services/PurchesOrderService/purches-order.service';

@Component({
  selector: 'app-form',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './form.component.html',
  styleUrl: './form.component.scss'
})
export class FormComponent implements OnInit {
  public partialSum!:number
  public totalPurchasValue :number[] = []
  public code!: string ;
  public productUnitValue!:number;
  public TotalPartialValue!: number;
  public currentQuantity!: number;
  public index: number | null = null
  public productsList : ProductsrequestedList[] = []
  public serviceCall=inject(ProductsServiceService)
  public servicePurchesOrder = inject(PurchesOrderService)
  public FGB = inject(FormBuilder)
  public createPurchesOrder = this.FGB.group({
    clientName:['',[Validators.required]],
    clientDocument:['',[Validators.required]],
    clientAddrees:['',[Validators.required]],
    orderProducts: this.FGB.array<FormGroup>([]),
    deliveryAddress:['',[Validators.required]],
    totalValue:['',[Validators.required]]
  })

  ngOnInit(): void {
    this.serviceCall.getProducts().subscribe({
      next:(response: HttpResponse<Servicerresponse<ProductsrequestedList[]>>) => {
        this.productsList = response.body?.data!
      },
      error: (error: HttpErrorResponse) => {
        console.log(' error: ',error.status)
      },
    })
  }

  public subscribeChange(form:FormGroup):void{
    form.get('productId')?.valueChanges.subscribe((value) => {
      var newCodeIndex = this.productsList.find(i => i.productId == value);
      this.code = newCodeIndex!.productCode
      this.productUnitValue = newCodeIndex!.unitValue
      form.get('quantity')?.enable();
    });
  }

  public subcirbeToQuantityChange(form:FormGroup):void{
    form.get('quantity')?.valueChanges.subscribe((value) => {
      var totalSum ;
      var productId = form.get('productId')?.value;
      var productSelected = this.productsList.find(i => i.productId == productId);
      var totalProductsValue = productSelected!.unitValue * value;
      if(totalProductsValue != 0){
        this.totalPurchasValue.push(totalProductsValue)
        console.log('this.totalPurchasValue',this.totalPurchasValue)
        totalSum = this.totalPurchasValue.reduce((acumulator,currentvalue) => acumulator + currentvalue,0)
        this.partialSum = totalSum
      }
      
      form.get('partialValue')?.setValue(totalProductsValue) 
      this.createPurchesOrder.controls.totalValue.setValue(this.partialSum!.toString())
      console.log('totalProductsValue: ', totalProductsValue);
      console.log('totalSum:', totalSum);
      
    })
  }

  public getTextArrayControl(index:number):FormControl{
    this.index = index
     return (this.createPurchesOrder.controls.orderProducts.controls.at(index) as FormGroup).get('textarrayobject') as FormControl
   }
  


  public getaddItemsControls(): FormGroup[]{
    return (this.createPurchesOrder.controls.orderProducts).controls as FormGroup[]
  }
//#region additem
  addItem(): void{
    const newItem = this.FGB.group({
      productId:[null,[Validators.required]],
      quantity:[null,[Validators.required]],
      partialValue:[null,[Validators.required]]
    });
    newItem.controls.quantity.disable();
    (this.createPurchesOrder.controls.orderProducts).push(newItem)
    this.subscribeChange(newItem)
    //console.log('getarraycontrols',this.getaddItemsControls())
    this.subcirbeToQuantityChange(newItem)

    
  }
//#endregion
removeItem(form:FormGroup,index:number): void {
  console.log(form);
  var subtractValue = form.get('partialValue')?.value;
  console.log('subtractValue: ', subtractValue)
  var newTotalValue = this.partialSum - subtractValue
  console.log('newTotalValue:', newTotalValue)
  this.createPurchesOrder.controls.totalValue.setValue(newTotalValue!.toString())
  console.log(index)
  this.createPurchesOrder.controls.orderProducts.removeAt(index);

}

getvalues():void
{
  const OrderProducts: OrderProductsDTO[] = [];
  this.createPurchesOrder.controls.orderProducts.controls.forEach(element => {
    const el = element as FormGroup;
    const orderProducts: OrderProductsDTO ={
      productId: el.get('productId')?.value,
      quantity: el.get('quantity')?.value,
      partialValue: el.get('partialValue')?.value,
    }
    OrderProducts.push(orderProducts)
  })
  const create: createPurchesOrder = {
    clientName: this.createPurchesOrder.controls.clientName.value,
    clientDocument:this.createPurchesOrder.controls.clientDocument.value,
    clientAddrees:this.createPurchesOrder.controls.clientAddrees.value,
    deliveryAddress:this.createPurchesOrder.controls.deliveryAddress.value,
    orderProducts: OrderProducts,
    totalValue:this.createPurchesOrder.controls.totalValue.value,

  }
  console.log('create: ' , create)
  console.log(this.createPurchesOrder.getRawValue())
  this.servicePurchesOrder.createPurchesOrder(create).subscribe({
    next:(createResponse:HttpResponse<any>)=>{
      console.log('status',createResponse.status)
      console.log(createResponse.body)
    },error:(error:HttpErrorResponse)=>{
      console.log(error)
    }
  })
}
}
