using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Projectile : MonoBehaviour
{
    [SerializeField] float mooveSpeed = 22f;
    [SerializeField] GameObject deathEffect;
    float range;
    public void SetRange(float range)
    {
        this.range = range;
    }
    Vector3 startPos;
    void Start()
    {
        startPos = transform.position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.isTrigger)
        {
            GameObject deathEffectInstance = Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(deathEffectInstance, deathEffectInstance.GetComponent<ParticleSystem>().main.duration);
            Destroy(gameObject);
        }
    }
    private void Die()
    {
        GameObject deathEffectInstance = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(deathEffectInstance, deathEffectInstance.GetComponent<ParticleSystem>().main.duration);
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
    void Update()
    {
        Move();
        if (Vector3.Distance(transform.position, startPos) > range)
        {
            Die();
        }
    }
    void Move()
    {
        transform.Translate(Vector3.right * mooveSpeed*Time.deltaTime);
    }
}
