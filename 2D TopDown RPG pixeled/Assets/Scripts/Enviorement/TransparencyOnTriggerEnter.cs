using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparencyOnTriggerEnter : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    [Range(0,1)] 
    [SerializeField] float transparencyAmount = 0.8f;
    [SerializeField] float fasdeTime = 0.4f;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
