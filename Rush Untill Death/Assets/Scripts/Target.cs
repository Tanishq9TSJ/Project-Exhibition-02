using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    public Animator anim;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            // Die();
            StartCoroutine(DeathCoroutine());

        }
    }

    /*void Die()
    {   
       this.gameObject.SetActive(false);
    }*/

    IEnumerator DeathCoroutine()
    {
        anim.SetTrigger("Die");

        yield return new WaitForSeconds(3f);
        this.gameObject.SetActive(false);

    }

}
