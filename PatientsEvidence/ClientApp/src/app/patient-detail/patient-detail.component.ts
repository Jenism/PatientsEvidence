import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';


@Component({
  selector: 'app-patient-detail',
  templateUrl: './patient-detail.component.html'
})
export class PatientDetailComponent {
  public patient: PatientDetail;
  private id: number;

  constructor(private route: ActivatedRoute, http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.route.params.subscribe(params => {
      this.id = params['id'];
    });

    http.get<PatientDetail>(baseUrl + 'api/Patient/GetPatientDetail?id=' + this.id).subscribe(result => {
      this.patient = result;
      console.log(this.patient);
    }, error => console.error(error));
  }

}

interface PatientDetail {
  name: string;
  surname: string;
  height: number;
  weight: number;
  dateOfBirth: Date;
  age: number;
  heightAverage: number;
}
