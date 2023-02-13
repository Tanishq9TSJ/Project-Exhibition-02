using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective4 : MonoBehaviour
{
    public GameObject obje4;
    public GameObject obje5;
    private void Awake()
    {
        obje5.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ObjectivesComplete.occurrence.GetObjectivesDone(true, true, true, true, false, false, false, false, false, false);
            StartCoroutine(Objec2());

        }
    }

    IEnumerator Objec2()
    {
        Destroy(obje4, 3f);

        yield return new WaitForSeconds(4f);

        obje5.SetActive(true);
        this.gameObject.SetActive(false);
    }

}

