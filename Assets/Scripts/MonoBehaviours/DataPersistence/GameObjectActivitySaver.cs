using System;
using UnityEngine;

public class GameObjectActivitySaver : Saver
{
    public GameObject gameObjectToSave;
    protected override void Load()
    {
        bool activeState = false;
        if (saveData.Load(key, ref activeState))
            gameObjectToSave.SetActive(activeState);
    }

    protected override void Save()
    {
        saveData.Save(key, gameObjectToSave.activeSelf);
    }

    protected override string SetKey()
    {
        return gameObjectToSave.name + gameObjectToSave.GetType().FullName + id;
    }
}
