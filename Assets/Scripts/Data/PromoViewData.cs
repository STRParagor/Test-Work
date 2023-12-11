using System.Collections.Generic;
using UnityEngine;

namespace ParagorGames.TestProject.Data
{
    [CreateAssetMenu(fileName = "PromoViewData", menuName = "ParagorGames/Data/PromoViewData", order = 0)]
    public class PromoViewData : ScriptableObject
    {
        [field: SerializeField] public PromoRarityViewInfo CommonRarityViewInfo { get; private set; }
        [field: SerializeField] public PromoRarityViewInfo RareRarityViewInfo { get; private set; }
        [field: SerializeField] public PromoRarityViewInfo EpicRarityViewInfo { get; private set; }

        private Dictionary<PromoRarity, PromoRarityViewInfo> _promoRarityView;
        
        public PromoRarityViewInfo GetPromoRarityView(PromoRarity rarity)
        {
            _promoRarityView ??= new Dictionary<PromoRarity, PromoRarityViewInfo>(3)
            {
                [PromoRarity.Common] = CommonRarityViewInfo,
                [PromoRarity.Rare] = RareRarityViewInfo,
                [PromoRarity.Epic] = EpicRarityViewInfo,
            };

            return _promoRarityView[rarity];
        }
    }
}