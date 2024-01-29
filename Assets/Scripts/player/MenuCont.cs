using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCont : MonoBehaviour
{
    [SerializeField] playerController playerController;
    [SerializeField] Animator aniMenu;
    [SerializeField] GameObject Menu;

    public bool isOpen;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isOpen != true)
        {
            playerController.enabled = false;
            isOpen = true;
            Menu.SetActive(true);
        }
        
        else if(Input.GetKeyDown(KeyCode.Escape) && isOpen != false)
        {
            StartCoroutine(closing());
            playerController.enabled = true;
        }
    }

    IEnumerator closing()
    {
        aniMenu.Play("cerrarMenu");
        yield return new WaitForSeconds(0.40f);
        isOpen = false;
        Menu.SetActive(false);
    }
}
