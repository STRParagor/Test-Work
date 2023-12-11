using UnityEngine;
using UnityEngine.UI;

namespace ParagorGames.TestProject.UI
{
    public sealed class LobbyView : View
    {
        [SerializeField] private Button _startButton;
        
        private void OnEnable()
        {
            _startButton.onClick.AddListener(OnStartButtonPressed);
        }

        private void OnDisable()
        {
            _startButton.onClick.RemoveAllListeners();
        }

        private void OnStartButtonPressed()
        {
            UIService.Close("LobbyView");
            UIService.Show("PromoView");
        }
    }
}