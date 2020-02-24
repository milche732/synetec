using Synetec.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Synetec.Domain.Repository
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAll();
        Employee Get(int id);
    }
}
