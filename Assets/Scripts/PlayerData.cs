using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public PlayerAttributes attributes;
    [HideInInspector]
    public float speed;
    [HideInInspector]
    public float rollDistance;
    [HideInInspector]
    public int hp;
    [HideInInspector]
    public float invincibleTime;
    void Start()
    {
        speed = attributes.playerSpeed;
        rollDistance = attributes.playerRollDistance;
        hp = attributes.playerHp;
        invincibleTime = attributes.playerInvincibleTime;
    }


}
