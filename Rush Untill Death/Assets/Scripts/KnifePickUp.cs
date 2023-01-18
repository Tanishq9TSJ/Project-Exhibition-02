using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifePickUp : MonoBehaviour
{
    public GameObject knifeOnPlayer;
    public GameObject pickUpText;
    
    void Start()
    {
        knifeOnPlayer.SetActive(false);
        pickUpText.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        pickUpText.SetActive(true);
        if(other.gameObject.tag == "Player")
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                this.gameObject.SetActive(false);
                knifeOnPlayer.SetActive(true);
                pickUpText.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        pickUpText.SetActive(false);
    }
}
