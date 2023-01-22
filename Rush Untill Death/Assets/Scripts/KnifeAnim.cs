using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeAnim : MonoBehaviour
{
    private Vector3 direction;
    private float speed;
    public Animator anim;
    public bool isAttacking = false;
    void Update()
    {
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");

        direction.x = hInput * speed;
        direction.z = vInput * speed;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 7f;
            anim.SetBool("Run", true);
        }
        else
        {
            speed = 5f;
            anim.SetFloat("Speed", vInput);
            anim.SetBool("Run", false);
        }

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            anim.SetTrigger("Attack");
            isAttacking = true;
            StartCoroutine(ResetAttackBool());
        }
    }

    IEnumerator ResetAttackBool()
    {
        yield return new WaitForSeconds(1.0f);
        isAttacking = false;
    }
}