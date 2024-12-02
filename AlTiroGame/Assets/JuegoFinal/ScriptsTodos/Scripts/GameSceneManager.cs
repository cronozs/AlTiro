using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneManager : MonoBehaviour
{
    public Character[] characters; // Mismo orden que en la escena de selección.
    public Transform player1SpawnPoint;
    public Transform player2SpawnPoint;

    private void Start()
    {
        // Carga las selecciones de los jugadores.
        int player1Index = PlayerPrefs.GetInt("Player1Index", 0);
        int player2Index = PlayerPrefs.GetInt("Player2Index", 0);

        // Instancia los personajes seleccionados.
        Instantiate(characters[player1Index].characterModel, player1SpawnPoint.position, Quaternion.identity);
        Instantiate(characters[player2Index].characterModel, player2SpawnPoint.position, Quaternion.identity);
    }
}
