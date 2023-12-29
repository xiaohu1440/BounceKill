using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform parentObject;

    public float rotationSpeed = 5f;
    public float stopRotationThreshold = 1f; 

    private Vector3 mousePosition;
    private bool shouldRotate = true;

    private float angle;
    // Start is called before the first frame update
    void Start()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        Vector3 directionToMouse = mousePosition - parentObject.position;
        angle = Mathf.Atan2(directionToMouse.y, directionToMouse.x) * Mathf.Rad2Deg;
        angle = Mathf.Repeat(angle, 360f);
        if (Mathf.Abs(angle) > stopRotationThreshold)
            shouldRotate = true;
        if (!shouldRotate)
            return;
        transform.RotateAround(parentObject.position,Vector3.forward,angle*rotationSpeed*Time.deltaTime);
        if (Mathf.Abs(angle) < stopRotationThreshold)
        {
            shouldRotate = false;
        }
    }
}
