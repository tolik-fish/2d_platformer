using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    protected const string StateName = "State";
    protected const int StandNumber = 0;
    protected const int RunNumber = 1;

    protected Animator Animator;

    private void Awake()
    {
        Animator = GetComponent<Animator>();
    }

    protected void PlayRun()
    {
        Animator.SetInteger(StateName, RunNumber);
    }

    protected void PlayStand()
    {
        Animator.SetInteger(StateName, StandNumber);
    }
}