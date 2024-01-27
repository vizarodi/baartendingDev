using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColeccionObj : MonoBehaviour
{
    [SerializeField] BoxCollider2D Bc2d;

    public bool isOnCollision;
    public bool isPlayer;

    ///////////////////////////

    [SerializeField] GameObject objActibable;

    private void Update()
    {
        if(isOnCollision == true)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                accion();
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
        
            isPlayer = true;
        
            isOnCollision = true;

        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player")) 
        { 
            isPlayer = false;
            isOnCollision = false;
        }

    }

    private void accion()
    {
        if (objActibable.activeInHierarchy == false && isPlayer==true)
        {
            objActibable.SetActive(true);
        }
    }
}
