using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolderController : MonoBehaviour
{
    WeaponHolderModel model;
    WeaponHolderController controller;

    private void Awake()
    {
        controller = GetComponent<WeaponHolderController>();
        model = GetComponent<WeaponHolderModel>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateRotationTowardsMouse();
    }

    private void UpdateRotationTowardsMouse()
    {
        Vector3 screenMousePos = Input.mousePosition;

        Vector3 screenPlayerPos = Camera.main.WorldToScreenPoint(transform.position);

        Vector3 relativeScreenMousPos = screenMousePos - screenPlayerPos;

        float angle = Mathf.Atan2(relativeScreenMousPos.y, relativeScreenMousPos.x) * Mathf.Rad2Deg;

        /*if (Mathf.Cos(angle) < 0) {
            angle = 180 - angle;
        }*/

        Vector3 actualRot = model.GetRotation();

        Vector3 newRot = new Vector3(actualRot.x, actualRot.y, angle);

        model.SetRotation(newRot);
    }

}
