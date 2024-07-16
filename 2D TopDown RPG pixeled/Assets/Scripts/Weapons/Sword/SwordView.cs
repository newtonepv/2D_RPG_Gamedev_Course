using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordView : MonoBehaviour
{
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        
    }
    public void AttackAnim()
    {
        animator.SetTrigger("Attack");
    }
    void Update()
    {
        
    }
}
