import { Component, OnInit, Inject } from '@angular/core';
import { FormBuilder, NgForm, FormGroup, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-taxifare',
  templateUrl: './taxifare.component.html',
})
export class TaxiFareComponent implements OnInit {
  public cost: String = "$0.00";
  public taxiForm: FormGroup;
  public formatter = new Intl.NumberFormat('en-US', {
    style: 'currency',
    currency: 'USD',
  });

  constructor( private formBuilder: FormBuilder, private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { 
    this.taxiForm = this.formBuilder.group({
      timeG6OrIdle: 0,
      distanceL6: 0,
      date: new Date().toLocaleDateString('en-US', { month: '2-digit', day: '2-digit', year: 'numeric'}),
      startTime: new Date().toLocaleString('en-US', { hour: '2-digit', minute: '2-digit', hour12: true }),
    });
  }
  
  ngOnInit() { }

  onSubmit(taxiData) {
    console.log(taxiData);
    this.http.get<any>(this.baseUrl + 'taxifare' ,{
      params: {
        distanceL6: taxiData.distanceL6.toString(),
        timeG6OrIdle: taxiData.timeG6OrIdle.toString(),
        date: taxiData.date.toString(),
        startTime: taxiData.startTime.toString()
      }
    }).subscribe(result => {
      var temp = result;
      this.cost= this.formatter.format(temp); 
    }, error => console.error(error));
    
  }
}