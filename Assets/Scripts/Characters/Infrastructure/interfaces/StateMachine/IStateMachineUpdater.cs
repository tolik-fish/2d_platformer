public interface IStateMachineUpdater
{
    void UpdateState(float deltaTime);

    void FixedUpdateState(float deltaTime);
}