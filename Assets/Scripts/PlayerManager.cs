using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private static PlayerManager instance;
    [HideInInspector]
    public PlayerData attributes;
    private PlayerManager(){}
    public MMF_Player M_Player;
    
    public static PlayerManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new PlayerManager();
            }
            return instance;
        }
    }
    void Start()
    {
        attributes = GetComponent<PlayerData>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag=="Bullet")
        {
            Debug.Log("受伤");
            attributes.hp--;
            M_Player.PlayFeedbacks();
        }
    }


}
