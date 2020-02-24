namespace Synetec.Domain.Services
{
    public interface IBonusCalculatorService
    {
        decimal CalculateBonus(int bonusPoolAmount, int employeeId);
    }
}