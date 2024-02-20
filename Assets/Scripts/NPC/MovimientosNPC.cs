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
    [SerializeField] public bool LlegoAlAsiento;
    public Transform salida;
    public GameObject verSalida;
    [SerializeField] public bool termino;

    //animacion
    public Animator anim;
    

    void Update()
    {
        if (ver[puntoActual].activeInHierarchy == false)
        {
            // Mueve el NPC hacia el siguiente punto del camino
            transform.position = Vector3.MoveTowards(transform.position, puntosDeCamino[puntoActual].position, velocidad * Time.deltaTime);
            anim.SetBool("IsWalking", true);

            // Si el NPC llega al punto, avanza al siguiente
            if (Vector3.Distance(transform.position, puntosDeCamino[puntoActual].position) < 0.1f)
            {
                anim.SetBool("IsWalking", false);
                ver[puntoActual].SetActive(true);
                Llego = true;
                if(puntoActual > 0 && Vector3.Distance(transform.position, puntosDeCamino[puntoActual].position) < 0.1f)
                {
                    LlegoAlAsiento = true;
                }
            }
        }

        else
        {
            addNum();
        }

        if(termino == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, salida.position, velocidad * Time.deltaTime);
            anim.SetBool("IsWalking", true);


            if (Vector3.Distance(transform.position, salida.position) < 0.1f)
            {
                resetSettings();
            }
        }

    }

    public void addNum()
    {
        if (Llego != true && LlegoAlAsiento != true)
        {
            ver[0].SetActive(false);

            puntoActual += 1;
        }
    }

    private void resetSettings()
    {
        Llego = false;
        LlegoAlAsiento = false;
        termino = false;
        ver[puntoActual].SetActive(false);
        puntoActual = 0;

        gameObject.SetActive(false);
    }

}

            //siguientePaso += 1;
            //tomandoAsiento = true;