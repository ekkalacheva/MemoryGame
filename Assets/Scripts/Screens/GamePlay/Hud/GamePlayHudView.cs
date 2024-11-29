using System;
using Assets.Scripts.Base.View;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.Screens.GamePlay
{
    public class GamePlayHudView : MonoBehaviour, IGamePlayHudView
    {
        public event Action BackButtonClicked;
        public event Action RestartButtonClicked;

        [SerializeField]
        private Button _backButton;

        [SerializeField]
        private Button _restartButton;

        private IPresenter _presenter;

        [Inject]
        private void Construct(GamePlayHudPresenter.Factory presenterFactory)
        {
            _presenter = presenterFactory.Create(this);
        }

        private void OnEnable()
        {
            _presenter?.Initialize();
            _backButton.onClick.AddListener(RiseBackButtonClickedEvent);
            _restartButton.onClick.AddListener(RiseRestartButtonClickedEvent);
        }

        private void OnDisable()
        {
            _presenter?.UnInitialize();
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