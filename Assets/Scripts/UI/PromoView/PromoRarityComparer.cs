using System.Collections.Generic;
using ParagorGames.TestProject.Interfaces;

namespace ParagorGames.TestProject.UI
{
    public sealed class PromoRarityComparer : IComparer<IPromoModel>
    {
        public int Compare(IPromoModel x, IPromoModel y)
        {
            if (x != null && y != null)
            {
                var xRarity = (int) x.Rarity;
                var yRarity = (int) y.Rarity;

                if (xRarity == yRarity)
                {
                    return 0;
                }

                return xRarity < yRarity ? 1 : -1;
            }
            
            return 0;
        }
    }
}