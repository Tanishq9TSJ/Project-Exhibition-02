using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI2 : MonoBehaviour
{
    private PlayerController cont;
    private SphereCollider sphereCollider;
    public float walkEnemyPerceptionRadius = 2f;
    public float sprintEnemyPerceptionRadius = 5f;

    void Start()
    {
        cont = GetComponent<PlayerController>();
        sphereCollider = GetComponent<SphereCollider>();
    }

    void Update()
    {
        if(cont.speed == 7f)
        {
            sphereCollider.radius = sprintEnemyPerceptionRadius;
        }
        else
        {
            sphereCollider.radius = walkEnemyPerceptionRadius;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyAI>().OnAware();
        }
    }
}
