using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaw : MonoBehaviour
{
    public GameObject inimigo;
    public Transform posicaoSpawn;
    public int tempoInicial, tempoSpawn;

    void Start()
    {
        InvokeRepeating("instanciarInimigo", tempoInicial, tempoSpawn);
    }

    public void instanciarInimigo()
    {
        Instantiate(inimigo, posicaoSpawn.position, Quaternion.identity);
    }

}
