using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolProyectiles : MonoBehaviour
{

    private List<BolaDeFuegoController> balasDisponibles;

    
    //Creo las instancias que el jugador va a tener disponibles para lanzar proyectiles.
    void Start()
    {
        balasDisponibles.Add(new BolaDeFuegoController());
        balasDisponibles.Add(new BolaDeFuegoController());
        balasDisponibles.Add(new BolaDeFuegoController());
    }

    public BolaDeFuegoController ObtenerProyectil()
    {
        if (balasDisponibles.Count > 0)
        {
            return balasDisponibles[0];
        }
        return null;
    }



}
