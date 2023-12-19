import { Component } from '@angular/core';
import {FormBuilder, Validators, FormsModule, ReactiveFormsModule} from '@angular/forms';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatStepperModule} from '@angular/material/stepper';
import {MatButtonModule} from '@angular/material/button';
import { RouterLink, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-payment',
  standalone: true,
  imports: [RouterLink,RouterOutlet,MatInputModule,MatFormFieldModule,MatStepperModule,MatButtonModule,ReactiveFormsModule,FormsModule],
  templateUrl: './payment.component.html',
  styleUrl: './payment.component.css'
})
export class PaymentComponent {
  firstFormGroup = this._fb.group({
    firstCtrl: ['', Validators.required],
  });
  secondFormGroup = this._fb.group({
    secondCtrl: ['', Validators.required],
  });
  isLinear = true;

  constructor(private _fb: FormBuilder) {}
}
