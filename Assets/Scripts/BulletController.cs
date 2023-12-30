using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Wall")||other.CompareTag("Player"))
        {
            gameObject.GetComponent<TrailRenderer>().enabled = false;
            gameObject.SetActive(false); // Deactivate the bullet when it hits the wall
        }
    }
}