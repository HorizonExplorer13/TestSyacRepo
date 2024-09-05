import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductsOrderFormListComponent } from './products-order-form-list.component';

describe('ProductsOrderFormListComponent', () => {
  let component: ProductsOrderFormListComponent;
  let fixture: ComponentFixture<ProductsOrderFormListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ProductsOrderFormListComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ProductsOrderFormListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
