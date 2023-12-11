using System;
using UnityEngine;

namespace ParagorGames.TestProject.Data
{
    [Serializable]
    public class PromoRarityViewInfo
    {
        [field: SerializeField] public Color BarColor { get; private set; }
        [field: SerializeField] public Sprite BackgroundSprite { get; private set; }
    }
}