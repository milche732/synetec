using System;
using System.Collections.Generic;
using System.Text;

namespace Synetec.Domain.Models
{
    public class Department
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Nullable<int> BonusPoolAllocationPerc { get; set; }
    }
}
