using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("¡Anotación!");
            // Aquí puedes agregar lógica adicional, como cargar la siguiente escena o mostrar un mensaje de victoria.
        }
    }
}
