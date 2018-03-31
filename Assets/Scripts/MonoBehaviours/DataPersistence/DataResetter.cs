using UnityEngine;

// This script is used to reset scriptable objects
// back to their default values.  This is useful
// in the editor when serialized data can persist
// between entering and exiting play mode.  It is
// also useful for situations where the game needs
// to reset without being closed, for example a new
// play through.
public class DataResetter : MonoBehaviour
{
    public ResettableScriptableObject[] resettableScriptableObject;
    private void Awake()
    {
        for(int i = 0; i < resettableScriptableObject.Length; i++)
        {
            resettableScriptableObject[i].Reset();

        }

    }
}
