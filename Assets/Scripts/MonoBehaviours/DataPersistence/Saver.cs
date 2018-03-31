using UnityEngine;

// This is an abstract MonoBehaviour that is the base class
// for all classes that want to save data to persist between
// scene loads and unloads.
// For an example of using this class, see the PositionSaver
// script.
public abstract class Saver : MonoBehaviour
{
    public string id;
    public SaveData saveData;
    protected string key;
    private SceneController sceneController;

    private void Awake()
    {
        sceneController = FindObjectOfType<SceneController>();
        key = SetKey();

    }

    private void OnEnable()
    {
        sceneController.BeforeSceneUnload += Save;
        sceneController.AfterSceneLoad += Load;
    }
    private void OnDisable()
    {
        sceneController.BeforeSceneUnload -= Save;
        sceneController.AfterSceneLoad -= Load;
    }
    protected abstract string SetKey();
    protected abstract void Save();
    protected abstract void Load();
}
