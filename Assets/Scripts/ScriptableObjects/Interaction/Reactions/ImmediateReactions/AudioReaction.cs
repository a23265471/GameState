using UnityEngine;

// This Reaction is used to play sounds through a given AudioSource.
// Since the AudioSource itself handles delay, this is a Reaction
// rather than an DelayedReaction.
public class AudioReaction : Reaction
{
    public AudioSource audioSource;
    public AudioClip audioClip;
    public float delay;

	protected override void ImmediateReaction()
	{
        audioSource.clip = audioClip;
        audioSource.PlayDelayed(delay);
	}
}