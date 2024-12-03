using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSceneManager : MonoBehaviour
{
    public Character[] characters; // Lista de personajes.
    public Transform player1SpawnPoint;
    public Transform player2SpawnPoint;

    public Image player1HealthBar;
    public Image player2HealthBar;

    public Camera player1Camera;  // Cámara de Player 1.
    public Camera player2Camera;  // Cámara de Player 2.

    public GameObject player1WinPanel;  // Panel de ganador de Player 1
    public GameObject player2WinPanel;  // Panel de ganador de Player 2

    public string nextSceneName = "NextScene"; // Nombre de la escena a cargar

    void Start()
    {
        player1WinPanel.SetActive(false);
        player2WinPanel.SetActive(false);
        int player1Index = PlayerPrefs.GetInt("Player1Index", 0);
        int player2Index = PlayerPrefs.GetInt("Player2Index", 0);

        // Instancia y configura Player 1.
        GameObject player1 = Instantiate(characters[player1Index].characterModel, player1SpawnPoint.position, Quaternion.identity);
        player1.tag = "Player1";
        player1.GetComponent<MovePlayer2>().SetControls("Player1");  // Asignamos los controles para Player 1
        AssignHealthBar(player1, player1HealthBar);
        ConfigureShooting(player1, "Vertical", 1f); // Configuración para Player 1.
        player1.transform.rotation = Quaternion.Euler(0, 90, 0);

        // Hacer que la cámara de Player 1 sea hija de Player 1.
        player1Camera.transform.SetParent(player1.transform);
        // Asignar el evento de muerte para Player 1
        VidaCharacters vidaPlayer1 = player1.GetComponent<VidaCharacters>();
        if (vidaPlayer1 != null)
        {
            vidaPlayer1.PlayerDied += () => ShowWinnerPanel(2); // Si Player 1 muere, muestra el panel de Player 2
        }

        // Instancia y configura Player 2.
        GameObject player2 = Instantiate(characters[player2Index].characterModel, player2SpawnPoint.position, Quaternion.identity);
        player2.tag = "Player2";
        player2.GetComponent<MovePlayer2>().SetControls("Player2");  // Asignamos los controles para Player 2
        AssignHealthBar(player2, player2HealthBar);
        ConfigureShooting(player2, "VerticalKey", -1f); // Configuración para Player 2.
        player2.transform.rotation = Quaternion.Euler(0, -90, 0);

        // Hacer que la cámara de Player 2 sea hija de Player 2.
        player2Camera.transform.SetParent(player2.transform);
        // Asignar el evento de muerte para Player 2
        VidaCharacters vidaPlayer2 = player2.GetComponent<VidaCharacters>();
        if (vidaPlayer2 != null)
        {
            vidaPlayer2.PlayerDied += () => ShowWinnerPanel(1); // Si Player 2 muere, muestra el panel de Player 1
        }
    }

    void AssignHealthBar(GameObject player, Image healthBar)
    {
        VidaCharacters vida = player.GetComponent<VidaCharacters>();
        if (vida != null)
        {
            vida.SetHealthBar(healthBar);
        }
    }

    void ConfigureShooting(GameObject player, string inputAxis, float direction)
    {
        Gun shootScript = player.GetComponent<Gun>();
        if (shootScript != null)
        {
            shootScript.ConfigureShooting(inputAxis, direction);
        }
    }

    void ShowWinnerPanel(int winner)
    {
        if (winner == 1)
        {
            player1WinPanel.SetActive(true); // Activa el panel de ganador de Player 1
            player2WinPanel.SetActive(false); // Desactiva el panel de ganador de Player 2
        }
        else if (winner == 2)
        {
            player2WinPanel.SetActive(true); // Activa el panel de ganador de Player 2
            player1WinPanel.SetActive(false); // Desactiva el panel de ganador de Player 1
        }
        // Inicia la corutina para cambiar de escena después de 10 segundos.
        StartCoroutine(ChangeSceneAfterDelay(7f));
    }

    // Corutina que espera un tiempo y luego cambia de escena.
    IEnumerator ChangeSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);  // Espera el tiempo especificado

        // Cambia de escena
        SceneManager.LoadScene(nextSceneName);
    }
}
