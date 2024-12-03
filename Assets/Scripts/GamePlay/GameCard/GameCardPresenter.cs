using Zenject;

namespace MemoryGame.GamePlay
{
    public class GameCardPresenter: IGameCardPresenter
    {
        private readonly IGameCardView _view;
        private readonly GameCardSprites _sprites;
        private readonly SignalBus _signals;
        private IGameCardModel _model;

        public GameCardPresenter(IGameCardView view,
                                 GameCardSprites sprites,
                                 SignalBus signals)
        {
            _view = view;
            _sprites = sprites;
            _signals = signals;
        }

        public void SetModel(IGameCardModel model)
        {
            _model = model;

            _view.SetPosition(model.Position);
            _view.SetSize(model.Size);
            _view.SetBackSprite(_sprites.Back);
            _view.SetFaceSprite(_sprites.Faces[model.Id]);
        }

        public void Initialize()
        {
            _view.Clicked += OnCardClicked;
        }

        public void UnInitialize()
        {
            _view.Clicked -= OnCardClicked;
        }

        private void OnCardClicked()
        {
            _signals.TryFire(new GamePlaySignals.CardClicked(_model));
        }

        #region Factory

        public class Factory : PlaceholderFactory<IGameCardView, GameCardPresenter>
        {
        }

        #endregion
    }
}
