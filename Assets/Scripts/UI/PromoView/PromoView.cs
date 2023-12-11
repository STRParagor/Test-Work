using System.Collections.Generic;
using ParagorGames.TestProject.Data;
using ParagorGames.TestProject.Interfaces;
using ParagorGames.TestProject.Services.Interfaces;
using UnityEngine;

namespace ParagorGames.TestProject.UI
{
    public class PromoView : View
    {
        [SerializeField] private Transform _groupsContentRootTransform;
        [SerializeField] private UserWalletView _userWalletView;
        
        private IPromoService _promoService;
        private IUserService _userService;
        private PromoGroupContainerView _promoGroupContainerViewPrefab;
        private PromoButtonView _promoButtonViewPrefab;
        private PromoViewData _promoViewData;
        
        private void Start()
        {
            _promoService = Container.Locate<IPromoService>();
            _userService = Container.Locate<IUserService>();
            _promoGroupContainerViewPrefab = Resources.Load<PromoGroupContainerView>("UI/PromoView/PromoGroupContainer");
            _promoButtonViewPrefab = Resources.Load<PromoButtonView>("UI/PromoView/PromoButtonView");
            _promoViewData = Resources.Load<PromoViewData>("Data/PromoViewData");
            _userWalletView.UpdateCurrency(_userService.Currency);
            
            CreateGroups(_promoService.GetPromos());
        }

        private void CreateGroups(IReadOnlyList<IPromoModel> promoModels)
        {
            var groupsDictionary = new Dictionary<PromoType, List<IPromoModel>>();
            
            foreach (var promoModel in promoModels)
            {
                var type = promoModel.Type;
                
                if (groupsDictionary.ContainsKey(type) == false)
                {
                    groupsDictionary.Add(type, new List<IPromoModel>());
                }
                
                groupsDictionary[type].Add(promoModel);
            }
            
            foreach (var (type, promoList) in groupsDictionary)
            {
                var groupContainer = Instantiate(_promoGroupContainerViewPrefab, _groupsContentRootTransform);
                groupContainer.Initialize(promoList, _promoButtonViewPrefab, _promoViewData);
                groupContainer.SetHeaderText(type.ToString());
                groupContainer.PromoButtonPressed += OnPromoButtonPressed;
            }
        }

        private void OnPromoButtonPressed(IPromoModel promoModel)
        {
            string promoTitle = promoModel.Title.Replace("\n", string.Empty);
            
            if (_userService.HasCurrency(promoModel.Cost))
            {
                _userService.ReduceCurrency(promoModel.Cost);
                _userWalletView.UpdateCurrency(_userService.Currency);
                Debug.Log($"Purchased: {promoTitle}");
            }
            else
            {
                Debug.LogError($"{promoTitle} - Not enough {promoModel.Cost - _userService.Currency} currency");
            }
        }
    }
}
