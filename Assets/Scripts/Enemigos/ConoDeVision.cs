using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConoDeVision : MonoBehaviour
{
    public float radio;
    [Range(0f,360f)]
    public float angulo;

    [SerializeField]
    private LayerMask objetivos;
    [SerializeField]
    private LayerMask obstaculos;

    public List<Transform> objetivosVisibles = new List<Transform>();
    public void EncontrarObjetivosVisibles()
    {
        objetivosVisibles.Clear();
        //Obtengo todas las colisiones que se dieron dentro del radio.
        Collider2D[] objetivosEnRadio = Physics2D.OverlapCircleAll(transform.position, radio, objetivos);
        
        //Recorro el array con todas las colisiones.
        for (int i = 0; i < objetivosEnRadio.Length; i++)
        {
            //Obtengo el vector en direccion a ese objetivo normalizado.
            Transform objetivo = objetivosEnRadio[i].transform;
            Vector2 direccionAlObjetivo = (objetivo.position - transform.position).normalized;

            //Verifico si esta dentro del ángulo de mi cono de vision.
            if (Vector2.Angle(transform.up, direccionAlObjetivo) < angulo / 2) 
            {
                float distanciaAlObjetivo = Vector2.Distance(transform.position, objetivo.position);
                if (!Physics2D.Raycast(transform.position, direccionAlObjetivo, distanciaAlObjetivo, obstaculos))
                {
                    objetivosVisibles.Add(objetivo);
                }
            }
        }
    }
    public Vector3 DireccionDesdeAngulo(float gradosDelAngulo)
    {
        return new Vector2(Mathf.Sin(gradosDelAngulo * Mathf.Deg2Rad), Mathf.Cos(gradosDelAngulo * Mathf.Deg2Rad));
    }
}
