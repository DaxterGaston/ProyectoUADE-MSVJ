using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscenarioController : MonoBehaviour
{
    [SerializeField]
    private GameObject InstanciaJugador;
    [SerializeField]
    private Camera CamaraPrincipal;
    private static int EscenaActual;
    private Reposicionamiento EscenaCamara;
    private JugadorAtaqueController jugador;
    private bool YaUtilizado = false;
    private void Awake()
    {
        EscenaActual = 1;
        jugador = InstanciaJugador.GetComponent<JugadorAtaqueController>();
        EscenaCamara = CamaraPrincipal.GetComponent<Reposicionamiento>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].collider.gameObject.CompareTag("Jugador") && !YaUtilizado)
        {
            if (gameObject.CompareTag("FinalNivel"))
            {
                SceneManager.LoadScene("Ganaste");
            }
            YaUtilizado = true;
            EscenaActual += 1;
            EscenaCamara.CambiarEscenario(EscenaActual);
            jugador.CambiarEscenario(EscenaActual);
        }
    }

    
}
