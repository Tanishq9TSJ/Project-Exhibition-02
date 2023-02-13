using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objectives1 : MonoBehaviour
{
    public GameObject obje1;
    public GameObject obje2;
    private void Awake()
    {
        obje2.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            ObjectivesComplete.occurrence.GetObjectivesDone(true, false, false, false, false, false, false, false, false, false);
            StartCoroutine(Objec2());
           
        }
    }

    IEnumerator Objec2()
    {
        Destroy(obje1, 3f);

        yield return new WaitForSeconds(4f);

        obje2.SetActive(true);
        this.gameObject.SetActive(false);
    }
   
}
