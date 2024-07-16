using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    [SerializeField] float moveSpeed;

    Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void MoveTowards(Vector2 movement)
    {

        Vector2 delta2d = movement * moveSpeed * Time.fixedDeltaTime;

        rb.MovePosition(transform.position + new Vector3(delta2d.x, delta2d.y, 0));

    }

    public void SetRotation(Vector3 rotation)
    {
        transform.eulerAngles = rotation;
    }
    public Vector3 GetRotation()
    {
        return transform.eulerAngles;
    }

    public float GetMoveSpeed()
    {
        return this.moveSpeed;
    }
    public void SetMoveSpeed(float moveSpeed)
    {
        this.moveSpeed = moveSpeed;
    }

}
