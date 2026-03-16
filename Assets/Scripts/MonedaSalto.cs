using UnityEngine;
using System.Collections;

public class MonedaSalto : MonoBehaviour
{
    public float alturaMaxima = 1.5f; // Cuánto sube
    public float velocidad = 6f;      // Qué tan rápido
    public float tiempoAntesDeBorrar = 0.6f; // Cuánto dura visible

    void Start()
    {
        // Iniciamos el movimiento en cuanto aparece
        StartCoroutine(MoverMoneda());
    }

    IEnumerator MoverMoneda()
    {
        Vector3 posicionInicial = transform.position;
        Vector3 posicionFinal = posicionInicial + new Vector3(0, alturaMaxima, 0);

        // Subir
        float timer = 0;
        while (timer < 1)
        {
            transform.position = Vector3.Lerp(posicionInicial, posicionFinal, timer);
            timer += Time.deltaTime * velocidad;
            yield return null;
        }

        // Bajar un poquito (opcional, para efecto de gravedad)
        timer = 0;
        Vector3 posicionCaida = posicionFinal + new Vector3(0, -0.3f, 0);
        while (timer < 1)
        {
            transform.position = Vector3.Lerp(posicionFinal, posicionCaida, timer);
            timer += Time.deltaTime * (velocidad * 1.5f);
            yield return null;
        }

        // Esperar un instante y borrarse
        yield return new WaitForSeconds(tiempoAntesDeBorrar / 2f);
        Destroy(gameObject);
    }
}