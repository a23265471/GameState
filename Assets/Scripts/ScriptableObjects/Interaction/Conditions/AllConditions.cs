using UnityEngine;
using System;
// This script works as a singleton asset.  That means that
// it is globally accessible through a static instance
// reference.  
[CreateAssetMenu]
public class AllConditions : ResettableScriptableObject
{
    public Condition[] conditions;
    private static AllConditions instance;
    private const string loadPath = "AllConditions";
    public static AllConditions Instance
    {
        get
        {
            if (!instance)
                instance = FindObjectOfType<AllConditions>();
            if (!instance)
                instance = Resources.Load<AllConditions>(loadPath);
            if (!instance)
                Debug.LogError("AllConditions has not been created yet!");
            return instance;
        }
        set
        {
            instance = value;
        }
    }

    public override void Reset()
    {
        if (conditions == null)
            return;
        for (int i = 0; i < conditions.Length; i++)
        {
            conditions[i].satisfied = false;
        }
    }

    public static bool CheckCondition(Condition requiredCondition)
    {
        Condition[] allConditions = Instance.conditions;
        Condition globalCondition = null;
        if (allConditions != null && allConditions[0] != null)
        {
            for (int i = 0; i < allConditions.Length; i++)
            {
                if (allConditions[i].description == requiredCondition.description)
                    globalCondition = allConditions[i];
            }
        }
        if (globalCondition == null)
            return false;
        return globalCondition.satisfied == requiredCondition.satisfied;
    }

    public static Condition GetCondition(Condition.ConditionName conditionName)
    {
        return Array.Find(Instance.conditions, data => data.description == conditionName); 
    }
}
