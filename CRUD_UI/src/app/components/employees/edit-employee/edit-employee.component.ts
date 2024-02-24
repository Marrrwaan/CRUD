import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { Employee } from 'src/app/models/employee.model';
import { EmployeesService } from 'src/app/services/employees.service';

@Component({
  selector: 'app-edit-employee',
  templateUrl: './edit-employee.component.html',
  styleUrls: ['./edit-employee.component.css']
})
export class EditEmployeeComponent implements OnInit {

  employeeDetails: Employee = {
    id: 0,
    name: '',
    address: '',
    email: '',
    salary: 0,
    phone: ''
  };
  constructor(private route: ActivatedRoute, private employeeService: EmployeesService, private router: Router) {
  }

  ngOnInit(): void {
    this.route.paramMap.subscribe({
      next: (params) => {
        const id = params.get('id');

        if (id) {
          this.employeeService.getEmployeeById(id)
            .subscribe({
              next: (response) => {
                this.employeeDetails = response;
              }
            })
        }
      }
    })
  }

  updateEmployee() {
    this.employeeService.updateEmployee(this.employeeDetails)
      .subscribe({
        next: () => { this.router.navigate(['employees']); }
      });
  }

  deleteEmployee(id: number) {
    this.employeeService.deleteEmployee(id)
      .subscribe({
        next: () => { this.router.navigate(['employees']); }
      });
  }
}