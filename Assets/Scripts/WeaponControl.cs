using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControl : MonoBehaviour
{
    public LayerMask bulletMask;
    public Collider2D[] colliders;

    private bool isTrigger;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       isTrigger =IsBulletInRange();
       if (Input.GetMouseButtonDown(0))
       {
           if (isTrigger)
           {
               foreach (Collider2D bullet in colliders)
               {
                   ReflectBullet(bullet.gameObject);
               }
           }
       }
    }
    public bool IsBulletInRange()
    {
        Vector2 center = transform.position; // 盾牌的中心位置
        Vector2 size = new Vector2(0.4f, 1.2f); // 盾牌的大小
        colliders = Physics2D.OverlapBoxAll(center, size, 0, bulletMask);
        return colliders.Length > 0;
    }

    private void OnDrawGizmos()
    {
        Vector2 size = new Vector2(0.4f, 1.2f); // 盾牌的大小
        Gizmos.color=Color.blue;
        Gizmos.DrawWireCube(transform.position,size); 
        
    }
    
    void ReflectBullet(GameObject bullet)
    {
        Vector2 reflectDirection = CalculateReflectDirection(bullet);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
    
        if (bulletRb != null)
        {
            // 根据计算的方向反射子弹的速度
            bulletRb.velocity = reflectDirection.normalized * bulletRb.velocity.magnitude*3;
        
            // 或者，如果你想设置子弹的位置而不是速度
            // bulletRb.position = (Vector2)bulletRb.position + reflectDirection.normalized * someDistance;
        }
    }
    Vector2 CalculateReflectDirection(GameObject bullet)
    {
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();

        if (bulletRb != null)
        {
            // 计算碰撞法线方向
            Vector2 collisionNormal = (bullet.transform.position - transform.position).normalized;

            // 计算子弹的入射方向
            Vector2 incomingDirection = bulletRb.velocity.normalized;

            // 使用Vector2.Reflect计算反射方向
            Vector2 reflectedDirection = Vector2.Reflect(incomingDirection, collisionNormal);

            return reflectedDirection.normalized;
        }

        // 如果子弹没有Rigidbody2D，返回默认方向
        return Vector2.zero;
    }
}
