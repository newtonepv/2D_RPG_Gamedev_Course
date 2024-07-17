using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemyAI : MonoBehaviour
{
    EnemyPathFinding enemyPathFinding;
    SlimeController slimeController;

    [SerializeField] float wanderingRange;

    enum State
    {
        Roaming
    }

    State state;

    bool wantsANewPath;

    private void Awake()
    {
        slimeController = GetComponent<SlimeController>();

        wantsANewPath = false;

        state = State.Roaming;

        enemyPathFinding = GetComponent<EnemyPathFinding>();
        
        StartCoroutine(StartRoamingOrNot());
    }
    void Start()
    {
    }

    bool GetWantsANewPath()
    {
        return wantsANewPath;
    }

    public void SetWantsANewPath(bool wantsANewPath)
    {
        this.wantsANewPath = wantsANewPath;
    }

    IEnumerator StartRoamingOrNot()
    {
        while(state == State.Roaming)
        {

            SetWantsANewPath(false);

            Vector2 newRoamingPos = GetNextRoamingPos();

            enemyPathFinding.SetPlaceToBe(newRoamingPos);

            slimeController.SetPath(enemyPathFinding.GetPath());


            yield return new WaitUntil(()=>wantsANewPath);



        }
    }

    Vector2 GetNextRoamingPos()
    {
        return ( new Vector2(Random.Range(-1,1)* wanderingRange, Random.Range(-1,1)* wanderingRange) ).normalized;
    }


    void Update()
    {
        
    }
}
