using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class activarMezcla : MonoBehaviour
{
    [Header("mezcla controll")]
    public GameObject mezclaMen;
    public Animator activarOdesactivar;
    private bool estaActive;
    private bool cervezacreada;
    private bool fuePressed;
    [SerializeField] bool colicion;
    public AudioSource slideInSound;
    public AudioSource slideOutSound;
    public BoxCollider2D bx;

    [Header("Control cerveza")]
    public bool yaVertio;
    public bool calidadExc, calidadPer, calidadBue, calidadMal;
    public Slider liquido;
    public float cantidadActual = 0f;
    public float velocidadCrecimiento = 0.5f;
    public GameObject CervezaItem;

    [Header("Particulas")]
    public GameObject particulaExito;


    private void Update()            
    {
        cantidadActual = liquido.value;

        if(CervezaItem.activeInHierarchy == false)
        {
            if (Input.GetKey(KeyCode.Space) && estaActive == true && yaVertio != true && cervezacreada == false)
            {
                liquido.value += velocidadCrecimiento * Time.deltaTime;
            }
            else if (Input.GetKeyUp(KeyCode.Space) && estaActive == true)
            {
                yaVertio = true;
                comprobarCalidad();
            }
        }
    }

    private void comprobarCalidad()
    {
        if(cantidadActual >= 0.9f)
        {
            calidadExc = true;
            Debug.LogError("EXCESIVO");
            CervezaItem.SetActive(true);
            //dmaciado liquido = 0 plata
        }
        if (cantidadActual >= 0.85f && cantidadActual < 0.9f)
        {
            calidadPer = true;
            //buena calidad = 1plata
            CervezaItem.SetActive(true);
            particulaExito.SetActive(true);
            Debug.Log("PERFECTO");
        }
        else if (cantidadActual < 0.85f && cantidadActual >= 0.6f)
        {
            calidadBue = true;
            Debug.LogWarning("Bueno");
            CervezaItem.SetActive(true);
            //aceptable = 1/2plata
        }
        else if(cantidadActual < 0.6)
        {
            calidadMal = true;
            //mediocre = 0plata
            Debug.LogError("Asqueroso");
            CervezaItem.SetActive(true);

        }
    }





    private IEnumerator sacarPapel()
    {
        yield return new WaitForSeconds(0.5f);
        yaVertio = false;
        cantidadActual = 0f;
        liquido.value = 0f;
        mezclaMen.SetActive(false);
        estaActive = false;
    }

    private IEnumerator precionaste()
    {
        fuePressed = true;
        yield return new WaitForSeconds(0.5f);
        fuePressed = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (estaActive == false && fuePressed == false)
            {
                slideInSound.pitch = Random.Range(0.89f, 1.5f);
                //StartCoroutine(precionaste());
                mezclaMen.SetActive(true);
                slideInSound.Play();
                activarOdesactivar.Play("Activar");
                estaActive = true;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (estaActive == true && fuePressed == false)
            {
                slideOutSound.pitch = Random.Range(0.9f, 1.8f);

                //StartCoroutine(precionaste());
                slideOutSound.Play();
                activarOdesactivar.Play("desacticar");
                StartCoroutine(sacarPapel());
            }
        }
    }
}
