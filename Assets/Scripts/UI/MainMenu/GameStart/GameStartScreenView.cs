using System;
using MemoryGame.Base.View;
using MemoryGame.Game;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace MemoryGame.UI.MainMenu
{
    public class GameStartScreenView : BaseView, IGameStartScreenView
    {
        public event Action<GameComplexity> GameComplexityButtonClicked;

        [SerializeField]
        private Button _easyButton;

        [SerializeField]
        private Button _mediumButton;

        [SerializeField]
        private Button _hardButton;

        [Inject]
        private void Construct(GameStartScreenPresenter.Factory presenterFactory)
        {
            _presenter = presenterFactory.Create(this);
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            _easyButton.onClick.AddListener(OnEasyButtonClicked);
            _mediumButton.onClick.AddListener(OnMediumButtonClicked);
            _hardButton.onClick.AddListener(OnHardButtonClicked);
        }

        protected override void OnDisable()
        {
            base.OnDisable();
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
