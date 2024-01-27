using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogo : MonoBehaviour
{
    public TextMeshProUGUI textoDialogo;
    public string[] lineas;
    public float textSpeed;

    [SerializeField] int index;

    public interactable iteractable;

    void Start()
    {
        textoDialogo.text = string.Empty;
        startDialogo();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            if(textoDialogo.text == lineas[index])
            {
                nextLine();
            }
            else
            {
                StopAllCoroutines();
                textoDialogo.text = lineas[index];

            }
        }
    }

    public void startDialogo()
    {
        index = 0;
        iteractable.enabled=false;//se desactiva controlador
        StartCoroutine(WriteLine());
    }

    IEnumerator WriteLine()
    {
        foreach (char letter in lineas[index].ToCharArray())
        {
            textoDialogo.text += letter;

            yield return new WaitForSeconds(textSpeed);
        }
    }

    public void nextLine()
    {
        if(index < lineas.Length - 1)
        {
            index++;
            textoDialogo.text = string.Empty;
            StartCoroutine(WriteLine());
        }
        else
        {
            iteractable.enabled = true;//se activa controlador
            index = 0;
            gameObject.SetActive(false);
        }
    }
}
