using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOP : MonoBehaviour
{
    private AudioSource a;
    public AudioClip clip1;
    public AudioClip clip2;
    public AudioClip clip3;
   
    void Start()
    {
        a = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            a.clip = clip1;
            a.Play();
        } 
        if(Input.GetKeyDown(KeyCode.S))
        {
            a.clip = clip1;
            a.Play();
        } 
        if(Input.GetKeyDown(KeyCode.A))
        {
            a.clip = clip1;
            a.Play();
        }  
        if(Input.GetKeyDown(KeyCode.D))
        {
            a.clip = clip1;
            a.Play();
        }
        if(Input.GetKeyUp(KeyCode.W))
        {
            a.clip = clip1;
            a.Stop();
        }  
        if(Input.GetKeyUp(KeyCode.S))
        {
            a.clip = clip1;
            a.Stop();
        }
        if(Input.GetKeyUp(KeyCode.A))
        {
            a.clip = clip1;
            a.Stop();
        }
        if(Input.GetKeyUp(KeyCode.D))
        {
            a.clip = clip1;
            a.Stop();
        }

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            a.clip = clip3;
            a.Play();
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            a.clip = clip3;
            a.Stop();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            a.clip = clip2;
            a.Play();
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            a.clip = clip2;
            a.Stop();
        }
    }
}
