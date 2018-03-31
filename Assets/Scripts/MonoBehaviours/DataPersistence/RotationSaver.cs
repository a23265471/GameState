using System;
using UnityEngine;

public class RotationSaver : Saver
{
    public Transform rotationToSave;
    protected override void Load()
    {

        Quaternion rotation = Quaternion.identity;
        if (saveData.Load(key, ref rotation))
            rotationToSave.rotation = rotation;

    }

    protected override void Save()
    {
        saveData.Save(key, rotationToSave.rotation);
    }

    protected override string SetKey()
    {
        return rotationToSave.name + rotationToSave.GetType().FullName + id;
    }
}
