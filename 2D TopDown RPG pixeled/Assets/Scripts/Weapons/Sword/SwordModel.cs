using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordModel : MonoBehaviour
{
    [SerializeField] Vector3 offsetOfSlashAnim;

    

    [SerializeField] float attackingDelay;

    public float GetAttackingDelay()
    {
        return attackingDelay;
    }
    public void SetAttackingDelay(float attackingDelay)
    {
        this.attackingDelay = attackingDelay;
    }
    
    
    
    private void Awake()
    {
        
    }

    void Start()
    {

    }

    

    public Vector3 GetOffsetOfSlashAnim(){
        return offsetOfSlashAnim;
    }

    public void SetOffsetOfSlashAnim(Vector3 offsetOfSlashAnim) {
    this.offsetOfSlashAnim = offsetOfSlashAnim;
    }

    

    public Vector3 GetRotation()
    {
        return transform.eulerAngles;
    }

    public void SetRotation(Vector3 rotation)
    {
        transform.rotation = Quaternion.Euler( rotation );

    }



    void Update()
    {
        
    }
}
