using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{
    public AudioClip pegarItem;
    public AudioClip soltarItem;
    public AudioSource sfx;


    void Awake()
    {
        sfx = GetComponent<AudioSource>();
    }

    public void sfxObjetivo()
    {
        sfx.Play();
    }

    public void sfxPegar()
    {
        sfx.PlayOneShot(pegarItem);
    }

    public void sfxSoltar()
    {
        sfx.PlayOneShot(soltarItem);
    }
}