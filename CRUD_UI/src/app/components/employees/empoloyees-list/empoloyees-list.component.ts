import { Component, OnInit } from '@angular/core';
import { Employee } from 'src/app/models/employee.model';
import { EmployeesService } from 'src/app/services/employees.service';

@Component({
  selector: 'app-empoloyees-list',
  templateUrl: './empoloyees-list.component.html',
  styleUrls: ['./empoloyees-list.component.css']
})
export class EmpoloyeesListComponent implements OnInit {

  employees: Employee[] = [];
  constructor(private employeesService: EmployeesService) {}

  ngOnInit(): void {
    this.employeesService.getAllEmployees()
    .subscribe({
      next: (employees) =>{
        this.employees = employees;
      },
      error: (response) => {
        console.log(response);
      }
    });
  }
}
