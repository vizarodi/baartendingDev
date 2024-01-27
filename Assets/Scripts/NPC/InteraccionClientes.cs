using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteraccionClientes : MonoBehaviour
{
    public BoxCollider2D bx;
    public MovimientosNPC NPC;
    public GameObject cerveza;
    public GameObject cervezaUI;
    //////////////////////////

    public bool Contacto;
    public bool atendido;

    public bool cervezaEnEspera;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E) && atendido == false && Contacto == true)
        {
            atendido = true;
            cervezaEnEspera = true;
            NPC.Llego = false;
        }
        if(cervezaEnEspera == true && Input.GetKeyUp(KeyCode.E) && NPC.Llego ==true && Contacto == true)
        {
            cervezaUI.SetActive(false);
            cerveza.SetActive(true);
            cervezaEnEspera = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Contacto = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Contacto = false;
        }
    }
}
