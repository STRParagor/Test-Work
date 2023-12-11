using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ParagorGames.TestProject.UI
{
    public class PromoButtonView : MonoBehaviour
    {
        public event Action ButtonPressed = delegate { };
        
        [SerializeField] private Button _button;
        [SerializeField] private Image _background;
        [SerializeField] private Image _topBarPanel;
        [SerializeField] private Image _promoIcon;
        [SerializeField] private TextMeshProUGUI _promoNameText;
        [SerializeField] private TextMeshProUGUI _priceText;

        public void Initialize(Sprite promoIcon, string titleText, int price)
        {
            _promoIcon.sprite = promoIcon;
            _promoNameText.text = titleText;
            _priceText.text = $"x{price}";
        }

        public void SetBackgroundView(Sprite background, Color barColor)
        {
            _background.sprite = background;
            _topBarPanel.color = barColor;
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(OnButtonPressed);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveAllListeners();
        }

        private void OnButtonPressed()
        {
            ButtonPressed.Invoke();
        }
    }
}