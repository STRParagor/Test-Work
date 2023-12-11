using ParagorGames.TestProject.Services.Interfaces;

namespace ParagorGames.TestProject.Services
{
    public sealed class UserService : IUserService
    {
        public int Currency { get; private set; }
        
        public UserService()
        {
            Currency = 1000;
        }

        void IUserService.AddCurrency(int delta)
        {
            Currency += delta;
        }

        void IUserService.ReduceCurrency(int delta)
        {
            Currency -= delta;
        }
        
        bool IUserService.HasCurrency(int amount)
        {
            return Currency >= amount;
        }
    }
}