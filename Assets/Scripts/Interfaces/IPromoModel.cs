using ParagorGames.TestProject.Data;

namespace ParagorGames.TestProject.Interfaces
{
    public interface IPromoModel
    {
        string Title { get; }
        string GetIcon();
        PromoType Type { get; }
        PromoRarity Rarity { get; }
        int Cost { get; }
    }
}