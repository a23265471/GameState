using UnityEngine;

// This Reaction has a delay but is not a DelayedReaction.
// This is because the TextManager component handles the
// delay instead of the Reaction.
public class TextReaction : Reaction
{
    public string message;
    public Color textColor = Color.white;
    public float delay;

    private TextManager textManager;
	protected override void SpecificInit()
	{
        textManager = GameObject.FindObjectOfType<TextManager>();
	}

	protected override void ImmediateReaction()
	{
        textManager.DisplayMessage(message, textColor, delay);
	}
}