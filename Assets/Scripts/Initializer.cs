using Grace.DependencyInjection;
using ParagorGames.TestProject.Services;
using ParagorGames.TestProject.Services.Interfaces;
using ParagorGames.TestProject.Services.UI;
using UnityEngine;

namespace ParagorGames.TestProject
{
    public sealed class Initializer : MonoBehaviour
    {
        private DependencyInjectionContainer _container = new();
        
        private void Awake()
        {
            _container.Configure(block =>
            {
                block.Export<UserService>().As<IUserService>().Lifestyle.Singleton();
                block.Export<PromoService>().As<IPromoService>().Lifestyle.Singleton();
                block.Export<UIService>().As<IUIService>().Lifestyle.Singleton();
            });

            _container.Locate<IUserService>();
            _container.Locate<IPromoService>();
            _container.Locate<IUIService>().Show("LobbyView");
            
        }
    }
}