using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporte : MonoBehaviour
{
    public static Vector3 VoltaCidade;
    public static bool noLab = false;
    public GameObject player;


    void Awake()
    {
        if (noLab)
        {
            player = FindObjectOfType<MovePlayer>().gameObject;
            player.transform.position = transform.position;
            player.transform.rotation = transform.rotation;
            noLab = false;
        }
    }

    public static void EntrarLab()
    {
        Load.CarregarCena(Cena.Lab);
    }

    public static void SairLab()
    {
        noLab = true;
        Load.CarregarCena(Cena.Ilha);
    }
}