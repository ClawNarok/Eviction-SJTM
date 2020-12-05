using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    Animator anim;
    AudioSource SFX;
    public AudioClip abrirPortal, fecharPortal;


    void Awake()
    {
        SFX = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            anim.SetBool("character_nearby", true);
            SFX.PlayOneShot(abrirPortal);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            anim.SetBool("character_nearby", false);
            SFX.PlayOneShot(fecharPortal);
        }
    }
}