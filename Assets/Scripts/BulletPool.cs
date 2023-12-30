using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public GameObject bulletPrefab;

    public int poolSize = 40;

    private List<GameObject> _bulletPool;
    
    // Start is called before the first frame update
    void Start()
    {
        _bulletPool = new List<GameObject>();
        for (int i=0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            _bulletPool.Add(bullet);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public GameObject GetBullet()
    {
        foreach (GameObject bullet in _bulletPool)
        {
            if (!bullet.activeInHierarchy)
            {
                bullet.SetActive(true);
                return bullet;
            }
        }

        return null; // Pool is empty
    }
}
