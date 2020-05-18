using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Timers;
using UnityEngine;

public class BolaDeFuegoController : MonoBehaviour
{
    #region SetUp

    //Velocidad a la que va a viajar el proyectil.
    [SerializeField]
    private float velocidad;
    //Objeto proyectil
    private Camera camara;
    //Esta variable define en que direccion debe moverse el proyectil, se actualiza al impactar contra algun objeto.
    private Vector3 direccionMovimiento;
    //Controlo el tiempo de vida del objeto disparado.
    private Transform posicionDisparo;
    private Stopwatch tiempoVidaProyectil;
    private Blackboard memoria;
    private GameObject jugador;
    private CircleCollider2D collider;

    void Start()
    {
        jugador = GameObject.Find("Jugador");
        memoria = jugador.GetComponent<Blackboard>();
        camara = Camera.main;
        posicionDisparo = (Transform)memoria.Get("posicionJugador");
        Vector3 direccionInicialMovimiento = camara.ScreenToWorldPoint(Input.mousePosition) - posicionDisparo.position;
        direccionMovimiento = direccionInicialMovimiento.normalized;

        collider = GetComponent<CircleCollider2D>();
    }

    #endregion

    void Update()
    {
        transform.position += direccionMovimiento * velocidad * Time.deltaTime;
        if (collider.tag == "pared")
        {
            UnityEngine.Debug.Log("Chocó!");
            Vector2.Perpendicular(direccionMovimiento);
        }
    }

    
}
