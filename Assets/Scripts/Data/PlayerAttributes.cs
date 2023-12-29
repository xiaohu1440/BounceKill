using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "角色属性",menuName = "角色/角色属性",order = 1)]
public class PlayerAttributes : ScriptableObject
{
    public float playerSpeed;
    public float playerRollDistance;
    public int playerHp; 
    public float playerInvincibleTime;  
}
