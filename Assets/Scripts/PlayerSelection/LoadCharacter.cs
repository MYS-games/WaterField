using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Mirror;

public class LoadCharacter : NetworkBehaviour
{
	public GameObject[] characterPrefabs;
	public Transform spawnPoint;
    //public TMP_Text label;

    void Start()
    {
        //int selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");

        WaterFieldPlayer myPlayer = FindObjectOfType<WaterFieldPlayer>();
        Debug.Log("after myPlayer");

        int selectedCharacter = myPlayer.GetSelectedPlayerIndex();
        Debug.Log("after selection	");
        //GameObject prefab = characterPrefabs[selectedCharacter];
        //GameObject clone = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
        //label.text = prefab.name;
    }
}
