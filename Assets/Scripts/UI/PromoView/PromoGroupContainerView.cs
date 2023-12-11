using System;
using System.Collections.Generic;
using ParagorGames.TestProject.Data;
using ParagorGames.TestProject.Interfaces;
using TMPro;
using UnityEngine;

namespace ParagorGames.TestProject.UI
{
    public class PromoGroupContainerView : View
    {
        public event Action<IPromoModel> PromoButtonPressed = delegate {  };
        
        [SerializeField] private Transform _promoButtonsTransformRoot;
        [SerializeField] private TextMeshProUGUI _headerText;

        public void Initialize(List<IPromoModel> promoModels, PromoButtonView buttonPrefab, PromoViewData promoViewData)
        {
            promoModels.Sort(new PromoRarityComparer());

            var icons = new Dictionary<string, Sprite>(promoModels.Count);

            foreach (var promoModel in promoModels)
            {
                var promoButton = Instantiate(buttonPrefab, _promoButtonsTransformRoot);
                string iconPath = promoModel.GetIcon();
                
                if (icons.ContainsKey(iconPath) == false)
                {
                    icons.Add(iconPath, Resources.Load<Sprite>(iconPath));
                }
                
                var promoViewInfo = promoViewData.GetPromoRarityView(promoModel.Rarity);
                
                promoButton.Initialize(icons[iconPath], promoModel.Title, promoModel.Cost);
                promoButton.SetBackgroundView(promoViewInfo.BackgroundSprite, promoViewInfo.BarColor);
                promoButton.ButtonPressed += () => OnPromoButtonPressed(promoModel);
            }
        }

        public void SetHeaderText(string headerText)
        {
            _headerText.text = headerText;
        }

        private void OnPromoButtonPressed(IPromoModel promoModel)
        {
            PromoButtonPressed.Invoke(promoModel);
        }
    }
}