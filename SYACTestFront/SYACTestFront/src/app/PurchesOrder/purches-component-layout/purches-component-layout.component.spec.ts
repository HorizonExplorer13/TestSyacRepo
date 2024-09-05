import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PurchesComponentLayoutComponent } from './purches-component-layout.component';

describe('PurchesComponentLayoutComponent', () => {
  let component: PurchesComponentLayoutComponent;
  let fixture: ComponentFixture<PurchesComponentLayoutComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PurchesComponentLayoutComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(PurchesComponentLayoutComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
