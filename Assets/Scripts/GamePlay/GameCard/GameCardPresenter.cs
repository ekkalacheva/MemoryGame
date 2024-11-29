using Zenject;

namespace Assets.Scripts.GamePlay
{
    public class GameCardPresenter: IGameCardPresenter
    {
        private readonly IGameCardView _view;

        public GameCardPresenter(IGameCardView view)
        {
            _view = view;
        }

        public void Initialize()
        {
            throw new System.NotImplementedException();
        }

        public void UnInitialize()
        {
            throw new System.NotImplementedException();
        }

        #region Factory

        public class Factory : PlaceholderFactory<IGameCardView, GameCardPresenter>
        {
        }

        #endregion
    }
}
