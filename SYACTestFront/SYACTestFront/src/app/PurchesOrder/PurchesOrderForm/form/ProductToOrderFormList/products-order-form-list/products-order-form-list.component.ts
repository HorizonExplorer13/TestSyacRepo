import { Component, inject, OnInit } from '@angular/core';
import {
  Form,
  FormArray,
  FormBuilder,
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { map } from 'rxjs';
export interface test {
  testText?: string | null;
  textArray?: testarray[] | null;
}
export interface testarray {
  textarrayobject?: string | null;
}

@Component({
  selector: 'app-products-order-form-list',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './products-order-form-list.component.html',
  styleUrl: './products-order-form-list.component.scss',
})
export class ProductsOrderFormListComponent {
  index: number = 0;
  arraymessageerror: string = '';
  public FGRP = inject(FormBuilder);
  public FormRequestedProducts = this.FGRP.group({
    testText: ['', [Validators.required]],
    textArray: this.FGRP.array<FormGroup>([]),
  });

  public getTextArrayControls(): FormGroup[] {
    return this.FormRequestedProducts.controls.textArray
      .controls as FormGroup[];
  }

  public getTextArrayControl(index: number): FormControl {
    this.index = index;
    return (
      this.FormRequestedProducts.controls.textArray.controls.at(
        index
      ) as FormGroup
    ).get('textarrayobject') as FormControl;
  }

  AddItem(): void {
    this.FormRequestedProducts.controls.textArray.push(
      this.FGRP.group({
        textarrayobject: ['', [Validators.required]],
      })
    );
    this.getTextArrayControls();

    if (this.arraymessageerror != '' || null) {
      this.arraymessageerror = '';
    }
  }

  removeItem(index: number): void {
    this.FormRequestedProducts.controls.textArray.removeAt(index);
  }

  public onSubmit() {
    console.log('getTextArrayControls()', this.getTextArrayControls());
    console.log(
      'getTextArrayControl(this.index)',
      this.getTextArrayControl(this.index)
    );
    console.log(this.FormRequestedProducts.value);
    if (this.FormRequestedProducts.invalid) {
      console.log('invalidForm');
      return this.FormRequestedProducts.markAllAsTouched();
    } else if (this.getTextArrayControls().length === 0) {
      console.log('textArray is empty');
      this.arraymessageerror = "textArray can't be empty .";
    }
    const testObject: test = this.FormRequestedProducts.getRawValue();
    console.log('testObject', testObject);
  }
}
