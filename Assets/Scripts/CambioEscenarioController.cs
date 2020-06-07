using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioEscenarioController : MonoBehaviour
{
    [SerializeField]
    private GameObject InstanciaJugador;
    [SerializeField]
    private Camera CamaraPrincipal;
    private static int EscenaActual = 1;
    private Reposicionamiento EscenaCamara;
    private JugadorAtaqueController jugador;
    private void Awake()
    {
        jugador = InstanciaJugador.GetComponent<JugadorAtaqueController>();
        EscenaCamara = CamaraPrincipal.GetComponent<Reposicionamiento>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].collider.gameObject.CompareTag("Jugador"))
        {
            EscenaActual += 1;
            EscenaCamara.CambiarEscenario(EscenaActual);
            jugador.CambiarEscenario(EscenaActual);
        }
    }
}
