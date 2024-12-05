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
        private void Construct(GameCardPresenter.Factory presenterFactory)
        {
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

        public void Open()
        {
            _backRenderer.gameObject.SetActive(false);
            _faceRenderer.gameObject.SetActive(true);
        }

        public void Close()
        {
            _backRenderer.gameObject.SetActive(true);
            _faceRenderer.gameObject.SetActive(false);
        }

        private void OnMouseDown()
        {
            RiseClickedEvent();
        }

        private void RiseClickedEvent()
        {
            Clicked?.Invoke();
        }

        public static implicit operator GameCardPresenter(GameCardView view)
        {
            return view._presenter as GameCardPresenter;
        }

        #region Pool

        public class Pool : MonoMemoryPool<Transform, Vector2, float, GameCardView>
        {
            protected override void Reinitialize(Transform parent, Vector2 position, float size, GameCardView view)
            {
                view.transform.SetParent(parent, false);
                view.SetPosition(position);
                view.SetSize(size);
            }
        }

        #endregion
    }
}
