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
    public bool cervezaEnEspera =true;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E) && atendido == false && Contacto == true && NPC.LlegoAlAsiento != true  && NPC.Llego !=false)
        {
            atendido = true;
            cervezaEnEspera = true;
            NPC.Llego = false;
        }
        if(cervezaEnEspera == true && Input.GetKeyUp(KeyCode.E) && cervezaUI.activeInHierarchy && Contacto == true && NPC.LlegoAlAsiento == true)
        {
            defaultSet();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") )
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

    private void defaultSet()
    {
        cervezaUI.SetActive(false);
        cerveza.SetActive(true);
        cervezaEnEspera = false;
        atendido = false;
    }
}
