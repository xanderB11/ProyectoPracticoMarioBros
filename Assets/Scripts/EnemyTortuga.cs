using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float velocidad = 2f;
    private int direccion = -1;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Movimiento constante
        rb.linearVelocity = new Vector2(direccion * velocidad, rb.linearVelocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Revisar cada punto de contacto
        foreach (ContactPoint2D contacto in collision.contacts)
        {
            // Si la colisión viene de lado (pared)
            if (Mathf.Abs(contacto.normal.x) > 0.5f)
            {
                Girar();
                break;
            }
        }
    }

    void Girar()
    {
        direccion *= -1;

        // Voltear sprite
        Vector3 escala = transform.localScale;
        escala.x = Mathf.Abs(escala.x) * direccion;
        transform.localScale = escala;
    }
}