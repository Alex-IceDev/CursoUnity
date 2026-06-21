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
        textoPuntos.text = "Puntos: " + puntosTotales.ToString();
        Debug.Log("Puntos Totales: " + puntosTotales);
    }

    public void ReiniciarJuego()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
