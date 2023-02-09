using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 30f;
    public Animator anim;
    public GameObject Enemy;


    private void Start()
    {
        Enemy = GameObject.FindGameObjectWithTag("Enemy");
       
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            StartCoroutine(DeathCoroutine());
        }
        
    }
 
    IEnumerator DeathCoroutine()
    {
        anim.SetTrigger("Die");

        yield return new WaitForSeconds(3f);

        Destroy(Enemy); 
      
    }

}
