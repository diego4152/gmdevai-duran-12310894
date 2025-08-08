using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Player player;
    public GameObject catToSpawn;
    public GameObject monsterToSpawn;

    public GameObject goal;

    [Header("Lists")]
    public List<GameObject> catSpawnpoints = new List<GameObject>();

    public List<GameObject> enemySpawnpoints = new List<GameObject>();
    public List<GameObject> waypoints = new List<GameObject>();

    [Header("How Long Will This Game Last?")]
    [SerializeField] private int maxStages = 7;

    private int currentStages = 0;

    [SerializeField] private int stageToSpawnMonster;

    private void Awake()
    {
        Instance = this;

        goal.SetActive(false);
    }

    // Start is called before the first frame update
    private void Start()
    {
        SpawnCats();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void AdvanceStage()
    {
        currentStages++;

        if (currentStages == stageToSpawnMonster)
        {
            SpawnMonster();
        }
        else if (currentStages == maxStages)
        {
            goal.SetActive(true);
        }

        UIManager.Instance.UpdateGoalText(currentStages, maxStages);
    }

    public void AddMeToList(List<GameObject> list, GameObject thingToAdd)
    {
        list.Add(thingToAdd);
    }

    private void SpawnCats()
    {
        int randomIndex = 0;

        for (int i = 0; i < maxStages; i++)
        {
            randomIndex = Random.Range(0, catSpawnpoints.Count);

            GameObject catSpawn = (GameObject)Instantiate(catToSpawn, catSpawnpoints[randomIndex].transform.position, Quaternion.identity);

            catSpawnpoints.Remove(catSpawnpoints[randomIndex]);
        }
    }

    private void SpawnMonster()
    {
        int randomIndex = Random.Range(0, enemySpawnpoints.Count);

        GameObject monsterSpawn = (GameObject)Instantiate(monsterToSpawn, enemySpawnpoints[randomIndex].transform.position, Quaternion.identity);
    }
}