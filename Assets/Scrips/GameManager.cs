using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("UI Component")]
    public TextMeshProUGUI textoPuntos;

    private int puntosTotales = 0;

    public void SumarPuntos(int cantidad)
    {
        puntosTotales += cantidad;
        textoPuntos.text = "Puntos: " + puntosTotales;
        Debug.Log("Puntos Totales: " + puntosTotales);
    }

    public void ReiniciarJuego()
    {
        Debug.Log("Reiniciando Juego...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("Juego Reiniciado");
    }
}
