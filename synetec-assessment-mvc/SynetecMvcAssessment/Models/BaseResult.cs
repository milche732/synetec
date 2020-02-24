using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterviewTestTemplatev2.Models
{
    public class BaseResult<T>
    {
        public T Result { get; protected set; }
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
    }
}