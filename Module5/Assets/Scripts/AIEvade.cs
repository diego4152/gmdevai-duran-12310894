using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIEvade : AIControl
{
    // Update is called once per frame
    private void LateUpdate()
    {
        if (isTargetInRange)
        {
            Evade();
        }
        else
        {
            Wander();
        }
    }
}