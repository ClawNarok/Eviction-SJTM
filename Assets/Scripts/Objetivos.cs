using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TipoItem
{
    PegarItem,
    SoltarITem,
    Objetivo
}

public class Objetivos : MonoBehaviour
{
    public int itensColocados = 0;
    public int itensTotais = 4;
    public AudioSource somEnergia;
    public ParticleSystem particula;


    public void Objetivo()
    {
        itensColocados++;
        if (itensTotais == itensColocados)
            ObjetivosConcluidos();
    }

    public void ObjetivosConcluidos()
    {
        somEnergia.Play();
        particula.Play();
    }
}