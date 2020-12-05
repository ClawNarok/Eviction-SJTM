using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapaControle : MonoBehaviour
{
    public enum Cidades
    {
        CidadeLitoral,
        CidadeInterior,
        CidadeCapital
    }
    public GameObject player;
    public Cidades Cidade;
    public float dist = 100;
    public bool cidadeAtiva = false;



    void Awake()
    {
        player = FindObjectOfType<MovePlayer>().gameObject;
    }

    void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) <= dist)
        {
            if (!cidadeAtiva)
                SceneManager.LoadSceneAsync(Cidade.ToString(),LoadSceneMode.Additive);
            cidadeAtiva = true;
        }
        else
        {
            if (cidadeAtiva)
                SceneManager.UnloadSceneAsync(Cidade.ToString());
            cidadeAtiva = false;
        }
    }
}