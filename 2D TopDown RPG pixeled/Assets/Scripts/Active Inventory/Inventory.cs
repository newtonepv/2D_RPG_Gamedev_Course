using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    int activeSlot = 0;
    PlayerInputActions inputActions;
    private void Awake()
    {
        inputActions = new PlayerInputActions();
    }
    private void OnEnable()
    {
        inputActions.Enable();
    }
    void Start()
    {
        inputActions.Inventory.Keyboard.performed += ctx => OnNumberPressed((int)ctx.ReadValue<float>());
        ToggleActiveSlot(1);
    }
    void OnNumberPressed(int number)
    {
        ToggleActiveSlot(number);
    }
    void ToggleActiveSlot(int number)
    {
        ToggleActiveHighlight(number);
    }
    void ToggleActiveHighlight(int number)
    {
        activeSlot = number-1;

        foreach (Transform inventorySlot in this.transform) {

            inventorySlot.GetChild(0).gameObject.SetActive(false);
        }

        this.transform.GetChild(activeSlot).GetChild(0).gameObject.SetActive(true);

        if (this.transform.GetChild(activeSlot).GetChild(1).gameObject.activeInHierarchy)
        {

            ChangeHoldingWeapon();
        }
    }

    void ChangeHoldingWeapon()
    {
        if (ActiveWeapon.Instance.GetCurrentActiveWeapon())
        {
            Destroy(ActiveWeapon.Instance.GetCurrentActiveWeapon().gameObject);
        }

        GameObject activeWeapon = this.transform.GetChild(activeSlot).GetComponent<InventorySlot>().GetWeaponInfo().weeaponPrefab;

        GameObject activeWeaponInstance = Instantiate(activeWeapon, ActiveWeapon.Instance.transform.position,Quaternion.identity);
        ActiveWeapon.Instance.transform.rotation = Quaternion.Euler(0,0,0);
        activeWeaponInstance.transform.parent = ActiveWeapon.Instance.transform;

        if (activeSlot == 0)
        {
            ActiveWeapon.Instance.SetCurrentActiveWeapon(activeWeaponInstance.GetComponent<SwordController>()) ;
        }
        else if (activeSlot == 1)
        {
            ActiveWeapon.Instance.SetCurrentActiveWeapon(activeWeaponInstance.GetComponent<Bow>()) ;
        }
        else if (activeSlot == 2)
        {
            ActiveWeapon.Instance.SetCurrentActiveWeapon(activeWeaponInstance.GetComponent<Staff>()) ;
        }
    }

    void Update()
    {
        
    }
}
