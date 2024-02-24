
Description
This project is aimed at demonstrating CRUD operations using angular and .net.

Getting Started
To run this project locally, you need to follow these instructions:

Prerequisites
MSSQL Server installed on your local machine.
Visual Studio or any other code editor of your choice.
Installing
Clone this repository to your local machine.
Open the solution file in Visual Studio.
Database Setup
Connect to your MSSQL Server instance on localhost.
Create a new database named employeedb.
Run the following SQL script to create the Employees table within the employeedb database:
sql
Copy code
CREATE TABLE Employees (
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(255) NOT NULL,
    Email NVARCHAR(255),
    Phone NVARCHAR(20),
    Address NVARCHAR(255),
    Salary INT NOT NULL
);
