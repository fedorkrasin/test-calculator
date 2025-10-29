namespace Calculator.Domain.Models.Interfaces
{
    public interface ICalculatorRepository
    {
        void Save(string output);
        string GetHistory();
    }
}