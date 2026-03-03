public interface IMover
{
    IMoveSetting Setting { get; }

    void Move(float direction) { }
}