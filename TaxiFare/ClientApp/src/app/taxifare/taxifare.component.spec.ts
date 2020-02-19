import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { TaxiFareComponent } from './taxifare.component';

describe('HomeComponent', () => {
  let component: TaxiFareComponent;
  let fixture: ComponentFixture<TaxiFareComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TaxiFareComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TaxiFareComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
