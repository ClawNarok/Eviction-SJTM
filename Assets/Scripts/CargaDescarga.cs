using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargaDescarga : MonoBehaviour
{
    public TipoItem Tipo;
    public PegarItem player;
    public bool tarefaFeita = false;
    public GameObject slot;
    


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.transform.GetComponentInParent<PegarItem>();
            Acao();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = null;
            Acao(other.GetComponentInParent<PegarItem>());
        }
    }

    public void Acao(PegarItem _player)
    {
        if (tarefaFeita)
            return;

        switch (Tipo)
        {
            case TipoItem.Objetivo:
                _player.ApontarDesapontarObjetivo();
                break;
            case TipoItem.PegarItem:
                _player.ApontarDesapontarItem();
                break;
            case TipoItem.SoltarITem:
                _player.ApontarDesapontarItem();
                break;
        }
    }

    public void Acao()
    {
        if (tarefaFeita)
            return;

        if(player)
        {
            switch (Tipo)
            {
                case TipoItem.Objetivo:
                    player.ApontarDesapontarObjetivo(transform.GetChild(0).gameObject);
                    break;
                case TipoItem.PegarItem:
                    if (player.comReceita)
                        player.ApontarDesapontarItem(transform.GetChild(0).gameObject);
                    break;
                case TipoItem.SoltarITem:
                    if (player.itemMao && player.comReceita)
                        player.ApontarDesapontarItem(slot);
                    break;
            }
        }
    }
}