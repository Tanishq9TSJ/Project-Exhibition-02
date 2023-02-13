using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective5 : MonoBehaviour
{
    public GameObject obje5;
    public GameObject obje6;
    private void Awake()
    {
        obje6.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ObjectivesComplete.occurrence.GetObjectivesDone(true, true, true, true, true, false, false, false, false, false);
            StartCoroutine(Objec2());

        }
    }

    IEnumerator Objec2()
    {
        Destroy(obje5, 3f);

        yield return new WaitForSeconds(4f);

        obje6.SetActive(true);
        this.gameObject.SetActive(false);
    }

}
