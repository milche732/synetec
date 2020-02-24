using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Synetec.Domain.Models;
using Synetec.Domain.Repository;
using Synetec.Domain.Services;

namespace Synetec.Tests
{
    [TestClass]
    public class BonusCalcTests
    {
        private List<Employee> list = new List<Employee> {
            new Employee { ID=1, Salary = 500},
            new Employee { ID=2, Salary = 200 },
            new Employee { ID=3, Salary = 300 } };

        [TestMethod]
        public void CalculateBonus_Employee_Successfully()
        {
            Mock<IEmployeeRepository> mock = new Mock<IEmployeeRepository>();
            mock.Setup(x => x.GetAll()).Returns(list);
            mock.Setup(x => x.Get(1)).Returns(list[0]);

            BonusCalculatorService bonusCalculatorService = new BonusCalculatorService(mock.Object);

            decimal bonus = bonusCalculatorService.CalculateBonus(1000, 1);

            Assert.AreEqual(500, bonus);
        }

        [TestMethod]
        public void CalculateBonus_NoEmployee_ThrowException()
        {
            Mock<IEmployeeRepository> mock = new Mock<IEmployeeRepository>();
            mock.Setup(x => x.GetAll()).Returns(list);
            mock.Setup(x => x.Get(1)).Returns(list[0]);

            BonusCalculatorService bonusCalculatorService = new BonusCalculatorService(mock.Object);

            decimal bonus = bonusCalculatorService.CalculateBonus(1000, 1);

            Assert.AreEqual(500, bonus);
            Assert.ThrowsException<InvalidOperationException>(()=>bonusCalculatorService.CalculateBonus(1000, 10));
        }

        [TestMethod]
        public void CalculateBonus_NegativeBonuns_ThrowException()
        {
            Mock<IEmployeeRepository> mock = new Mock<IEmployeeRepository>();
            mock.Setup(x => x.GetAll()).Returns(list);

            BonusCalculatorService bonusCalculatorService = new BonusCalculatorService(mock.Object);

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => bonusCalculatorService.CalculateBonus(-1000, 10));
        }
    }
}
