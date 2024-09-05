import { Component } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';
import { FormComponent } from "../../PurchesOrder/PurchesOrderForm/form/form.component";

@Component({
  selector: 'app-base-table',
  standalone: true,
  imports: [RouterOutlet, RouterLink, FormComponent,FormComponent],
  templateUrl: './base-table.component.html',
  styleUrl: './base-table.component.scss'
})
export class BaseTableComponent {

}
