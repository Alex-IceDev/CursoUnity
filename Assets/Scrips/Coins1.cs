using UnityEngine;

public class Coins1 : MonoBehaviour
{
    [Header("Configuración de Recompensa")]
    public GameObject monedaPrefab;

    [Header("Cantidad Monedas")]
    public int cantidadMonedas = 5;

    [Header("Rango de Posición X")]
    public float rangoX = 5f;

    [Header("Rango de Posición Y")]
    public float rangoY = -0.5f;

    [Header("Rango de Posición Z")]
    public float rangoZ = 5f;

    private bool monedasGeneradas = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !monedasGeneradas)
        {
            Debug.Log("Generando Monedas...");
            GenerarMonedas();
            monedasGeneradas = true;
        }
    }

    void GenerarMonedas()
    {
        for (int i = 0; i < cantidadMonedas; i++)
        {
            Vector3 offsetAleatorio = new Vector3(
                Random.Range(0f, rangoX),
                rangoY,
                Random.Range(0f, rangoZ)
            );
            Vector3 posicionSpawn = transform.position + offsetAleatorio;
            Instantiate(monedaPrefab, posicionSpawn, monedaPrefab.transform.rotation);
        }
    }
}
