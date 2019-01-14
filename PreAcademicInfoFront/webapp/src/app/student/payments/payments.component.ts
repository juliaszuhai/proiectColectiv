import { Component, OnInit, HostListener } from '@angular/core';
import { MatRadioChange } from '@angular/material/radio';
import { MatSelect } from '@angular/material';
@Component({
  selector: 'app-payments',
  templateUrl: './payments.component.html',
  styleUrls: ['./payments.component.scss']
})
export class PaymentsComponent implements OnInit {
  
  semestre = [
    {value: '1', viewValue: 'semestrul 1'},
    {value: '2', viewValue: 'semestrul 2'},
    {value: '3', viewValue: 'semestrul 3'},
    {value:'4', viewValue:'semestrul 4'},
    {value:'5', viewValue:'semestrul 5'},
    {value:'6', viewValue:'semestrul 6'}
    ];

  handler: any;
  amount = 360000;
  globalListener: any;
  fixedamount = 360000;
  selectedSemestru :string;

  numeTransactie: string;
  tipTranzactie: string;
  inTranse : boolean;
  constructor() { }

  ngOnInit() {
    this.numeTransactie = "Plata semestrul 1";
    this.tipTranzactie = "Plata integrala";
    this.inTranse = false;
  }
  openCheckout() {
    this.numeTransactie = "Plata " + this.selectedSemestru;
    if(this.inTranse == false)
    {
      this.tipTranzactie = "Plata intgrala";
      this.amount =this.fixedamount 
    }
    else{
      this.amount =this.fixedamount / 4;
    }
    var handler = (<any>window).StripeCheckout.configure({
      key: 'pk_test_oi0sKPJYLGjdvOXOM8tE8cMa',
      locale: 'auto',
      token: function (token: any) {
        // You can access the token ID with `token.id`.
        // Get the token ID to your server-side code for use.
      }
    });

    handler.open({
      name: this.numeTransactie,
      description: this.tipTranzactie,
      amount: this.amount
    });
  }
  radioChange(event: MatRadioChange) {
    this.tipTranzactie = "Plata transa " + event.value;
  }
  semestuChanged(event: MatSelect) {
    this.selectedSemestru = event.value;
  }

  ngOnDestroy() {
    this.globalListener();
}
}
