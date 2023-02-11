using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWeapon : MonoBehaviour
{
    public GameObject knife;
    public GameObject flash;
    public GameObject Axe;

    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            knife.SetActive(true);
            flash.SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.F))
        {
            knife.SetActive(false);
            flash.SetActive(true);
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            Axe.SetActive(true);
            knife.SetActive(false);
            flash.SetActive(false);
        }
    }
}
