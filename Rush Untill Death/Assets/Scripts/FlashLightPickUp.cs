using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightPickUp : MonoBehaviour
{
    public GameObject flashOnPlayer;
    public GameObject pickUpText;
    public GameObject knife;

    void Start()
    {
        flashOnPlayer.SetActive(false);
        pickUpText.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        pickUpText.SetActive(true);
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                this.gameObject.SetActive(false);
                flashOnPlayer.SetActive(true);
                pickUpText.SetActive(false);
                knife.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        pickUpText.SetActive(false);
    }
}


