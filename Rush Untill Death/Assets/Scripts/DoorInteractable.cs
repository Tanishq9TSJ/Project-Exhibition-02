using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteractable : MonoBehaviour
{
    public Animator anim;
    public AudioSource audio;
    private bool isOpen;
    void Awake()
    {
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }


    public void ToggleDoor()
    {
        isOpen = !isOpen;
        anim.SetBool("Open", true);
        audio.Play();
      
    }
}
