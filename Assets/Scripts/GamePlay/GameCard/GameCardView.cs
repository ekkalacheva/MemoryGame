using System;
using MemoryGame.Base.View;
using UnityEngine;
using Zenject;

namespace MemoryGame.GamePlay
{
    public class GameCardView : BaseView, IGameCardView
    {
        [SerializeField]
        private SpriteRenderer _backRenderer;

        [SerializeField]
        private SpriteRenderer _faceRenderer;

        public event Action Clicked;

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

        public void SetBackSprite(Sprite sprite)
        {
            _backRenderer.sprite = sprite;
        }

        public void SetFaceSprite(Sprite sprite)
        {
            _faceRenderer.sprite = sprite;
        }

        private void OnMouseDown()
        {
            RiseClickedEvent();
        }

        private void RiseClickedEvent()
        {
            Clicked?.Invoke();
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
