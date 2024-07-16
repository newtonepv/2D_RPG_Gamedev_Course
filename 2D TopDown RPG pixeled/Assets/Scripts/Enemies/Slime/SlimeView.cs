using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeView : MonoBehaviour
{ 
    SpriteRenderer spriteRenderer;
    [SerializeField] Material whiteMaterial;
    [SerializeField] Material normalMaterial;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }
    void Start()
    {
        
    }
    public void SetMaterialToWhite()
    {
        spriteRenderer.material = whiteMaterial;
    }
    public void SetMaterialToDefoult()
    {
        spriteRenderer.material = normalMaterial;
    }
    void Update()
    {
        
    }
}
