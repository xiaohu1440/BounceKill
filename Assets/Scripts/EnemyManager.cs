using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine.PlayerLoop;


public class EnemyManager : SerializedMonoBehaviour
{
    public EnemyPool enemyPool;
    [OdinSerialize]
    private Dictionary<string, GameObject> enemyList;

    [OdinSerialize]
    private Dictionary<string, List<GameObject>> enemyPools = new Dictionary<string, List<GameObject>>();
    // Start is called before the first frame update
    void Start()
    {
        enemyList = new Dictionary<string, GameObject>();
        enemyPool = Resources.Load<EnemyPool>("Data/敌人预制体管理");
        foreach (var enemy in enemyPool.Enemy)
        {
            enemyList.Add(enemy.Key,enemy.Value);
        }

        foreach (var enemyType in enemyList)
        {
            InitializePool(enemyType.Value,"方块敌人",15);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InitializePool(GameObject prefab, string poolKey, int poolSize)
    {
        List<GameObject> objectPool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab, transform);
            obj.SetActive(false);
            objectPool.Add(obj);
        }
        enemyPools.Add(poolKey,objectPool);
    }
    public GameObject GetEnemy(string poolKey)
    {
        if (enemyPools.ContainsKey(poolKey) && enemyPools[poolKey].Count > 0)
        {
            GameObject enemy = enemyPools[poolKey][0];
            enemyPools[poolKey].RemoveAt(0);
            enemy.SetActive(true);
            return enemy;
        }
        else
        {
            Debug.LogWarning("No available objects in the pool.");
            return null;
        }
    }
    public void ReturnEnemy(string poolKey, GameObject enemy)
    {
        enemy.SetActive(false);
        enemyPools[poolKey].Add(enemy);
    }
}
