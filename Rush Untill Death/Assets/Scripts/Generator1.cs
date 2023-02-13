using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator1 : MonoBehaviour
{
    private BoxCollider boxcollider;
    public GameObject switchText;
    public GameObject obje3;
    public GameObject obje4;
    void Start()
    {
        switchText.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        switchText.SetActive(true);
        if(other.gameObject.tag == "Player")
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                ObjectivesComplete.occurrence.GetObjectivesDone(true, true, true, false, false, false, false, false, false, false);

                StartCoroutine(objec4());
            }
        }
    }

    IEnumerator objec4()
    {
        Destroy(obje3, 3f);
        yield return new WaitForSeconds(4f);
        switchText.SetActive(false);
        obje4.SetActive(true);
        // Destroy(this.gameObject);
        Destroy(boxcollider);

    }
}
