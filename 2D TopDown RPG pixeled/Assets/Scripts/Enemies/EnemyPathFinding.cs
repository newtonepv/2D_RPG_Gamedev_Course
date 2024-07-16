using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathFinding : MonoBehaviour
{
    Vector2 placeToBe;

    List<Vector2> path = new List<Vector2>();

    public void SetPlaceToBe(Vector2 placeToBe)
    {
        this.placeToBe = placeToBe;
        UpdatePath(placeToBe);
    }

    private void UpdatePath(Vector2 placeToBe)
    {
        path.Clear();

        path.Add(placeToBe);

        //Debug.Log(path[0].ToString());
    }

    public List<Vector2> GetPath()
    {
        return path;
    }

    private void Awake()
    {

    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
