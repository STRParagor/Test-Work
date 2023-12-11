using System.Collections.Generic;
using ParagorGames.TestProject.Interfaces;

namespace ParagorGames.TestProject.Services.Interfaces
{
    public interface IPromoService
    {
        IReadOnlyList<IPromoModel> GetPromos();
    }
}