using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terminar : MonoBehaviour
{
    public activarMezcla servir;
    public MovimientosNPC npc;

    public bool mucho, genial, bueno, malo;

    public int price;


    // Start is called before the first frame update
    private void OnEnable()
    {

        mucho = servir.calidadExc;
        genial = servir.calidadPer;
        bueno = servir.calidadBue;
        malo = servir.calidadMal;

        if (mucho == true || malo == true)
        {
            price = 0;
        } 
        if(genial == true)
        {
            price = 5;
        }
        if(bueno == true)
        {
            price = 2;
        }
        StartCoroutine(terminandoPedido());
    }

    IEnumerator terminandoPedido()
    {
        servir.calidadExc = false;
        servir.calidadPer = false;
        servir.calidadBue = false;
        servir.calidadMal = false;
        yield return new WaitForSeconds(10);
        npc.termino = true;
        pagar();
        gameObject.SetActive(false);
    }


    public void pagar()
    {
        GameManager.Instance.AddMoney(price);
        // a�adir un script q maneje los precios en el player (podria ser el del mismo player)
    }
}
