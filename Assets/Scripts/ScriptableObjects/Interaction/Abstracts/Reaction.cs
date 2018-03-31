using UnityEngine;
// This is the base class for all Reactions.
// There are arrays of inheriting Reactions on ReactionCollections.
public abstract class Reaction : MonoBehaviour
{
    public void Init()
    {
        SpecificInit();
    }

    protected virtual void SpecificInit() { }

    public void React()
    {
        ImmediateReaction();
    }

    protected abstract void ImmediateReaction();
}
