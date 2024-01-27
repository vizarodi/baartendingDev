using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactable : MonoBehaviour
{
    [SerializeField] BoxCollider2D Bc2d;

    public bool isOnCollision;

    ///////////////////////////

    [SerializeField] GameObject objActibable;

    private void Update()
    {
        if (isOnCollision == true )
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                accion();
            }
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isOnCollision = true;

        }
        //SE ACTIVA ISONCOLLISION

        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isOnCollision = false;

        }
        //SE DESACTIVA ISONCOLLISION
    }

    private void accion()
    {
        if(objActibable.activeInHierarchy == false)
        {
            objActibable.SetActive(true);

        }
        else
        {
            objActibable.SetActive(false);
        }
    }
}
