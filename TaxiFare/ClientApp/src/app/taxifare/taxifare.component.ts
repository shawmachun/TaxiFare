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
  public timeGreaterThanSixOrIdle: number;
  public distanceLessThanSix: number;
  public date: string;
  public startTime: string;

  public formatter = new Intl.NumberFormat('en-US', {
    style: 'currency',
    currency: 'USD',
  });

  constructor( private formBuilder: FormBuilder, private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { 
    this.taxiForm = this.formBuilder.group({
      timeGreaterThanSixOrIdle: new FormControl(this.timeGreaterThanSixOrIdle, [Validators.required]),
      distanceLessThanSix: new FormControl(this.distanceLessThanSix, [Validators.required]),
      date: new FormControl(this.date, [Validators.required]),
      startTime: new FormControl(this.startTime, [Validators.required]),
    });
  }
  
  ngOnInit() { }

  onSubmit(taxiData) {
    console.log(taxiData);
    this.http.get<any>(this.baseUrl + 'taxifare' ,{
      params: {
        distanceLessThanSix: taxiData.distanceLessThanSix.toString(),
        timeGreaterThanSixOrIdle: taxiData.timeGreaterThanSixOrIdle.toString(),
        date: taxiData.date.toString(),
        startTime: taxiData.startTime.toString()
      }
    }).subscribe(result => {
      var temp = result;
      this.cost= this.formatter.format(temp); 
    }, error => console.error(error));   
  }
}
