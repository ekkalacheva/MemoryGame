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
            SubscribeModelEvents();

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
            UnsubscribeModelEvents();
            _model = null;
        }

        private void UpdateCardState()
        {
            switch (_model.State)
            {
                case GameCardState.Closed:
                    _view.Close();
                    break;
                case GameCardState.Opened:
                    _view.Open();
                    break;
                case GameCardState.Collected:
                    break;
            }
        }

        private void SubscribeModelEvents()
        {
            if (_model == null)
            {
                return;
            }

            _model.StateChanged += UpdateCardState;
        }

        private void UnsubscribeModelEvents()
        {
            if (_model == null)
            {
                return;
            }

            _model.StateChanged -= UpdateCardState;
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
