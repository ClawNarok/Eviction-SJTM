using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegarItem : MonoBehaviour
{
    public MovePlayer move;
    public Animator anim;
    public bool segurar = false;
    public bool apontarItem = false;
    public bool apontarObjetivo = false;
    public bool comReceita = false;
    public GameObject mao;
    public GameObject item = null;
    public GameObject itemMao = null;
    public Desafio desafio;


    void Awake()
    {
        move = GetComponent<MovePlayer>();
        anim = GetComponent<Animator>();
        desafio = FindObjectOfType<Desafio>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (apontarItem && item && !itemMao)
                Seguraritem();

            if (apontarItem && item && itemMao)
                SoltarItem(item);

            if (apontarObjetivo && item)
            {
                comReceita = true;
                item.GetComponent<SFX>().sfxObjetivo();
                FindObjectOfType<Desafio>().PegarItens();
                ApontarDesapontarObjetivo();
            }
        }
    }

    public void ApontarDesapontarObjetivo(GameObject _item)
    {
        if (comReceita)
            return;
        
        apontarObjetivo = true;
        item = _item;
    }

    public void ApontarDesapontarObjetivo()
    {
        apontarObjetivo = false;
        item = null;
    }

    public void ApontarDesapontarItem(GameObject _item)
    {
        if (!comReceita)
            return;
        
        apontarItem = true;
        item = _item;
    }

    public void ApontarDesapontarItem()
    {
        if (!comReceita)
            return;
        
        apontarItem = false;
        item = null;
    }

    public void SoltarItem(GameObject alvo)
    {
        if (!comReceita)
            return;
        
        alvo.GetComponentInParent<CargaDescarga>().tarefaFeita = true;
        desafio.PegarItens();
        itemMao.transform.SetParent(alvo.transform);
        itemMao.transform.localPosition = Vector3.zero;
        itemMao.GetComponent<SFX>().sfxSoltar();
        apontarItem = false;
        itemMao = null;
        segurar = false;
        item = null;
    }

    public void Seguraritem()
    {
        if (!comReceita)
            return;
        
        segurar = true;
        apontarItem = false;
        item.GetComponentInParent<CargaDescarga>().tarefaFeita = true;
        itemMao = item;
        itemMao.transform.SetParent(mao.transform);
        itemMao.transform.localPosition = Vector3.zero;
        itemMao.GetComponent<SFX>().sfxPegar();
    }

    private void OnAnimatorIK(int layerIndex)
    {
        if (item != null && apontarItem)//apontar item
        {
            anim.SetIKPosition(AvatarIKGoal.RightHand, item.transform.position + item.transform.right * .1F);
            anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
            anim.SetIKPosition(AvatarIKGoal.LeftHand, item.transform.position - item.transform.right * .1F);
            anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
        }

        if (itemMao != null && segurar)//segurar item
            anim.SetLayerWeight(1,0);

        if (!segurar)
            anim.SetLayerWeight(1,1);

        if (item != null && !comReceita)//apontar objetivo
        {
            anim.SetIKPosition(AvatarIKGoal.RightHand, item.transform.position + item.transform.right * .1F);
            anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
        }
    }

    // anim.SetIKPosition(AvatarIKGoal.RightHand, volante.position + volante.right * .35F);
    // anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
    // anim.SetIKPosition(AvatarIKGoal.LeftHand, volante.position - volante.right * .35F);
    // anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);

    // anim.SetIKRotation (AvatarIKGoal.RightHand, volante.rotation * Quaternion.Euler(90, 90, 0));
    // anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
    // anim.SetIKRotation(AvatarIKGoal.LeftHand, volante.rotation * Quaternion.Euler(90, -90, 0));
    // anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
}