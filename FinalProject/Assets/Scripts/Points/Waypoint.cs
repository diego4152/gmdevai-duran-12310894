using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    private void Start()
    {
        GameManager.Instance.AddMeToList(GameManager.Instance.waypoints, this.gameObject);
    }
}