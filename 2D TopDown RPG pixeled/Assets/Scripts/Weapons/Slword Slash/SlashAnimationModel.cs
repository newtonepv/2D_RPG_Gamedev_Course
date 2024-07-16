using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashAnimationModel : MonoBehaviour
{
    [SerializeField] float lifeTime;

    public float GetLifeTime() { 
    return lifeTime;
    }

    public void SetXRotation(float xRot)
    {
        Vector3 currentRotation = transform.eulerAngles;

        currentRotation.x = xRot;

        transform.eulerAngles = currentRotation;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
