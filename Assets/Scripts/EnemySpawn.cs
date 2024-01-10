using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawn : MonoBehaviour
{
    public EnemyManager objectPoolManager;

    public float spawnInterval = 2f;//刷新时间
    public float spawnAreaWidth = 10f;//刷新区域宽
    public float spawnAreaHeight = 5f;//刷新区域高

    public Dictionary<string, float> enemysProbability = new Dictionary<string, float>();
    // 敌人生成比例


    private void Start()
    {
        foreach (var probability in objectPoolManager.enemyPool.EnemyRation)
        {
            enemysProbability.Add(probability.Key,probability.Value);
        }
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            float randomValue = Random.value;
            string enemyType=null;

            foreach (var pro in enemysProbability)
            {
                if (randomValue<pro.Value)
                {
                    enemyType = pro.Key;
                    break;
                }
                else
                {
                    randomValue -= pro.Value;
                }
            }


            SpawnEnemy(enemyType);
        }
    }

    private void SpawnEnemy(string enemyType)
    {
        float spawnX = Random.Range(-spawnAreaWidth / 2f, spawnAreaWidth / 2f);
        float spawnY = Random.Range(-spawnAreaHeight / 2f, spawnAreaHeight / 2f);

        GameObject enemy = objectPoolManager.GetEnemy(enemyType);

        if (enemy != null)
        {
            Debug.Log(enemy.name);
            enemy.transform.position = new Vector2(spawnX, spawnY);
            // 可以设置其他敌人属性
        }
    }

 
}