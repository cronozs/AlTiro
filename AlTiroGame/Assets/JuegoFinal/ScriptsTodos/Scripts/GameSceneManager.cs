using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSceneManager : MonoBehaviour
{
    public Character[] characters; // Lista de personajes.
    public Transform player1SpawnPoint;
    public Transform player2SpawnPoint;

    public Image player1HealthBar;
    public Image player2HealthBar;

    void Start()
    {
        int player1Index = PlayerPrefs.GetInt("Player1Index", 0);
        int player2Index = PlayerPrefs.GetInt("Player2Index", 0);

        // Instancia y configura Player 1.
        GameObject player1 = Instantiate(characters[player1Index].characterModel, player1SpawnPoint.position, Quaternion.identity);
        player1.tag = "Player1";
        player1.GetComponent<MovePlayer2>().SetControls("Player1");  // Asignamos los controles para Player 1
        AssignHealthBar(player1, player1HealthBar);
        ConfigureShooting(player1, "Vertical", 1f); // Configuración para Player 1.
        player1.transform.rotation = Quaternion.Euler(0, 90, 0);

        // Instancia y configura Player 2.
        GameObject player2 = Instantiate(characters[player2Index].characterModel, player2SpawnPoint.position, Quaternion.identity);
        player2.tag = "Player2";
        player2.GetComponent<MovePlayer2>().SetControls("Player2");  // Asignamos los controles para Player 2
        AssignHealthBar(player2, player2HealthBar);
        ConfigureShooting(player2, "VerticalKey", -1f); // Configuración para Player 2.
        player2.transform.rotation = Quaternion.Euler(0, -90, 0);
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
}
