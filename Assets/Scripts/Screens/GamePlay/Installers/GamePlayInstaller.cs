using Zenject;

namespace Assets.Scripts.Screens.GamePlay
{
    public class GamePlayInstaller : MonoInstaller
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