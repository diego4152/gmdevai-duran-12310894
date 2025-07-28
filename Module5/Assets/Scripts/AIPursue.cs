using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPursue : AIControl
{
    // Update is called once per frame
    private void LateUpdate()
    {
        if (isTargetInRange)
        {
            Pursue();
        }
        else
        {
            Wander();
        }
    }
}