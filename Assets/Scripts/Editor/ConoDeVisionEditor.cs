using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ConoDeVision))]
public class ConoDeVisionEditor : Editor
{
    private void OnSceneGUI()
    {
        ConoDeVision cv = (ConoDeVision)target;
        Handles.color = Color.white;
        Vector3 normal = cv.transform.position;
        normal -= new Vector3(normal.x, normal.y, normal.z - 10);
        //Dibujo lo que seria el circulo dentro del cual puedo captar las colisiones y ver al jugador.
        Handles.DrawWireArc(cv.transform.position, normal, Vector2.up, 360, cv.radio);

        //Vectores limites del cono
        Vector2 vectorAnguloA = cv.DireccionDesdeAngulo(-cv.angulo / 2);
        Vector2 vectorAnguloB = cv.DireccionDesdeAngulo(cv.angulo / 2);

        Handles.DrawLine(cv.transform.position, cv.transform.position + (Vector3)vectorAnguloA * cv.radio);
        Handles.DrawLine(cv.transform.position, cv.transform.position + (Vector3)vectorAnguloB * cv.radio);

        Handles.color = Color.blue;
        foreach (Transform objetivo in cv.objetivosVisibles)
        {
            Handles.DrawLine(cv.transform.position, objetivo.transform.position);
        }

        //Normal que necesito en 2D
        Debug.DrawRay(cv.transform.position, normal, Color.red);
    }
}
