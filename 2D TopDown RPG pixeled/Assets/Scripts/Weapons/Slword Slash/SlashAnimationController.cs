using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashAnimationController : MonoBehaviour
{
    SlashAnimationModel model;
    SlashAnimationView view;
    void Awake()
    {
        view = GetComponent<SlashAnimationView>();
        model = GetComponent<SlashAnimationModel>();
    }

    private void DestroySelf()
    {
        Destroy(this.gameObject);
    }

    void Update()
    {
        
    }
}
