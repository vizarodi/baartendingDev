using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{
    [Header("playerMove")]
    public float moveSpeed;
    public Rigidbody2D rb;
    private Vector2 moveInput;


    [Header("sonidos player")]
    public GameObject pasos;

    [Header("animation features")]
    public Animator Animator;

    [Header("papel controll")]
    public GameObject Papel;
    public Animator slide;
    private bool isActive;
    private bool hasBeenPressed;
    public AudioSource papelsound;

    

    void Update()
    {

        if (moveInput.x != 0 || moveInput.y != 0)
        {
            Animator.SetFloat("isMoving", 1);
            pasos.SetActive(true);
        }
        else
        {
            Animator.SetFloat("isMoving", 0);
            pasos.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Tab)) aparecerPapel();
        if (Input.GetKeyUp(KeyCode.R))
        {
            SceneManager.LoadScene(1);
        }
    }

    private void FixedUpdate()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        rb.MovePosition(rb.position + (moveInput * moveSpeed * Time.fixedDeltaTime));
    }

    //Configuracion movimiento del papel
    public void aparecerPapel()
    {
        if(isActive == false && hasBeenPressed == false)
        {
            papelsound.pitch = Random.Range(0.89f, 1.5f);
            StartCoroutine(precionaste());
            Papel.SetActive(true);
            papelsound.Play();
            slide.Play("SlideIn");
            isActive = true;
        }
        else if (isActive == true && hasBeenPressed == false)
        {
            papelsound.pitch = Random.Range(0.9f, 1.8f);

            StartCoroutine(precionaste());
            papelsound.Play();
            slide.Play("SlideOut");
            StartCoroutine(sacarPapel());

        }
    }

    private IEnumerator sacarPapel()
    {
        yield return new WaitForSeconds(0.30f);
        Papel.SetActive(false);
        isActive = false;

    }

    private IEnumerator precionaste()
    {
        hasBeenPressed = true;
        yield return new WaitForSeconds(0.30f);
        hasBeenPressed = false;
    }

}
