using MemoryGame.Base.View;

namespace MemoryGame.GamePlay
{
    internal interface IGameCardPresenter: IPresenter
    {
        void SetModel(IGameCardModel model);
    }
}
