using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI3 : MonoBehaviour
{
    public PlayerController PCS;
    public float Pdamage = 10f;
    void Start()
    {
        PCS = GetComponent<PlayerController>();
    }


    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider o)
    {
        if(o.gameObject.tag == "Player")
        {
            if(PCS != null)
            {
                PCS.PlayerDamage(Pdamage);
            }
        }
    }
}
