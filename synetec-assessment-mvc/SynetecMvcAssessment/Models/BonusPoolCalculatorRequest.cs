using Synetec.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterviewTestTemplatev2.Models
{
    public class BonusPoolCalculatorRequest
    {
        public int BonusPoolAmount { get; set; }
        public int SelectedEmployeeId { get; set; }
    }
}