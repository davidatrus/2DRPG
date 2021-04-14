using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trig : MonoBehaviour
{
    public Canvas myCanvas;

    private void Start()
    {
        myCanvas.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        myCanvas.enabled = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        myCanvas.enabled = false;
    }
}