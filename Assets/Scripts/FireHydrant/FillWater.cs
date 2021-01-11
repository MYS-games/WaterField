using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FillWater : MonoBehaviour
{
    [SerializeField] int maxQuantity = 15;
    [SerializeField] private float timeBetweenFill = 80f;
    private float timer = 0.0f;
    Player[] players;

    // Start is called before the first frame update
    void Start()
    {
       players = FindObjectsOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (players.Length == 0)
        {
            players = FindObjectsOfType<Player>();
        }
        foreach (Player player in players)
        {
            if (player == null) { return; }
            if (Vector3.Distance(player.transform.position, transform.position) < 8)
            {
                timer += Time.deltaTime;
                if (timer > timeBetweenFill)
                {
                    timer = 0f;
                    Fill(player);
                }
            }
        }
    }

    private void Fill(Player player)
    {
        int oldShots = player.GetShotsLeft();
        if (oldShots != maxQuantity)
        {
            player.SetShotsLeft(++oldShots);
        }
    }
}