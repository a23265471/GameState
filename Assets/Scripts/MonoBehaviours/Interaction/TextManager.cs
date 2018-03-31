using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

// This class is used to manage the text that is
// displayed on screen.  In situations where many
// messages are triggered one after another it
// makes sure they are played in the correct order.
public class TextManager : MonoBehaviour
{
    public struct Instruction
    {
        public string message;
        public Color textColor;
        public float startTime;

    }

    public Text text;
    public float displayTimePerCharacter = 0.1f;
    public float additionDisplayTime = 0.5f;
    private List<Instruction> instruction = new List<Instruction>();
    private float clearTime;
	// This function is called from TextReactions in order to display a message to the screen.
	public void DisplayMessage (string message, Color textColor, float delay)
    {
        float starTime = Time.time + delay;
        float displayDuration = message.Length * displayTimePerCharacter + additionDisplayTime;
        clearTime = starTime + displayDuration;
        Instruction newInstruction = new Instruction()
        {
            message = message,
            textColor = textColor,
            startTime = starTime
        };
        instruction.Add(newInstruction);
        
    }

    private void Update()
    {

        if (instruction.Count > 0 && Time.time >= instruction[0].startTime)
        {
            text.text = instruction[0].message;
            text.color = instruction[0].textColor;
            instruction.RemoveAt(0);
        }
        else if (Time.time > clearTime)
            text.text = string.Empty;

    }
}

