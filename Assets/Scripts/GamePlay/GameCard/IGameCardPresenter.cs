using MemoryGame.Base.View;

namespace MemoryGame.GamePlay
{
    internal interface IGameCardPresenter: IPresenter
    {
        void SetModel(GameCardModel model);
    }
}
