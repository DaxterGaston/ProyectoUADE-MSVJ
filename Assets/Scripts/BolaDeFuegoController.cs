using System;
using System.Diagnostics;
using UnityEngine;

public class BolaDeFuegoController : MonoBehaviour
{
    #region SetUp

    //Velocidad a la que va a viajar el proyectil.
    [SerializeField]
    private float velocidad;
    //Objeto proyectil
    //Esta variable define en que direccion debe moverse el proyectil, se actualiza al impactar contra algun objeto.
    private Vector3 direccionMovimiento;
    //Controlo el tiempo de vida del objeto disparado.
    private Transform posicionDisparo;
    private Stopwatch tiempoVidaProyectil;
    private Blackboard memoria;
    private GameObject jugador;
    private Vector2 posicionMouse;

    void Start()
    {
        //Obtengo la posicion desde la que el jugador disparó.
        jugador = GameObject.FindGameObjectWithTag("Jugador");
        memoria = jugador.GetComponent<Blackboard>();
        posicionDisparo = (Transform)memoria.Get("posicionJugador");
        //Obtengo la posicion del mouse al momento de disparar.
        posicionMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Obtengo la direccion inicial de movimiento del proyectil.
        direccionMovimiento = posicionMouse - (Vector2)posicionDisparo.position;
        direccionMovimiento.Normalize();
        //Seteo el momento de instanciamiento del objeto
        tiempoVidaProyectil = new Stopwatch();
        tiempoVidaProyectil.Start();
    }

    #endregion

    void Update()
    {
        transform.position += direccionMovimiento * velocidad * Time.deltaTime;
        if (tiempoVidaProyectil.Elapsed > new TimeSpan(0, 0, 3))
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 normal;
        if (collision.contacts[0].collider.CompareTag("Pared"))
        {
            UnityEngine.Debug.Log("Choco!");
            normal = collision.contacts[0].normal;
            direccionMovimiento = Vector2.Reflect(direccionMovimiento, normal);
        }
    }
}
