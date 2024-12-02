using Zenject;

namespace MemoryGame.GamePlay
{
    public class GameCardPresenter: IGameCardPresenter
    {
        private readonly IGameCardView _view;
        private readonly GameCardSprites _sprites;

        public GameCardPresenter(IGameCardView view,
                                 GameCardSprites sprites)
        {
            _view = view;
            _sprites = sprites;
        }

        public void SetModel(GameCardModel model)
        {
            _view.SetPosition(model.Position);
            _view.SetSize(model.Size);
        }

        public void Initialize()
        {
        }

        public void UnInitialize()
        {
        }

        #region Factory

        public class Factory : PlaceholderFactory<IGameCardView, GameCardPresenter>
        {
        }

        #endregion
    }
}
