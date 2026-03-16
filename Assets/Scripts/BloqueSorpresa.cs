using UnityEngine;

public class BloqueSorpresa : MonoBehaviour
{
    public GameObject monedaPrefab;
    public int cantidadMonedas = 5;
    private bool bloqueAgotado = false;
    private AudioSource fuenteAudio; // Variable para el sonido

    void Start()
    {
        // Obtenemos el componente AudioSource que agregamos en el bloque
        fuenteAudio = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !bloqueAgotado)
        {
            foreach (ContactPoint2D punto in collision.contacts)
            {
                if (punto.normal.y > 0.5f)
                {
                    SoltarMoneda();
                }
            }
        }
    }

    void SoltarMoneda()
    {
        // Reproducir el sonido si existe
        if (fuenteAudio != null)
        {
            fuenteAudio.Play();
        }

        Vector3 posicionMoneda = transform.position + new Vector3(0, 1.0f, 0);
        Instantiate(monedaPrefab, posicionMoneda, Quaternion.identity);

        cantidadMonedas--;

        if (cantidadMonedas <= 0)
        {
            bloqueAgotado = true;
            GetComponent<SpriteRenderer>().color = Color.gray;
        }
    }
}