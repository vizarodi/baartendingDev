using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenombrarDespues : MonoBehaviour
{
    public GameObject este;

    public GameObject espacio1, espacio2, espacio3, espacio4, espacio5;
    [SerializeField] Transform lugar1, lugar2, lugar3, lugar4, lugar5;

    private void Start()
    {
        posicionamiento();
    }

    public void posicionamiento()
    {
        if(espacio1.activeInHierarchy == false)
        {
            este.transform.position = lugar1.position;
            espacio1.SetActive(true);
        }
        else if(espacio2.activeInHierarchy == false)
        {
            este.transform.position = lugar2.position;
            espacio2.SetActive(true);
        }
        else if(espacio3.activeInHierarchy == false)
        {
            este.transform.position = lugar3.position;
            espacio3.SetActive(true);
        }
        else if (espacio4.activeInHierarchy == false)
        {
            este.transform.position = lugar4.position;
            espacio4.SetActive(true);
        }
        else if (espacio5.activeInHierarchy == false)
        {
            este.transform.position = lugar5.position;
            espacio5.SetActive(true);
        }
    }
}
