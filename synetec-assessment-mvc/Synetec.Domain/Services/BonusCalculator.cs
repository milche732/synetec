using Synetec.Domain.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Synetec.Domain.Repository;

namespace Synetec.Domain.Services
{
    public class BonusCalculatorService : IBonusCalculatorService
    {
        private readonly IEmployeeRepository employeeRepository;

        public BonusCalculatorService(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
        }

        public decimal CalculateBonus(int bonusPoolAmount, int employeeId)
        {
            Employee employee = employeeRepository.Get(employeeId);

            if (employee == null)
                throw new InvalidOperationException($"Cannot find user {employeeId}.");

            int employeeSalary = employee.Salary;

            //get the total salary budget for the company
            int totalSalary = employeeRepository.GetAll().Sum(item => item.Salary);

            //calculate the bonus allocation for the employee
            decimal bonusPercentage = (decimal)employeeSalary / (decimal)totalSalary;
            int bonusAllocation = (int)(bonusPercentage * bonusPoolAmount);

            return bonusAllocation;
        }
    }
}
