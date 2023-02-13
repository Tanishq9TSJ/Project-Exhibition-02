using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifePickUp : MonoBehaviour
{
    public GameObject knifeOnPlayer;
    public GameObject pickUpText;
    public GameObject flash;
    public GameObject obje2;
    public GameObject obje3;
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
                //this.gameObject.SetActive(false);
                
                knifeOnPlayer.SetActive(true);
                pickUpText.SetActive(false);
                flash.SetActive(false);
                ObjectivesComplete.occurrence.GetObjectivesDone(true, true, false, false, false, false, false, false, false, false);
                StartCoroutine(Objec3());
            }
        }
    }

    IEnumerator Objec3()
    {
        Destroy(obje2, 3f);
        yield return new WaitForSeconds(4f);
        pickUpText.SetActive(false);
        obje3.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
