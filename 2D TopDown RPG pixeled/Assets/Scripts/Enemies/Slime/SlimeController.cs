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

    List<Vector2> path;


    private void Awake()
    {

        path = new List<Vector2>();

        enemyAI = GetComponent<EnemyAI>();

        enemyPathFinding = GetComponent<EnemyPathFinding>();

        model = GetComponent<SlimeModel>();

        view = GetComponent<SlimeView>();
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
        MoveToDestination();
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
}
