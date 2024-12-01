using Zenject;

namespace MemoryGame.UI.GamePlay
{
    public class GamePlayUIInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InstallHud();
        }

        private void InstallHud()
        {
            Container.BindFactory<IGamePlayHudView, GamePlayHudPresenter, GamePlayHudPresenter.Factory>()
                .To<GamePlayHudPresenter>()
                .WhenInjectedInto<GamePlayHudView>();
        }
    }
}