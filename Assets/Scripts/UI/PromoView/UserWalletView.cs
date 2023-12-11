using TMPro;
using UnityEngine;

namespace ParagorGames.TestProject.UI
{
    public class UserWalletView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _currencyText;

        public void UpdateCurrency(int currency)
        {
            _currencyText.text = currency.ToString();
        }
    }
}