import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Employee } from '../models/employee.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EmployeesService {

baseApiUrl: string= environment.baseApiUrl;
  constructor(private http: HttpClient) { }

  getAllEmployees(): Observable<Employee[]>{
    return this.http.get<Employee[]>(this.baseApiUrl + '/GetEmployees');
  }

  addEmployee(newEmployee :Employee): Observable<Employee>{
    return this.http.post<Employee>(this.baseApiUrl+'/AddEmployee', newEmployee);
  }

  getEmployeeById(id :string): Observable<Employee>{
    return this.http.get<Employee>(this.baseApiUrl+'/GetEmployeeById'+ id);
  }

  updateEmployee(updatedEmployee: Employee):Observable<Employee>{
    return this.http.post<Employee>(this.baseApiUrl+'/UpdateEmployee', updatedEmployee);
  }

  deleteEmployee(id:number):Observable<Employee>{
    return this.http.get<Employee>(this.baseApiUrl+'/DeleteEmployee' + id);
  }
}
