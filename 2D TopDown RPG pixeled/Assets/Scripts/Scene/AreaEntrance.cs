using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEntrance : MonoBehaviour
{
    [SerializeField] string areaName;
    void Start()
    {
        Debug.Log(areaName);
        Debug.Log(SceneManagmentScript.Instance.GetEntrance());
        if (areaName == SceneManagmentScript.Instance.GetEntrance())
        {
            PlayerController.Instance.SetPos(transform.position);
            CameraController.Instance.SetCameraToPlayer();
            
            FadeScript.Instance.FadeToWhite();
        }
    }

    void Update()
    {
        
    }
}
