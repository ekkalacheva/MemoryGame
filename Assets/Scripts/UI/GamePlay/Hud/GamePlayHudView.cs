using System;
using MemoryGame.Base.View;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace MemoryGame.UI.GamePlay
{
    public class GamePlayHudView : BaseView, IGamePlayHudView
    {
        public event Action BackButtonClicked;
        public event Action RestartButtonClicked;

        [SerializeField]
        private Button _backButton;

        [SerializeField]
        private Button _restartButton;

        [Inject]
        private void Construct(GamePlayHudPresenter.Factory presenterFactory)
        {
            _presenter = presenterFactory.Create(this);
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            _backButton.onClick.AddListener(RiseBackButtonClickedEvent);
            _restartButton.onClick.AddListener(RiseRestartButtonClickedEvent);
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            _backButton.onClick.RemoveListener(RiseBackButtonClickedEvent);
            _restartButton.onClick.RemoveListener(RiseRestartButtonClickedEvent);
        }

        private void RiseBackButtonClickedEvent()
        {
            BackButtonClicked?.Invoke();
        }

        private void RiseRestartButtonClickedEvent()
        {
            RestartButtonClicked?.Invoke();
        }
    }
}