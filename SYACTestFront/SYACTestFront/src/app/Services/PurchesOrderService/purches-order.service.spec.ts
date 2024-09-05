import { TestBed } from '@angular/core/testing';

import { PurchesOrderService } from './purches-order.service';

describe('PurchesOrderService', () => {
  let service: PurchesOrderService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PurchesOrderService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
