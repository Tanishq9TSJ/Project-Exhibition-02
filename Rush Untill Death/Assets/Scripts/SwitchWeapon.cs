using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWeapon : MonoBehaviour
{
    public GameObject knife;
    public GameObject flash;

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
    }
}
