using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CharacterSelector : MonoBehaviour
{
    [Header("Player 1")]
    public Character[] charactersPlayer1; // Referencia a los personajes para Player 1.
    public Transform displayPositionPlayer1; // Punto donde se muestra el modelo del personaje para Player 1.
    public TMP_Text nameTextPlayer1; // Texto para el nombre del personaje de Player 1.
    public Image characterImagePlayer1; // Imagen para mostrar el personaje de Player 1.

    [Header("Player 2")]
    public Character[] charactersPlayer2; // Referencia a los personajes para Player 2.
    public Transform displayPositionPlayer2; // Punto donde se muestra el modelo del personaje para Player 2.
    public TMP_Text nameTextPlayer2; // Texto para el nombre del personaje de Player 2.
    public Image characterImagePlayer2; // Imagen para mostrar el personaje de Player 2.

    private int selectedIndexPlayer1 = 0; // Índice del personaje seleccionado para Player 1.
    private int selectedIndexPlayer2 = 0; // Índice del personaje seleccionado para Player 2.
    private GameObject currentModelPlayer1; // Referencia al modelo actual mostrado para Player 1.
    private GameObject currentModelPlayer2; // Referencia al modelo actual mostrado para Player 2.

    private void Start()
    {
        // Inicializa la visualización de los personajes para ambos jugadores.
        DisplayCharacterPlayer1(selectedIndexPlayer1);
        DisplayCharacterPlayer2(selectedIndexPlayer2);
    }

    // Métodos para Player 1
    public void NextCharacterPlayer1()
    {
        selectedIndexPlayer1 = (selectedIndexPlayer1 + 1) % charactersPlayer1.Length;
        Debug.Log("Next Player 1: " + selectedIndexPlayer1);
        DisplayCharacterPlayer1(selectedIndexPlayer1);
    }

    public void PreviousCharacterPlayer1()
    {
        selectedIndexPlayer1 = (selectedIndexPlayer1 - 1 + charactersPlayer1.Length) % charactersPlayer1.Length;
        Debug.Log("Previous Player 1: " + selectedIndexPlayer1);
        DisplayCharacterPlayer1(selectedIndexPlayer1);
    }

    private void DisplayCharacterPlayer1(int index)
    {
        if (currentModelPlayer1 != null)
        {
            Destroy(currentModelPlayer1);
        }
        Character character = charactersPlayer1[index];
        currentModelPlayer1 = Instantiate(character.characterModel, displayPositionPlayer1.position, Quaternion.identity);
        currentModelPlayer1.transform.rotation = Quaternion.Euler(0, 180, 0);
        nameTextPlayer1.text = character.characterName;
    }

    // Métodos para Player 2
    public void NextCharacterPlayer2()
    {
        selectedIndexPlayer2 = (selectedIndexPlayer2 + 1) % charactersPlayer2.Length;
        Debug.Log("Next Player 2: " + selectedIndexPlayer2);
        DisplayCharacterPlayer2(selectedIndexPlayer2);
    }

    public void PreviousCharacterPlayer2()
    {
        selectedIndexPlayer2 = (selectedIndexPlayer2 - 1 + charactersPlayer2.Length) % charactersPlayer2.Length;
        Debug.Log("Previous Player 2: " + selectedIndexPlayer2);
        DisplayCharacterPlayer2(selectedIndexPlayer2);
    }

    private void DisplayCharacterPlayer2(int index)
    {
        if (currentModelPlayer2 != null)
        {
            Destroy(currentModelPlayer2);
        }
        Character character = charactersPlayer2[index];
        currentModelPlayer2 = Instantiate(character.characterModel, displayPositionPlayer2.position, Quaternion.identity);
        currentModelPlayer2.transform.rotation = Quaternion.Euler(0, 0, 0);
        nameTextPlayer2.text = character.characterName;
    }

    // Confirmar selección y cambiar de escena
    public void ConfirmSelectionAndPlay()
    {
        PlayerPrefs.SetInt("Player1Index", selectedIndexPlayer1);
        PlayerPrefs.SetInt("Player2Index", selectedIndexPlayer2);

        Debug.Log($"Player 1 selected: {charactersPlayer1[selectedIndexPlayer1].characterName}");
        Debug.Log($"Player 2 selected: {charactersPlayer2[selectedIndexPlayer2].characterName}");

        // Cambia de escena (ajusta el nombre de la escena según tu proyecto).
        SceneManager.LoadScene("Juego");
    }
}
