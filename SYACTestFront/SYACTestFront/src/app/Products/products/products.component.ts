import { Component, inject, OnInit } from '@angular/core';
import { ProductsServiceService } from '../../Services/ProductService/products-service.service';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ProductCreate } from '../../interfaces/Products/IProductCreate';
import { HttpErrorResponse, HttpResponse } from '@angular/common/http';

@Component({
  selector: 'app-products',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './products.component.html',
  styleUrl: './products.component.scss'
})
export class ProductsComponent implements OnInit {
  public productServiceCall = inject(ProductsServiceService)
  public FG = inject(FormBuilder)

  createProductForm = this.FG.group({
    createProductList:this.FG.array<FormGroup>([])
  })
  

  ngOnInit(): void {
    console.log('getArrayFormControls()',this.getArrayFormControls())
  }

  getArrayFormControls():FormGroup[]{
    return (this.createProductForm.controls.createProductList).controls as FormGroup[]
  }

  addProduct():void{
    var newProduct = this.FG.group({
      productName:['',[Validators.required]],
      productoCode:['',[Validators.required]],
      productUnitValue:[null,[Validators.required]]
    })
    this.createProductForm.controls.createProductList.push(newProduct)
    console.log('getArrayFormControls()',this.getArrayFormControls())
  }
  
  createProducts():void{
    const productList : ProductCreate [] = [];
    this.createProductForm.controls.createProductList.controls.forEach(element => {
      console.log('elementValue:', element.get('productName')?.value) 
      const product: ProductCreate = {
        productName: element.get('productName')?.value,
        productoCode: element.get('productoCode')?.value,
        productUnitValue: element.get('productUnitValue')?.value
      }
      productList.push(product)
    });
    console.log('productList:',productList);
    // this.productServiceCall.createProductList(productList).subscribe({
    //       next:(createResponse:HttpResponse<any>)=>{
    //         console.log(createResponse)
    //       },error:(error:HttpErrorResponse)=>{
    //         console.log(error)
    //       }
    //     })
    
  }

  // createProduct():void{
  //   const create: ProductCreate[] = {

  //     productName: this.prodcutCreateForm.controls.productName.value!,
  //     productoCode: this.prodcutCreateForm.controls.productoCode.value!,
  //     productUnitValue:this.prodcutCreateForm.controls.productUnitValue.value!
  //   }
  //   
  // }


  
}
