using UnityEngine;

public class EnemigoController : MonoBehaviour
{
    private float velocidad = 8f;
    private Vector2 direccion;
    private float radioCirculo = 3f;
    private ConoDeVision cv;
    private bool jugadorEncontrado;
    [SerializeField]
    private DireccionCono direccionVision;
    void Start()
    {
        Physics2D.IgnoreLayerCollision(9, 9);
        cv = GetComponent<ConoDeVision>();
        cv.direccionEnum = direccionVision;
        if (direccionVision == DireccionCono.Abajo)
        {
            GetComponent<Animator>().SetBool("MirandoAbajo", true);   
        }
    }

    void Update()
    {
        if (jugadorEncontrado)
        {
            transform.position += (Vector3)direccion * velocidad * Time.deltaTime; ;
        }
        else
        { 
            Physics.OverlapSphere(transform.position, radioCirculo);
            cv.EncontrarObjetivosVisibles(direccionVision);
            foreach (Transform item in cv.objetivosVisibles)
            {
                if (item.CompareTag("Jugador"))
                {
                    item.GetComponent<JugadorAtaqueController>().movimiento = false;
                    direccion = ((Vector2)item.position - (Vector2)transform.position).normalized;
                    jugadorEncontrado = true;
                }
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Me voy para el lado contrario al chocar contra una pared.
        if (collision.contacts[0].collider.CompareTag("Jugador"))
        {
            Destroy(collision.contacts[0].collider.gameObject);
            Camera.main.GetComponent<CambioEscenaController>().Perdiste();
        }
        if (collision.contacts[0].collider.CompareTag("Proyectil"))
        {
            Destroy(gameObject);
        }
    }

}
