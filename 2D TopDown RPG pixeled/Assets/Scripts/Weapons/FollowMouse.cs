using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
    {
        FaceMouse();
    }
    void FaceMouse()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector2 direction = mousePos - transform.position;
        Debug.Log(direction.ToString());
        transform.right = direction; 
    }
}
