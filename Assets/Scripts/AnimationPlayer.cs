using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    protected const string StateName = "State";
    protected const int StandNumber = 0;
    protected const int RunNumber = 1;

    protected Animator Animator;

    protected void Awake()
    {
        Animator = GetComponent<Animator>();
    }

    public void PlayRun()
    {
        Animator.SetInteger(StateName, RunNumber);
    }

    public void PlayStand()
    {
        Animator.SetInteger(StateName, StandNumber);
    }
}