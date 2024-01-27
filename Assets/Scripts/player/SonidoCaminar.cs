using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoCaminar : MonoBehaviour
{
    public AudioSource pasos;
    // Update is called once per frame
    void Update()
    {
        StartCoroutine(enumerator());
    }

    IEnumerator enumerator()
    {
        yield return new WaitForSeconds(0.27f);
        pasos.pitch = Random.Range(1, 1.4f);
    }
}
