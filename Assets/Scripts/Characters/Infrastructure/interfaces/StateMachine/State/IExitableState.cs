public interface IExitableState
{
    void SetStateChanger(IStateChanger stateChanger);

    void Exit();
}