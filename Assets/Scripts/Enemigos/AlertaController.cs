using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AlertaController : MonoBehaviour
{
    [SerializeField]
    private GameObject enemigo;
    private ConoDeVision cv;
    SpriteRenderer sprite;
    Sprite alerta;
    Sprite encontrado;
    // Start is called before the first frame update
    void Start()
    {
        cv = enemigo.GetComponent<ConoDeVision>();
        sprite = GetComponent<SpriteRenderer>();
        alerta = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Sprites/Enemigos/Alertas/signo_pregunta.png", typeof(Sprite));
        encontrado = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Sprites/Enemigos/Alertas/signo_exclamacion.png", typeof(Sprite));
    }

    void Update()
    {
        //Al ser solo 1 posible objetivo(el jugador), nunca van a tener las 2 listas a la vez con objetos.
        //Lo modifico aca para dejar el cono de vision lo mas generico posible en caso de necesitarlo en otra situacion.
        sprite.sprite = null;
        if (cv.objetivosEnRangoNoVisibles.Count > 0)
            sprite.sprite = alerta;
        if (cv.objetivosVisibles.Count > 0)
            sprite.sprite = encontrado;
    }
}
