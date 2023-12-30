using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    // 公有变量，用于设置子弹发射的间隔时间
    public float fireInterval = 2f;

    // 私有变量，用于存储上一次发射子弹的时间
    private float lastFireTime;

    // 引用对象池的变量
    private BulletPool bulletPool;
    private Transform player;
    public float speed;

    // 在游戏对象（敌人）启用时调用的方法
    void Start()
    {
        // 查找场景中的 ObjectPool 类的实例，通常通过在场景中放置一个 ObjectPool 对象或通过其他方式进行引用
        bulletPool = FindObjectOfType<BulletPool>();

        // 初始化上一次发射子弹的时间为当前时间
        lastFireTime = Time.time;
    }

    // 在每一帧更新时调用的方法
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").gameObject.transform;
        // 如果距离上一次发射子弹的时间超过了发射间隔时间
        if (Time.time - lastFireTime >= fireInterval)
        {
            // 调用发射子弹的方法
            Shoot();

            // 更新上一次发射子弹的时间为当前时间
            lastFireTime = Time.time;
        }
    }

    // 发射子弹的方法
    void Shoot()
    {
        // 从对象池中获取子弹对象
        GameObject bullet = bulletPool.GetBullet();

        // 如果成功获取到子弹对象
        if (bullet != null)
        {
            // 设置子弹的位置为敌人的位置

            bullet.transform.position = transform.position;
                
            
            // 如果子弹有刚体组件，你可能还需要为其添加速度，这样它才会朝着旋转方向移动
            // bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
            Vector2 direction = (player.position - transform.position).normalized;
            bullet.GetComponent<Rigidbody2D>().velocity = direction * speed;
            bullet.GetComponent<TrailRenderer>().enabled = true;
        }
    }
}