using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ConoDeVision))]
public class ConoDeVisionEditor : Editor
{
    private Vector2 direccionVision;

    private void OnSceneGUI()
    {
        ConoDeVision cv = (ConoDeVision)target;
        direccionVision = cv.ObtenerVectorDireccional(cv.direccionEnum);
        Handles.color = Color.white;
        Vector3 normal = cv.transform.position;
        normal -= new Vector3(normal.x, normal.y, normal.z - 10);
        //Dibujo lo que seria el circulo dentro del cual puedo captar las colisiones y ver al jugador.
        Handles.DrawWireArc(cv.transform.position, normal, Vector2.up, 360, cv.radio);

        DibujarLineasCono(cv);

        foreach (Transform objetivo in cv.objetivosVisibles)
        {
            Handles.color = Color.blue;
            Handles.DrawLine(cv.transform.position, objetivo.transform.position);
        }
        foreach (Transform objetivo in cv.objetivosEnRangoNoVisibles)
        {
            Handles.color = Color.red;
            Handles.DrawLine(cv.transform.position, objetivo.transform.position);
        }


        //Normal que necesito en 2D
        Debug.DrawRay(cv.transform.position, normal, Color.red);
    }

    private void DibujarLineasCono(ConoDeVision cv)
    {
        //Vectores limites del cono
        Vector2 vectorAnguloA = cv.DireccionDesdeAngulo(-cv.angulo / 2);
        Vector2 vectorAnguloB = cv.DireccionDesdeAngulo(cv.angulo / 2);
        if (direccionVision == Vector2.down)
        {
            Handles.DrawLine(cv.transform.position, cv.transform.position - (Vector3)vectorAnguloA * cv.radio);
            Handles.DrawLine(cv.transform.position, cv.transform.position - (Vector3)vectorAnguloB * cv.radio);
        }
        if (direccionVision == Vector2.up)
        {
            Handles.DrawLine(cv.transform.position, cv.transform.position + (Vector3)vectorAnguloA * cv.radio);
            Handles.DrawLine(cv.transform.position, cv.transform.position + (Vector3)vectorAnguloB * cv.radio);
        }
    }
}
