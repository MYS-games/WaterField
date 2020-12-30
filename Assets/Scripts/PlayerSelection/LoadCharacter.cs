﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadCharacter : MonoBehaviour
{
	public GameObject[] characterPrefabs;
	public Transform spawnPoint;
	//public TMP_Text label;

	void Start()
	{
		int selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
		Debug.Log(selectedCharacter);
		GameObject prefab = characterPrefabs[selectedCharacter];
		Debug.Log(characterPrefabs[selectedCharacter].ToString());
		GameObject clone = Instantiate(prefab, spawnPoint.position, Quaternion.identity);

		//label.text = prefab.name;
	}
}
