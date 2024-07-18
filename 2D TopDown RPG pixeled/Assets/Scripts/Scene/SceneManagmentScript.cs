using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManagmentScript : Singleton<SceneManagmentScript>
{
    string entrance;

    public string GetEntrance()
    {
        return entrance;
    }
    public void SetEntrance(string entrance)
    {
        Debug.Log("Setted entrance to "+entrance);
        this.entrance = entrance;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
