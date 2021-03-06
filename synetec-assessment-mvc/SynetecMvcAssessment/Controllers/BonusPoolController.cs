﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InterviewTestTemplatev2.Models;
using Synetec.Domain;
using Synetec.Domain.Models;
using Synetec.Domain.Repository;
using Synetec.Domain.Services;

namespace InterviewTestTemplatev2.Controllers
{
    public class BonusPoolController : Controller
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IBonusCalculatorService bonusCalculatorService;

        public BonusPoolController(IEmployeeRepository employeeRepository, IBonusCalculatorService bonusCalculatorService )
        {
            if (employeeRepository == null)
            {
                throw new ArgumentNullException(nameof(employeeRepository));
            }

            if (bonusCalculatorService == null)
            {
                throw new ArgumentNullException(nameof(bonusCalculatorService));
            }

            this.employeeRepository = employeeRepository;
            this.bonusCalculatorService = bonusCalculatorService;
        }

        // GET: BonusPool
        public ActionResult Index()
        {
            BonusPoolCalculatorModel model = new BonusPoolCalculatorModel();
            model.AllEmployees = employeeRepository.GetAll();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Calculate(BonusPoolCalculatorRequest model)
        {
            BonusPoolCalculatorResultModel calcModel = new BonusPoolCalculatorResultModel();

            if (model.BonusPoolAmount < 0)
            {
                calcModel.ErrorMessage = "Bonus must be greater than 0";
                calcModel.Success = false;
            }
            else
            {
                var employee = employeeRepository.Get(model.SelectedEmployeeId);
                if (employee != null)
                {
                    decimal bonusAllocation = bonusCalculatorService.CalculateBonus(model.BonusPoolAmount, model.SelectedEmployeeId);
                    calcModel.Result.hrEmployee = employee;
                    calcModel.Result.bonusPoolAllocation = (int)bonusAllocation;
                    calcModel.Success = true;
                }
                else
                {
                    calcModel.ErrorMessage = "Employee was not found!";
                    calcModel.Success = false;
                }
            }
            return View(calcModel);
        }
    }
}