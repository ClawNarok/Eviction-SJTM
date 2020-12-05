using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Desafio : MonoBehaviour
{
    public Text txtDesafio;
    public string msgReceita = "Ache a receita do medicamento.";
    public string msgDesafio = "Ache os ingredientes e coloque na mesa.";
    Objetivos obj;
    public Animator animPortaSaida;
    public AudioSource somPortaSaida;
    public Animator animPortaEntrada;
    public AudioSource somPortaEntrada;
    public float delaySala = .5f;


    void Awake()
    {
        somPortaSaida = GetComponent<AudioSource>();
        animPortaSaida = GetComponent<Animator>();
        txtDesafio = FindObjectOfType<Text>();
        obj = FindObjectOfType<Objetivos>();
    }

    void Start()
    {
        PegarReceita();
        StartCoroutine(FecharSala());
    }

    IEnumerator FecharSala()
    {
        animPortaEntrada.SetBool("character_nearby",  false);
        yield return new WaitForSeconds(delaySala);
        somPortaEntrada.Play();
    }

    public void PegarReceita()
    {
        txtDesafio.text = msgReceita;
    }

    public void PegarItens()
    {
        obj.Objetivo();
        txtDesafio.text = string.Format(msgDesafio + " ({0}/{1})", obj.itensColocados, obj.itensTotais);
        ChecarDesafios();
    }

    public void ChecarDesafios()
    {
        if (obj.itensColocados == obj.itensTotais)
        {
            animPortaSaida.SetBool("character_nearby", true);
            somPortaSaida.Play();
        }
    }
}