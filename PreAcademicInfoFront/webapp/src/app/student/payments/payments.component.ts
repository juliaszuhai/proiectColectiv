import { Component, OnInit, HostListener } from '@angular/core';
import { MatRadioChange } from '@angular/material/radio';
import { MatSelect } from '@angular/material';
import { StudentService } from "../student.service";

@Component({
  selector: 'app-payments',
  templateUrl: './payments.component.html',
  styleUrls: ['./payments.component.scss']
})
export class PaymentsComponent implements OnInit {

  ani = [
    {value: '1', viewValue: 'Anul 1'},
    {value: '2', viewValue: 'Anul 2'},
    {value: '3', viewValue: 'Anul 3'}
    ];

  handler: any;
  amount = 360000;
  //globalListener: any;
  fixedamount = 360000;
  selectedSemestru :string;

  numeTransactie: string;
  tipTranzactie: string;
  inTranse : boolean;
  selectedMaterie: string;
  materii = [];

  constructor(private studentService:StudentService) { }

  ngOnInit() {
    this.numeTransactie = "Plata semestrul 1";
    this.tipTranzactie = "Plata integrala";
    this.inTranse = false;
   
    //load materile predate de un teacher
    this.studentService.getMaterii(localStorage.getItem('username'))
    .subscribe(data => 
      { console.log(data);
        for (var _i = 0; _i < data.length; _i++)
        {
          this.materii.push(data[_i]);
        }
      }
      );
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
        localStorage['username'];
      }
    });
  }
    openCheckout2() {
      this.numeTransactie = "Plata restanta"+this.selectedMaterie;
      if(this.inTranse == false)
      {
        this.tipTranzactie = "Plata intgrala";
        this.amount =this.fixedamount
      }
      else{
        this.amount = 360;
      }
      var handler = (<any>window).StripeCheckout.configure({
        key: 'pk_test_oi0sKPJYLGjdvOXOM8tE8cMa',
        locale: 'auto',
        token: function (token: any) {
          localStorage['username'];
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


}
