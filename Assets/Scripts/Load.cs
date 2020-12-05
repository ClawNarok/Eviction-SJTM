using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum Cena
{
    Menu,
    Ilha,
    Load,
    Lab
}

public class Load : MonoBehaviour
{
    static Cena proximaCena = Cena.Menu;
    static AsyncOperation op;
    Slider slide;

    void Awake()
    {
        slide = FindObjectOfType<Slider>();
    }

    void Start()
    {
        CarregarCena();
    }

    public static void CarregarCena(Cena cena)
    {
        proximaCena = cena;
        op = SceneManager.LoadSceneAsync(Cena.Load.ToString());
    }

    public static void CarregarCena()
    {
        op = SceneManager.LoadSceneAsync(proximaCena.ToString());
    }

    void Update()
    {
        slide.value = op.progress;
    }
}