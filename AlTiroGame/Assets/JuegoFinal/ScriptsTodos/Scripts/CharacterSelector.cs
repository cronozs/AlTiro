using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelector : MonoBehaviour
{
    public Character[] characters; // Referencia a los personajes.
    public Transform characterDisplayPosition; // Punto donde se muestra el modelo del personaje.
    public Text characterNameText; // Texto para el nombre del personaje.

    private int selectedIndex = 0; // Índice del personaje seleccionado.
    private GameObject currentCharacterModel; // Referencia al modelo actual mostrado.

    private void Start()
    {
        DisplayCharacter(selectedIndex);
    }

    public void NextCharacter()
    {
        selectedIndex = (selectedIndex + 1) % characters.Length;
        DisplayCharacter(selectedIndex);
    }

    public void PreviousCharacter()
    {
        selectedIndex = (selectedIndex - 1 + characters.Length) % characters.Length;
        DisplayCharacter(selectedIndex);
    }

    private void DisplayCharacter(int index)
    {
        // Destruye el modelo actual si existe.
        if (currentCharacterModel != null)
        {
            Destroy(currentCharacterModel);
        }

        // Instancia el nuevo modelo del personaje.
        Character character = characters[index];
        currentCharacterModel = Instantiate(character.characterModel, characterDisplayPosition.position, Quaternion.identity);
        currentCharacterModel.transform.rotation = Quaternion.Euler(0, 180, 0); // Ajusta la rotación según necesites.
        characterNameText.text = character.characterName;
    }

    public void ConfirmSelection(string player)
    {
        // Almacena la selección en PlayerPrefs o en un Singleton.
        if (player == "Player1")
        {
            PlayerPrefs.SetInt("Player1Index", selectedIndex);
        }
        else if (player == "Player2")
        {
            PlayerPrefs.SetInt("Player2Index", selectedIndex);
        }

        Debug.Log($"{player} selected: {characters[selectedIndex].characterName}");
    }
}
