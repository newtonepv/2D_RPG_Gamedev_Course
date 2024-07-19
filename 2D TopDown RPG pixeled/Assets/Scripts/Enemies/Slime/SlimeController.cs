using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : MonoBehaviour
{

    SlimeModel model;
    SlimeView view;

    EnemyAI enemyAI;
    EnemyPathFinding enemyPathFinding;

    Vector2 destination;
    Coroutine gettingKnockedBack;
    Coroutine gettingFlashed;

    List<Vector2> path;


    private void Awake()
    {

        path = new List<Vector2>();

        enemyAI = GetComponent<EnemyAI>();

        enemyPathFinding = GetComponent<EnemyPathFinding>();

        model = GetComponent<SlimeModel>();

        view = GetComponent<SlimeView>();

        model.SetBeingKnockedBack(false);
    }
    void Start()
    {
    }
    
    public void SetPath(List<Vector2> path)
    {
        this.path = path;

        SetDestination(path[0]);
    }

    void SetDestination(Vector2 destination)
    {
        this.destination = destination;

    }
    void FixedUpdate()
    {
        if(model.GetBeingKnockedBack() == false)
        {
            MoveToDestination();
        }
    }

    private void MoveToDestination()
    {
        if (path.Count != 0)
        {

            model.MoveTowards(destination);

            if (model.GetRbPos() == destination)
            {
                path.RemoveAt(0);

                if (path.Count != 0)
                {
                    SetDestination(path[0]);
                }
                else
                {
                    enemyAI.SetWantsANewPath(true);
                }
            }
        }
        
    }

    void TakeDamage(float damage)
    {
        float health = model.GetHealth();

        if (health > damage)
        {
            model.SetHealth(health - damage);
        }
        else
        {
            Die();
        }
    }
    void Die()
    {
         GameObject particleSys = Instantiate(model.GetDeathParticles(), model.GetPosition(),Quaternion.identity);
         Destroy(particleSys, particleSys.GetComponent<ParticleSystem>().main.duration);
         Destroy(this.gameObject);
    }
    

    public void StartKnockBack(float knockBackDuration, float knockBackForce, Vector3 impactPos, float damage)
    {
        if (gettingFlashed != null)
        {
            StopCoroutine(gettingFlashed);
            gettingFlashed = StartCoroutine(GetFlashed(knockBackForce));
        }
        else
        {
            gettingFlashed = StartCoroutine(GetFlashed(knockBackForce));
        }
        
        if (gettingKnockedBack != null)
        {
            StopCoroutine(gettingKnockedBack);
            gettingKnockedBack = StartCoroutine(GetKnockBack(knockBackDuration, knockBackForce, impactPos, damage));
        }
        else
        {
            gettingKnockedBack = StartCoroutine(GetKnockBack(knockBackDuration, knockBackForce, impactPos, damage));
        }

    }

    IEnumerator GetFlashed(float knockBackForce)
    {
        view.SetMaterialToWhite();
        yield return new WaitForSeconds(knockBackForce/model.GetMass()/12f);
        view.SetMaterialToDefoult();
    }

    IEnumerator GetKnockBack(float knockBackDuration, float knockBackForce, Vector3 impactPos, float damage)
    {
        model.SetBeingKnockedBack(true);

        Vector2 pos = model.GetRbPos();

        Vector2 knockDirection = (pos - new Vector2(impactPos.x, impactPos.y)).normalized;

        model.AddImpulseForceToRb(knockDirection * knockBackForce/model.GetMass());

        yield return new WaitForSeconds(knockBackDuration / model.GetMass());

        model.SetRbAngularVelocity(0f);

        model.SetRbVelocity(Vector2.zero);

        model.SetBeingKnockedBack(false);

        TakeDamage(damage);


    }
}
