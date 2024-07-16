using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolderModel : MonoBehaviour
{

    public Vector3 GetRotation()
    {
        return transform.eulerAngles;
    }

    public void SetRotation(Vector3 rotation)
    {
        transform.rotation = Quaternion.Euler(rotation);
    }
}
