using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

[CreateAssetMenu(fileName = "敌人预制体管理",menuName = "预制体管理/敌人")]
public class EnemyPool :SerializedScriptableObject
{
    public Dictionary<string,GameObject> Enemy;
    public Dictionary<string, float> EnemyRation = new Dictionary<string, float>();
}
