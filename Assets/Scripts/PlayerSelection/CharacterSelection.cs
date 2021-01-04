﻿using Mirror;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : NetworkBehaviour
{
	public GameObject[] characters;
	public int selectedCharacter = 0;

	public void NextCharacter()
	{
		characters[selectedCharacter].SetActive(false);
		selectedCharacter = (selectedCharacter + 1) % characters.Length;
		characters[selectedCharacter].SetActive(true);
	}

	public void PreviousCharacter()
	{
		characters[selectedCharacter].SetActive(false);
		selectedCharacter--;
		if (selectedCharacter < 0)
		{
			selectedCharacter += characters.Length;
		}
		characters[selectedCharacter].SetActive(true);
	}

	public void StartGame()
	{
		//PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
		WaterFieldPlayer myPlayer = NetworkClient.connection.identity.GetComponent<WaterFieldPlayer>();

		myPlayer.TrySelectIndex(selectedCharacter);

		myPlayer.CmdStartWorldScene();
		//SceneManager.LoadScene(2, LoadSceneMode.Single);
	}
}
