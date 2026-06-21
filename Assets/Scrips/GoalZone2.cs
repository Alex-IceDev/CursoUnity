using UnityEngine;

public class GoalZone2 : MonoBehaviour
{
    [Header("Configuración de Recompensa")]
    public GameObject monedaPrefab;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Balon"))
        {
            Debug.Log("¡Gol! Generando Monedas...");
            GenerarLluviaMonedas();
        }
    }

    void GenerarLluviaMonedas()
    {
        for (int i = 0; i < 10; i++)
        {
            Vector3 offsetAleatorio = new Vector3(
                Random.Range(-5f, 5f), 
                0.1f, 
                Random.Range(-5f, 5f)
            );

            Vector3 posicionSpawn = transform.position + offsetAleatorio;

            Instantiate(monedaPrefab, posicionSpawn, monedaPrefab.transform.rotation);
        }
    }
}
