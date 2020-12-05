using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCControl : MonoBehaviour
{
    public NavMeshAgent agent;
    public Animator anim;
    public GameObject[] pontos;
    public enum estadoAnim
    {
        Idle,
        Andando
    }
    public estadoAnim estadoAtual;
    public GameObject destino;


    void Awake()
    {
        anim = transform.GetComponent<Animator>();
        agent = transform.GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        print("start");
        pontos = GameObject.FindGameObjectsWithTag("Ponto");
        StartCoroutine(estadoAnim.Idle.ToString());
    }

    void Update()
    {
        anim.SetFloat("Mover", agent.velocity.magnitude);
    }

    IEnumerator Idle()
    {
        estadoAtual = estadoAnim.Idle;
        float timer = Random.Range(1,5);
        yield return new WaitForSeconds(timer);
        StartCoroutine(estadoAnim.Andando.ToString());
    }

    IEnumerator Andando()
    {
        estadoAtual = estadoAnim.Andando;
        int x = Random.Range(0, pontos.Length);
        destino = pontos[x];
        agent.SetDestination(pontos[x].transform.position);
        print(Vector3.Distance(transform.position, pontos[x].transform.position));
        while (Vector3.Distance(transform.position, pontos[x].transform.position) > 2)
        {
            yield return new WaitForFixedUpdate();
        }
        print(Vector3.Distance(transform.position, pontos[x].transform.position));
        StartCoroutine(estadoAnim.Idle.ToString());
    }
}