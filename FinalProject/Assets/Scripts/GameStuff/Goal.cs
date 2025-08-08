using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>() != null)
        {
            Cursor.lockState = CursorLockMode.None;
            LevelManager.Instance.GoToLevel(2);
        }
    }
}