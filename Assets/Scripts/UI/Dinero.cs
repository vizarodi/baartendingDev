using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dinero : MonoBehaviour
{
    public TextMeshProUGUI dineroDisponible;

    // Update is called once per frame
    void Update()
    {
        dineroDisponible.text = GameManager.Instance.dineroTotal.ToString();
    }
}
