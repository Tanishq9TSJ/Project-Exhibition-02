using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
    public GameObject Enemy;
    public Target ts;
    //public Animator anim;
    float amount;
    private void Update()
    {
       
        ts.health -= amount;
        if (ts.health <=0f)
        {
            StartCoroutine(DeathCoroutine());
        }
    }

    IEnumerator DeathCoroutine()
    {
        if(gameObject.name == "Zombie(Clone)")
        {
           // anim.SetTrigger("Die");

            yield return new WaitForSeconds(3f);
            Enemy.SetActive(false);

        }

    }

}
