using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    [SerializeField] GameObject spriteHolder;
    [SerializeField] GameObject particles;
    ParticleSystem particlesSystem;
    [SerializeField] int timesShaken;
    [SerializeField] float timeInEachShake;
    [SerializeField] float radiusForShake;
    Vector3 originalPosition;
    Coroutine shakeCoroutine;
    private void Awake()
    {
        particlesSystem = particles.GetComponent<ParticleSystem>();
    }
    void Start()
    {
        originalPosition = spriteHolder.transform.position;
    }
    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<SwordController>() != null)
        {
            Debug.Log("pepe");
            if (shakeCoroutine != null)
            {
                StopCoroutine(shakeCoroutine);
            }
            shakeCoroutine = StartCoroutine(ShakeCoroutine());
        }
    }*/
    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealing damageDealing = collision.gameObject.GetComponent<DamageDealing>();
        Debug.Log("collision");
        if (damageDealing != null && damageDealing.GetIsDealingDamage())
        {

            Debug.Log("w damage");
            Die();

            /*Debug.Log("pepe");
            if (shakeCoroutine != null)
            {
                StopCoroutine(shakeCoroutine);
            }
            shakeCoroutine = StartCoroutine(ShakeCoroutine());*/
        }

    }

    private void Die()
    {
        GameObject particlesInstance =Instantiate(particles,transform.position,Quaternion.identity);
        Destroy(particlesInstance, particlesSystem.main.duration);
        Destroy(this.gameObject);

    }

    IEnumerator ShakeCoroutine()
    {
        for (int i = 0; i < timesShaken; i++)
        {

            float x = Random.Range(-1f, 1f) * radiusForShake;
            float y = Random.Range(-1f, 1f) * radiusForShake;

            spriteHolder.transform.localPosition = new Vector3(originalPosition.x + x, originalPosition.y + y, originalPosition.z);

            yield return new WaitForSeconds(timeInEachShake);
            spriteHolder.transform.position = new Vector3(originalPosition.x, originalPosition.y,0);
            yield return new WaitForSeconds(timeInEachShake);
        }
    }
    void Update()
    {
        
    }
}
