using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Direccion
{ 
    Arriba,
    Abajo,
    Izquierda,
    Derecha,
    Arriba_Izquierda,
    Arriba_Derecha,
    Abajo_Izquierda,
    Abajo_Derecha
}
public class JugadorAtaqueController : JugadorBehavior
{
    #region SetUp
    //TODO: Implementar pool para reutilizar instancias.
    //[SerializeField]
    //private PoolProyectiles pool;
    private Animator anim;
    [SerializeField]
    private float velocidad;
    [SerializeField]
    private GameObject proyectil;
    public bool movimiento = true;
    private TimeSpan intervaloDisparo;
    private DateTime ultimoDisparo;

    private Dictionary<int, Vector3> PosicionesInicialesJugador;

    private Vector3 direccion;
    void Start()
    {
        direccion = Vector3.zero;
        anim = GetComponent<Animator>();
        Physics2D.IgnoreLayerCollision(8, 9);
        PosicionesInicialesJugador = new Dictionary<int, Vector3>();
        PosicionesInicialesJugador.Add(1, new Vector3(-10f, 3.5f, 9f));
        PosicionesInicialesJugador.Add(2, new Vector3(13.5f, 0f, 9f));
        PosicionesInicialesJugador.Add(3, new Vector3(37f, 0f, 9f));
        PosicionesInicialesJugador.Add(4, new Vector3(61f, 0f, 9f));
        intervaloDisparo = new TimeSpan(0, 0, 2);
        ultimoDisparo = new DateTime();
    }
    #endregion

    void Update()
    {
        GestionMovimiento();
        if (Input.GetKeyDown(KeyCode.Mouse0) && movimiento && DateTime.Now >= ultimoDisparo.Add(intervaloDisparo))
        {
            Disparar();
            ultimoDisparo = DateTime.Now;
        }

        transform.position += direccion * velocidad * Time.deltaTime;
        
        direccion = Vector3.zero;
    }

    /// <summary>
    /// Este metodo controla el movimiento y la animacion del jugador.
    /// Parametros de las trancisiones
    /// @EnMovimiento[boolean](true - false, determina si el jugador se encuentra en movimiento o quieto)
    /// @Direccion[int](Determina la direccion del jugador, utilizando los numeros del 1-9 excluido el 5, utilizando este ultimo como
    /// posicion general y los demas en relacion a la direccion en la que se encuentran del 5)
    /// </summary>
    private void GestionMovimiento()
    {
        if (!movimiento)
        {
            anim.SetBool("EnMovimiento", false);
            return;
        }
        anim.SetBool("EnMovimiento", true);
        //Arriba
        if (Input.GetKey(KeyCode.W))
        {
            anim.SetInteger("Direccion", 8);
            direccion += Vector3.up;
            //Arriba izquierda
            if (Input.GetKey(KeyCode.A))
            {
                anim.SetInteger("Direccion", 7);
                direccion += Vector3.left;
            }
            //Arriba derecha
            if (Input.GetKey(KeyCode.D))
            {
                anim.SetInteger("Direccion", 9);
                direccion += Vector3.right;
            }
        }
        //Abajo
        else if (Input.GetKey(KeyCode.S))
        {
            anim.SetInteger("Direccion", 2);
            direccion += Vector3.down;
            //Abajo izquierda
            if (Input.GetKey(KeyCode.A))
            {
                anim.SetInteger("Direccion", 1);
                direccion += Vector3.left;
            }
            //Abajo derecha
            if (Input.GetKey(KeyCode.D))
            {
                anim.SetInteger("Direccion", 3);
                direccion += Vector3.right;
            }
        }
        //Izquierda
        else if (Input.GetKey(KeyCode.A))
        {
            anim.SetInteger("Direccion", 4);
            direccion += Vector3.left;
        }
        //Derecha
        else if (Input.GetKey(KeyCode.D))
        {
            anim.SetInteger("Direccion", 6);
            direccion += Vector3.right;
        }
        else
        {
            //Al no estarse presionando ninguna tecla, el jugador no se encuentra en movimiento.
            anim.SetBool("EnMovimiento", false);
        }
    }

    //Para disparar, instancio el proyectil. La direccion y velocidad se controla dentro del script del proyectil.
    private void Disparar()
    {
        Memoria.Set("posicionJugador", transform);
        Instantiate(proyectil, transform.position, transform.rotation);
    }

    public void CambiarEscenario(int nroEscenario)
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        sprite.enabled = false;
        transform.position = PosicionesInicialesJugador[nroEscenario];
        sprite.enabled = true;
    }

}
