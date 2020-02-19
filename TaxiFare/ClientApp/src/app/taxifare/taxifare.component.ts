import { Component, OnInit, Inject } from '@angular/core';
import { FormBuilder, NgForm, FormGroup, Validators, FormControl } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-taxifare',
  templateUrl: './taxifare.component.html',
})
export class TaxiFareComponent implements OnInit {
  public cost: String = "$0.00";
  public taxiForm: FormGroup;
  public timeG6OrIdle: number;
  public distanceL6: number;
  public date: string;
  public startTime: string;

  public formatter = new Intl.NumberFormat('en-US', {
    style: 'currency',
    currency: 'USD',
  });

  constructor( private formBuilder: FormBuilder, private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { 
    this.taxiForm = this.formBuilder.group({
      timeG6OrIdle: new FormControl(this.timeG6OrIdle, [Validators.required]),
      distanceL6: new FormControl(this.distanceL6, [Validators.required]),
      date: new FormControl(this.date, [Validators.required]),
      startTime: new FormControl(this.startTime, [Validators.required]),
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