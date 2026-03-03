public interface IStateChanger
{
    void ChangeState<T>() where T : IExitableState;
}
