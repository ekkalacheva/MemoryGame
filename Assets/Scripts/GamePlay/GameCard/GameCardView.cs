using MemoryGame.Base.View;
using UnityEngine;
using Zenject;

namespace MemoryGame.GamePlay
{
    public class GameCardView : BaseView, IGameCardView
    {
        [Inject]
        private void Construct(Transform parent,
                               GameCardPresenter.Factory presenterFactory)
        {
            transform.SetParent(parent, false);
            _presenter = presenterFactory.Create(this);
        }

        public void SetPosition(Vector2 position)
        {
            transform.position = new Vector3(position.x, position.y, transform.position.y);
        }

        public void SetSize(float size)
        {
            transform.localScale = new Vector3(size, size, transform.localScale.z);
        }

        protected override void OnEnable()
        {
            base.OnEnable();
        }

        protected override void OnDisable()
        {
            base.OnDisable();
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
