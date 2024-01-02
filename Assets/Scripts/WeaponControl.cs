using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using UnityEngine;

public class WeaponControl : MonoBehaviour
{
    public LayerMask bulletMask;
    public Collider2D[] colliders;
    public Transform player;
    private float angle;

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
           this.gameObject.GetComponent<MMF_Player>().PlayFeedbacks();
           if (isTrigger)
           {
               foreach (Collider2D bullet in colliders)
               {
                   ReflectBullet(bullet.gameObject);
                   bullet.gameObject.GetComponent<MMF_Player>().PlayFeedbacks();
               }
           }
       }
    }
    public bool IsBulletInRange()
    {
        Vector2 center = transform.position; // 盾牌的中心位置
        Vector2 size = new Vector2(1.2f, 0.4f); // 盾牌的大小
        angle = gameObject.GetComponentInParent<Transform>().eulerAngles.z;
        
        
        colliders = Physics2D.OverlapBoxAll(center, size, angle, bulletMask);
        
        return colliders.Length > 0;
    }

    private void OnDrawGizmos()
    {
        Vector2 size = new Vector2(1.2f, 0.4f); // 盾牌的大小
        Gizmos.color=Color.blue;
        DrawOverlapBoxBounds(transform.position, size, angle, Color.green);
        //Gizmos.DrawWireCube(transform.position,size); 
        
    }
    private void DrawOverlapBoxBounds(Vector2 center, Vector2 size, float angle, Color color)
    {
        Matrix4x4 matrixBackup = Gizmos.matrix;
        Gizmos.matrix = Matrix4x4.TRS(center, Quaternion.Euler(0, 0, angle), Vector3.one);

        Gizmos.color = color;
        Gizmos.DrawWireCube(Vector3.zero, size);

        Gizmos.matrix = matrixBackup;
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
            
            Vector2 playerToBullet = (bullet.transform.position - player.position).normalized;

            // 如果反射方向朝向角色方向，则调整反射方向
            if (Vector2.Dot(reflectedDirection, playerToBullet) < 0)
            {
                reflectedDirection = Quaternion.Euler(0, 0, 180) * reflectedDirection;
            }
            return reflectedDirection.normalized;
        }

        // 如果子弹没有Rigidbody2D，返回默认方向
        return Vector2.zero;
    }
}
