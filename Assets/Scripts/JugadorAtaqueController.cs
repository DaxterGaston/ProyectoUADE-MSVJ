using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorAtaqueController : JugadorBehavior
{
    //TODO: Implementar pool para reutilizar instancias.
    //[SerializeField]
    //private PoolProyectiles pool;

    [SerializeField]
    private float velocidad;

    [SerializeField]
    private GameObject proyectil;
    
    private Vector3 direccion;
    void Start()
    {
        direccion = Vector3.zero;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            direccion += Vector3.up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direccion += Vector3.down;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direccion += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direccion += Vector3.right;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Disparar();
        }

        transform.position += direccion * velocidad * Time.deltaTime;
        direccion = Vector3.zero;
    }

    private void Disparar()
    {
        Memoria.Set("posicionJugador", transform);
        Instantiate(proyectil, transform.position, transform.rotation);
    }

}
