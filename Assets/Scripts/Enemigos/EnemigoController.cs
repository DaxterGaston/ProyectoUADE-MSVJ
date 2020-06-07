using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoController : MonoBehaviour
{
    private float velocidad = 3f;
    private Vector2 direccion;
    private float radioCirculo = 3f;
    private ConoDeVision cv;
    // Start is called before the first frame update
    void Start()
    {
        cv = GetComponent<ConoDeVision>();
        //direccion = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
    }

    // Update is called once per frame
    void Update()
    {
        Physics.OverlapSphere(transform.position, radioCirculo);
        //transform.position += (Vector3)direccion * velocidad * Time.deltaTime;
        cv.EncontrarObjetivosVisibles();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Me voy para el lado contrario al chocar contra una pared.
        if (collision.contacts[0].collider.CompareTag("Pared"))
        {
            direccion = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        }
        if (collision.contacts[0].collider.CompareTag("Proyectil"))
        {
            Destroy(gameObject);
        }
    }
}
