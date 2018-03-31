using UnityEngine;
using System.Collections;

// This is a base class for Reactions that need to have a delay.
public abstract class DelayedReaction : Reaction
{
    public float delay;
    protected WaitForSeconds wait;

    public new void Init()
    {
        wait = new WaitForSeconds(delay);
        SpecificInit();
    }

    public new void React()
    {
        StartCoroutine(ReactCoroutine());
    }

    protected IEnumerator ReactCoroutine()
    {
        yield return wait;
        ImmediateReaction();
    }
}
