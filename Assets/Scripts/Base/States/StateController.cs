namespace MemoryGame.Base.States
{
    internal class StateController
    {
        protected IState CurrentState;

        protected void SetState(IState state)
        {
            CurrentState?.OnExit();
            CurrentState = state;
            CurrentState?.OnEnter();
        }
    }
}
