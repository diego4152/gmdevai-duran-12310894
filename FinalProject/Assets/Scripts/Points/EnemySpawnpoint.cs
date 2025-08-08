using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnpoint : MonoBehaviour
{
    private void Start()
    {
        GameManager.Instance.AddMeToList(GameManager.Instance.enemySpawnpoints, this.gameObject);
    }
}