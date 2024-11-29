using System;
using Assets.Scripts.Base.View;
using Assets.Scripts.Game;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.Screens.MainMenu
{
    public class GameStartScreenView : MonoBehaviour, IGameStartScreenView
    {
        public event Action<GameComplexity> GameComplexityButtonClicked;

        [SerializeField]
        private Button _easyButton;

        [SerializeField]
        private Button _mediumButton;

        [SerializeField]
        private Button _hardButton;

        private IPresenter _presenter;

        [Inject]
        private void Construct(GameStartScreenPresenter.Factory presenterFactory)
        {
            _presenter = presenterFactory.Create(this);
        }

        private void OnEnable()
        {
            _presenter?.Initialize();
            _easyButton.onClick.AddListener(OnEasyButtonClicked);
            _mediumButton.onClick.AddListener(OnMediumButtonClicked);
            _hardButton.onClick.AddListener(OnHardButtonClicked);
        }

        private void OnDisable()
        {
            _presenter?.UnInitialize();
            _easyButton.onClick.RemoveListener(OnEasyButtonClicked);
            _mediumButton.onClick.RemoveListener(OnMediumButtonClicked);
            _hardButton.onClick.RemoveListener(OnHardButtonClicked);
        }

        private void OnEasyButtonClicked()
        {
            RiseComplexityButtonClickedEvent(GameComplexity.Easy);
        }

        private void OnMediumButtonClicked()
        {
            RiseComplexityButtonClickedEvent(GameComplexity.Medium);
        }

        private void OnHardButtonClicked()
        {
            RiseComplexityButtonClickedEvent(GameComplexity.Hard);
        }

        private void RiseComplexityButtonClickedEvent(GameComplexity complexity)
        {
            GameComplexityButtonClicked?.Invoke(complexity);
        }
    }
}
