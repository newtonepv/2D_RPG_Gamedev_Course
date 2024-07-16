using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeModel : MonoBehaviour
{
    [SerializeField] float moveSpeed;

    [SerializeField] float health;

    Action ArrivedToPlace;

    Vector2 destination;

    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }



    void Start()
    {
        
    }

    void Update()
    {

    }


    public void MoveTowards(Vector2 place)
    {
        if(Vector2.Distance(place, rb.position) > 0.1)
        {

            Vector2 direction = (place - new Vector2(transform.position.x, transform.position.y)).normalized;

            Vector2 delta = direction * moveSpeed * Time.fixedDeltaTime;

            rb.MovePosition(rb.position + delta);

        }
        else
        {
            rb.MovePosition(place);
        }
    }

    public Vector2 GetRbPos()
    {
        return rb.position;
    }
    
    public void SetHealth(float health)
    {
        this.health = health;
    }
    public float GetHealth()
    {
        return health;
    }

}
