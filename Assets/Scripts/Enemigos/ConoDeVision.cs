using System.Collections.Generic;
using UnityEngine;
public enum DireccionCono
{ 
    Arriba,
    Abajo,
    Izquierda,
    Derecha
}
public class ConoDeVision : MonoBehaviour
{
    public float radio;
    [Range(0f, 360f)]
    public float angulo;
    [SerializeField]
    private LayerMask objetivos;
    [SerializeField]
    private LayerMask obstaculos;
    public DireccionCono direccionEnum;
    public Vector2 direccionVision;

    /// <summary>
    /// Obtengo el vector direccional para encarar el cono.
    /// Publico para pruebas GUI.
    /// </summary>
    /// <param name="direccion"></param>
    /// <returns></returns>
    public Vector2 ObtenerVectorDireccional(DireccionCono direccion)
    {
        switch (direccion)
        {
            case DireccionCono.Arriba:
                return Vector2.up;
            case DireccionCono.Abajo:
                return Vector2.down;
            case DireccionCono.Izquierda:
                return Vector2.left;
            case DireccionCono.Derecha:
                return Vector2.right;
            default:
                Debug.LogError("Direccion para el cono de vision invalida.");
                return Vector2.zero;
        }
    }

    public List<Transform> objetivosVisibles = new List<Transform>();
    public List<Transform> objetivosEnRangoNoVisibles = new List<Transform>();
    public void EncontrarObjetivosVisibles(DireccionCono direccion)
    {
        direccionVision = ObtenerVectorDireccional(direccion);
        objetivosEnRangoNoVisibles.Clear();
        objetivosVisibles.Clear();
        //Obtengo todas las colisiones que se dieron dentro del radio.
        Collider2D[] objetivosEnRadio = Physics2D.OverlapCircleAll(transform.position, radio, objetivos);
        
        //Recorro el array con todas las colisiones.
        for (int i = 0; i < objetivosEnRadio.Length; i++)
        {
            //Obtengo el vector en direccion a ese objetivo normalizado.
            Transform objetivo = objetivosEnRadio[i].transform;
            Vector2 direccionAlObjetivo = (objetivo.position - transform.position).normalized;

            //Verifico si esta dentro del ángulo de mi cono de vision en la direccion determinada.
            if (Vector2.Angle(direccionVision, direccionAlObjetivo) < angulo / 2) 
            {
                float distanciaAlObjetivo = Vector2.Distance(transform.position, objetivo.position);
                if (!Physics2D.Raycast(transform.position, direccionAlObjetivo, distanciaAlObjetivo, obstaculos))
                    objetivosVisibles.Add(objetivo);
                else
                    objetivosEnRangoNoVisibles.Add(objetivo);
            }
        }
    }
    public Vector3 DireccionDesdeAngulo(float gradosDelAngulo)
    {
        return new Vector2(Mathf.Sin(gradosDelAngulo * Mathf.Deg2Rad), Mathf.Cos(gradosDelAngulo * Mathf.Deg2Rad));
    }
}
