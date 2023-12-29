using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponR : MonoBehaviour
{
    public Transform parentPosition;

    public float distanceFromParent;

    public float angleSpeed;
    // Start is called before the first frame update
    void Start()
    {
        if (parentPosition != null)
        {
            distanceFromParent = Vector2.Distance(transform.position, parentPosition.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePositon = GetMousePosition();
        Vector2 mouseParent = mousePositon - (Vector2)parentPosition.position;
        transform.position = (Vector2)parentPosition.position + mouseParent.normalized * distanceFromParent;
        float angle = Mathf.Atan2(mouseParent.y, mouseParent.x) * Mathf.Rad2Deg;
        transform.rotation=Quaternion.Euler(0,0,angle);

    }
    Vector2 GetMousePosition()
    {
        // 获取鼠标在世界空间中的位置
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
