using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pause;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            chamarPause();
        }
    }

    public void voltarMenu()
    {
        Load.CarregarCena(Cena.Menu);
    }

    void chamarPause()
    {
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0.00000001f;
        pause.SetActive(true);
    }

    public void retomarJogo()
    {
        Time.timeScale = 1f;
        pause.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
}