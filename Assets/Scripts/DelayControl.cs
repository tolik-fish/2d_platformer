using System;
using System.Collections;
using UnityEngine;

public class DelayControl : MonoBehaviour
{
    public event Action TimeIsOver; 

    public IEnumerator WaitTime(float time)
    {
        var wait = new WaitForSeconds(time);

        yield return wait;

        TimeIsOver?.Invoke();
    }
}