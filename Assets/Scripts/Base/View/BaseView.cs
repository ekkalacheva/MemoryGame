using UnityEngine;

namespace MemoryGame.Base.View
{
    public abstract class BaseView: MonoBehaviour
    {
        protected IPresenter _presenter;

        protected virtual void OnEnable()
        {
            _presenter?.Initialize();
        }

        protected virtual void OnDisable()
        {
            _presenter?.UnInitialize();
        }
    }
}
