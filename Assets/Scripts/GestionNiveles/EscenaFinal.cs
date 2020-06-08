using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscenaFinal : MonoBehaviour
{
    Stopwatch tiempo;
    // Start is called before the first frame update
    void Start()
    {
        tiempo = new Stopwatch();
        tiempo.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (tiempo.Elapsed >= new TimeSpan(0,0,3))
        {
            SceneManager.LoadScene("MenuPrincipal");
        }
    }
}
