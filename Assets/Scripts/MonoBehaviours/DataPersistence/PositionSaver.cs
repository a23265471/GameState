using System;
using UnityEngine;

public class PositionSaver : Saver
{
    public Transform transformToSave;

    protected override void Load()
    {
        Vector3 position = Vector3.zero;
        if (saveData.Load(key, ref position))
            transformToSave.position = position;    
    }

    protected override void Save()
    {
        saveData.Save(key, transformToSave.position);
    }

    protected override string SetKey()
    {
        return transformToSave.name + transformToSave.GetType().FullName + id;
    }
}
