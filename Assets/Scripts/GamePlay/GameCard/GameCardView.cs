using UnityEngine;
using Zenject;

namespace Assets.Scripts.GamePlay
{
    public class GameCardView : MonoBehaviour, IGameCardView
    {
        private IGameCardPresenter _presenter;

        [Inject]
        private void Construct(Transform parent,
                               GameCardPresenter.Factory presenterFactory)
        {
            transform.SetParent(parent, false);
            _presenter = presenterFactory.Create(this);
        }

        private void OnEnable()
        {
            _presenter?.Initialize();
        }

        private void OnDisable()
        {
            _presenter?.UnInitialize();
        }

        #region Factory

        public class Factory : PlaceholderFactory<Transform, GameCardView>
        {
        }

        public static implicit operator GameCardPresenter(GameCardView view)
        {
            return view._presenter as GameCardPresenter;
        }

        #endregion Factory
    }
}
