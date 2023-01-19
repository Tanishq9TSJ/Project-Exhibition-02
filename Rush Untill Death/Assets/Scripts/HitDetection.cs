using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetection : MonoBehaviour
{
    public KnifeAnim ka;
    public Target target;
    public float damage = 10f;
    public GameObject HitParticle;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy" && ka.isAttacking)
        {
            Instantiate(HitParticle, new Vector3(other.transform.position.x, transform.position.y, other.transform.position.z), other.transform.rotation);
            target.TakeDamage(damage);
        }
    } 
 
}
