using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetection : MonoBehaviour
{
    public KnifeAnim ka;
    public Health health;
    public float damage = 10f;
    public GameObject HitParticle;
    private void Start()
    {
         health = Object.FindObjectOfType<Health>();
    }
    private void Update()
    {
        health = Object.FindObjectOfType<Health>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy" && ka.isAttacking)
        {
            Instantiate(HitParticle, new Vector3(other.transform.position.x, transform.position.y, other.transform.position.z), other.transform.rotation);
            if(health != null)
            {

               health.TakeDamage(damage);
            }
        }
    } 
 
}
