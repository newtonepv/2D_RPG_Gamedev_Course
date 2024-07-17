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
        this.entrance = entrance;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
