using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickUp : MonoBehaviour
{
    public GameObject keyText;
    public GameObject obje6;
    public GameObject obje7;

    void Start()
    {
        keyText.SetActive(false);

    }


    private void OnTriggerStay(Collider other)
    {
        keyText.SetActive(true);
        if(other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {   
                ObjectivesComplete.occurrence.GetObjectivesDone(true, true, true, true, true, true, false, false, false, false);
                StartCoroutine(KeyOP());
            }
        }
    }
    IEnumerator KeyOP()
    {
        Destroy(obje6, 3f);
        yield return new WaitForSeconds(4f);
        keyText.SetActive(false);
        obje7.SetActive(true);
        this.gameObject.SetActive(false);
    }
}

