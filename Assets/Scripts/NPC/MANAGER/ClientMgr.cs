using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientMgr : MonoBehaviour
{
    [SerializeField] int clienteRandom;
    [SerializeField] GameObject[] cliente;
    [SerializeField] GameObject[] Ver;


    public float tiempoDeEspera;
    public int limite = 40;
    public int cuenta = 0;

    public bool puedeSpawn;
    private void Start()
    {
        StartCoroutine(generarNum());
    }

    void Update()
    {
        if(Ver[1].activeSelf && Ver[2].activeSelf && Ver[3].activeSelf && Ver[4].activeSelf || Ver[0].activeSelf)
        {
            puedeSpawn = false;
        }
        else
        {
            puedeSpawn = true;
        }
    }

    IEnumerator generarNum()
    {
        if (cuenta < limite)
        {
            yield return new WaitForSeconds(tiempoDeEspera);
            if(puedeSpawn == true)
            {
                clienteRandom = Random.Range(0, cliente.Length);
                Debug.Log("se eligio un cliente");
                tiempoDeEspera = Random.Range(3, 6f);
                StartCoroutine(generarCliente());
            }
            else
            {
                Debug.Log("se cancelo el spawn");
                StartCoroutine(generarNum());
            }
        }
        else
        {
            StartCoroutine(generarNum());
        }
    }

    IEnumerator generarCliente()
    {

        if (cliente[clienteRandom].activeInHierarchy == false && puedeSpawn == true)
        {
            yield return new WaitForSeconds(tiempoDeEspera);    

            Debug.Log("aparecio un cliente");

            cliente[clienteRandom].SetActive(true);
            cuenta += 1;
            StartCoroutine(generarNum());
        }
        else
        {
            Debug.Log("no es posible aparecer clientes");

            StartCoroutine( generarNum());
        }

    }
}
