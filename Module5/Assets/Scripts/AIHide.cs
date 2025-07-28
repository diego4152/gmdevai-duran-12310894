using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIHide : AIControl
{
    // Update is called once per frame
    private void LateUpdate()
    {
        if (canSeeTarget())
        {
            Hide();
        }
        else
        {
            Wander();
        }
    }
}