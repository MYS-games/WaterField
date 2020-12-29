using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelection : NetworkBehaviour
{
    [SerializeField] private GameObject[] characters;

    public int selectedCharacterIndex = 0;

    public void NextCharacter()
    {
        characters[selectedCharacterIndex].SetActive(false);
        selectedCharacterIndex = (selectedCharacterIndex + 1) % characters.Length;
        characters[selectedCharacterIndex].SetActive(true);
    }

    public void PreviousCharacter()
    {
        characters[selectedCharacterIndex].SetActive(false);
        selectedCharacterIndex--;

        if(selectedCharacterIndex < 0)
        {
            selectedCharacterIndex += characters.Length;
        }

        characters[selectedCharacterIndex].SetActive(true);
    }

    public void StartGame()
    {
        //TODO: somthing
    }


}
