using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    List<GameObject> enemiesPool;

    public int EnemiesAllowedOnScreen=2;
    public int EnemySpawnRate=2;
    public int ActiveEnemiesCount;
    public float DoorHealth=100f;

    public DoorBehaviour door;
    public GameObject EnemyPrefab;
    [Range(5,50)]public int EnemyPoolSize = 5;

    private void Awake()
    {
        Instance = this; 
        enemiesPool = new List<GameObject>();
    }

    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i<EnemyPoolSize;i++)
        {
            enemiesPool.Add(Instantiate(EnemyPrefab));
        }

        Invoke(nameof(CheckAndRelaunchEnemy), EnemySpawnRate);
    }

    public void CheckAndRelaunchEnemy()
    {
        if(ActiveEnemiesCount< EnemiesAllowedOnScreen)
        {
            foreach(GameObject enemy in enemiesPool)
            {
                Enemy temp = enemy.GetComponent<Enemy>();
                if(!temp.Moving)
                {
                    temp.Launch();
                    break;
                }
            }

            Invoke(nameof(CheckAndRelaunchEnemy), EnemySpawnRate);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReduceDoorHealth(int reduceHP)
    {
        // Reduce Door Health
        DoorHealth -= reduceHP;
        door.UpdateAlpha();

        Invoke(nameof(CheckAndRelaunchEnemy), EnemySpawnRate);

    }
}
