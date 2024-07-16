using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordModel : MonoBehaviour
{
    [SerializeField] Vector3 offsetOfSlashAnim;

    DamageDealing damageDealing;
    private void Awake()
    {
        damageDealing = GetComponent<DamageDealing>();
    }

    void Start()
    {

    }

    public bool GetDealingDamageAvaliable()=> damageDealing.GetDealingDamageAvaliable();
    public void SetDealingDamageAvaliable(bool value) {damageDealing.SetDealingDamageAvaliable(value);}

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
