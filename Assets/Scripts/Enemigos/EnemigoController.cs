using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoController : MonoBehaviour
{
    private float velocidad = 3f;
    private Vector2 direccion;
    // Start is called before the first frame update
    void Start()
    {
        direccion = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)direccion * velocidad * Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].collider.tag == "Pared")
        {
            direccion = -direccion;
        }
        if (collision.contacts[0].collider.tag == "Proyectil")
        {
            Destroy(gameObject);
        }
    }
}
