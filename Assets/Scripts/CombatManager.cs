 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CombatManager : MonoBehaviour
{
    public int numOfEnemies = 0;
    public int maxNumOfEnemies;
    public int currentScene;
    public int maxSceneCount;
    [SerializeField] private GameObject enemyPrefab;

    private void Start()
    {
        if (maxSceneCount == null)
        {
            Debug.Log("you need to set maxSceneCount via Unity Editor");
        }
    }

    private void FixedUpdate()
    {
        SpawnEnemies();
    }

    void SpawnEnemies()
    {
        if (numOfEnemies < maxNumOfEnemies)
        {
            Instantiate(enemyPrefab);
            numOfEnemies++;
        }
    }

    

    
}
