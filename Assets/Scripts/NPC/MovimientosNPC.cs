using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientosNPC : MonoBehaviour
{
    public Transform[] puntosDeCamino;
    public GameObject[] ver;
    public float velocidad = 5f;
    private int puntoActual = 0;

    [SerializeField] public bool Llego;
    public Transform salida;
    public GameObject verSalida;
    [SerializeField] public bool termino;

    

    void Update()
    {
        if (ver[puntoActual].activeInHierarchy == false)
        {
           

            // Mueve el NPC hacia el siguiente punto del camino
            transform.position = Vector3.MoveTowards(transform.position, puntosDeCamino[puntoActual].position, velocidad * Time.deltaTime);

            // Si el NPC llega al punto, avanza al siguiente
            if (Vector3.Distance(transform.position, puntosDeCamino[puntoActual].position) < 0.1f)
            {
                ver[puntoActual].SetActive(true);
                Llego = true;
            }
        }

        else
        {
            addNum();
        }

        if(termino == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, salida.position, velocidad * Time.deltaTime);

            if (Vector3.Distance(transform.position, salida.position) < 0.1f)
            {
                Llego = false;
                termino = false;
                ver[puntoActual].SetActive(false);
                puntoActual = 0;

                gameObject.SetActive(false);
            }
        }

    }

    public void addNum()
    {
        if (Llego != true)
        {
            ver[0].SetActive(false);

            puntoActual += 1;
        }
    }
}

            //siguientePaso += 1;
            //tomandoAsiento = true;