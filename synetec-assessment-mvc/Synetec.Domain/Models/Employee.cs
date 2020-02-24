﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Synetec.Domain.Models
{
    public class Employee
    {
        public int ID { get; set; }
        public string FistName { get; set; }
        public string SecondName { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public int HrDepartmentId { get; set; }
        public string JobTitle { get; set; }
        public int Salary { get; set; }
        public string Full_Name { get; set; }
    }
}
