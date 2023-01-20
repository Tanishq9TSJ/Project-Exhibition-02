using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorForce : MonoBehaviour
{
    public float forceOP;
    public Rigidbody rb;
    public Transform player;
    public GameObject textOp;
    public BoxCollider b;
    public GameObject solidCollider;
    private void Start()
    {
        textOp.SetActive(false);
    }
    public void OnTriggerStay(Collider other)
    {
        textOp.SetActive(true);
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                rb.AddForce(transform.forward * forceOP, ForceMode.Acceleration);
                rb.useGravity = true;
                b.isTrigger = false;
                b.size = new Vector3(1f,1f, 1f);
                b.center = new Vector3(0, 0, 0);
                Destroy(solidCollider);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        textOp.SetActive(false);

    }

}
