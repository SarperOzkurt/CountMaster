using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickManTrigger
{
    private static StickManTrigger instance;

    private bool trigger;

    public static StickManTrigger getInstance()
    {
        if (instance == null)
            instance = new StickManTrigger();

        return instance;
    }

    public bool IsTrigger { get => trigger; set => trigger = value; }

}
