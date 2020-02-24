using Synetec.Domain;
using Synetec.Domain.Models;
using Synetec.Domain.Repository;
using Synetec.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synetec.Infrastructure
{
    public class EmployeeRepository : IEmployeeRepository, IDisposable
    {
        private MvcInterviewV3Entities1 db = new MvcInterviewV3Entities1();

        private bool IsDisposed = false;
        public void Dispose()
        {
            if (!IsDisposed)
                db.Dispose();
            IsDisposed = true;
        }

        ~EmployeeRepository()
        {
            if (IsDisposed)
                GC.SuppressFinalize(this);
        }

        public Employee Get(int id)
        {
            var emplyee = db.HrEmployees.FirstOrDefault(item => item.ID == id);
            if (emplyee == null) return null;
            return Map(emplyee);
        }

        public IEnumerable<Employee> GetAll()
        {
            return db.HrEmployees.ToList().Select(Map);
        }

        private static Func<HrEmployee, Employee> Map = x => new Employee()
        {
            ID = x.ID,
            DateOfBirth = x.DateOfBirth,
            FistName = x.FistName,
            Full_Name = x.Full_Name,
            HrDepartmentId = x.HrDepartmentId,
            JobTitle = x.JobTitle,
            Salary = x.Salary,
            SecondName = x.SecondName
        };
    }
}
