import { Component, OnInit, HostListener } from '@angular/core';
import { environment } from '../../../environments/environment';
@Component({
  selector: 'app-payments',
  templateUrl: './payments.component.html',
  styleUrls: ['./payments.component.scss']
})
export class PaymentsComponent implements OnInit {
  
  handler: any;
  amount = 360000;
  globalListener: any;

  numeTransactie: string;
  tipTranzactie: string;
  myModel : boolean;
  constructor() { }

  ngOnInit() {
    this.numeTransactie = "Plata semestrul 1";
    this.tipTranzactie = "Plata integrala";
    this.myModel = false;
  }
  openCheckout() {
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

  ngOnDestroy() {
    this.globalListener();
}
}
