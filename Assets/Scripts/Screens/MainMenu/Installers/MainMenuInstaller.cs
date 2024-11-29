using Zenject;

namespace Assets.Scripts.Screens.MainMenu
{
    public class MainMenuInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InstallGameStartScreen();
        }

        private void InstallGameStartScreen()
        {
            Container.BindFactory<IGameStartScreenView, GameStartScreenPresenter, GameStartScreenPresenter.Factory>()
                .To<GameStartScreenPresenter>()
                .WhenInjectedInto<GameStartScreenView>();
        }
    }
}