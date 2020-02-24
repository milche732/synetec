using Synetec.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterviewTestTemplatev2.Models
{
    public class BonusPoolCalculatorResult
    {
        public Employee hrEmployee;
        public int bonusPoolAllocation;
    }

    public class BonusPoolCalculatorResultModel: BaseResult<BonusPoolCalculatorResult>
    {
        public BonusPoolCalculatorResultModel()
        {
            this.Result = new BonusPoolCalculatorResult();
        }
    }
}