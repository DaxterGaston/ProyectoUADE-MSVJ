using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposicionamiento : MonoBehaviour
{
    private Dictionary<int, Vector3> PosicionesCamara;
    private readonly float Velocidad = 15f;
    // Start is called before the first frame update
    void Start()
    {
        //TODO: Establecer posiciones predeterminadas para la camara al momento de cambiar de parte del nivel.
        PosicionesCamara = new Dictionary<int, Vector3>();
        PosicionesCamara.Add(1, new Vector3(0, 0, -10));
        PosicionesCamara.Add(2, new Vector3(23.5f, 0, -10));
        PosicionesCamara.Add(3, new Vector3(47.5f, 0, -10));
        PosicionesCamara.Add(4, new Vector3(72.5f, 0, -10));
    }

    public void CambiarEscenario(int nroEscenario)
    {
        Debug.Log("Llamó a la camara");
        //transform.position = Vector3.MoveTowards(transform.position, PosicionesCamara[nroEscenario], Velocidad);
        transform.Translate(PosicionesCamara[nroEscenario]);
    }
}
