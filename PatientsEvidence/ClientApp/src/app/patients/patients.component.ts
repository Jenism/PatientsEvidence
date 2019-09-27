import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-patients',
  templateUrl: './patients.component.html'
})
export class PatientsComponent {
  public patients: Patient[];

  _nameFilter: string = '';
  get nameFilter(): string {
    return this._nameFilter;
  }
  set nameFilter(value: string) {
    this._nameFilter = value;
    this.filteredPatients = this.performFilter();
  }

  _surnameFilter: string = '';
  get surnameFilter(): string {
    return this._surnameFilter;
  }
  set surnameFilter(value: string) {
    this._surnameFilter = value;
    this.filteredPatients = this.performFilter();
  }

  _ageFilter: number;
  get ageFilter(): number {
    return this._ageFilter;
  }
  set ageFilter(value: number) {
    this._ageFilter = value;
    this.filteredPatients = this.performFilter();
  }

  _dateOfBirthFilter: Date;
  get dateOfBirthFilter(): Date {
    return this._dateOfBirthFilter;
  }
  set dateOfBirthFilter(value: Date) {
    this._dateOfBirthFilter = value;
    this.filteredPatients = this.performFilter();
  }

  public filteredPatients: Patient[];


  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Patient[]>(baseUrl + 'api/Patient/GetAllPatients').subscribe(result => {
      this.patients = result;
      this.filteredPatients = this.patients;
    }, error => console.error(error));
  }

  performFilter(): Patient[] {
    var tmpPatients = this.nameFilter ? this.performNameFilter(this.patients) : this.patients;
    tmpPatients = this.surnameFilter ? this.performSurnameFilter(tmpPatients) : tmpPatients;
    tmpPatients = this.ageFilter ? this.performAgeFilter(tmpPatients) : tmpPatients;
    tmpPatients = this.dateOfBirthFilter ? this.performBirthDateFilter(tmpPatients) : tmpPatients;

    return tmpPatients;
  }

  performBirthDateFilter(filteredList: Patient[]): Patient[] {
    return filteredList.filter((patient: Patient) => (new Date(patient.dateOfBirth).getFullYear() == new Date(this.dateOfBirthFilter).getFullYear())
                                                  && (new Date(patient.dateOfBirth).getMonth() == new Date(this.dateOfBirthFilter).getMonth())
                                                  && (new Date(patient.dateOfBirth).getDate() == new Date(this.dateOfBirthFilter).getDate()));
  }

  performAgeFilter(filteredList: Patient[]): Patient[] {
    return filteredList.filter((patient: Patient) => patient.age == this.ageFilter);
  }

  performNameFilter(filteredList: Patient[]): Patient[] {
    var filterBy = this.nameFilter.toLocaleLowerCase();
    return filteredList.filter((patient: Patient) => patient.name.toLocaleLowerCase().indexOf(filterBy) !== -1);
  }

  performSurnameFilter(filteredList: Patient[]): Patient[] {
    var filterBy = this.surnameFilter.toLocaleLowerCase();
    return filteredList.filter((patient: Patient) => patient.surname.toLocaleLowerCase().indexOf(filterBy) !== -1);
  }
}

interface Patient {
  name: string;
  surname: string;
  height: number;
  weight: number;
  dateOfBirth: Date;
  age: number;
}
