using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPlayer : MonoBehaviour
{
    public GameObject[] players;
    private int index = 0;
    [SerializeField] public GameObject CurrentPlayer;
 
    void Start()
    {
        for (int i = 0; i < players.Length; i++) {
            DisableMove(players[i]);
        }
        CurrentPlayer = players[0];
        EnableMove(CurrentPlayer);

    }

    void Update()
    {
        if (Input.GetKeyDown("space")) {
            //Debug.Log("Switch Player");
            DisableMove(players[index]);
            index++;
            if (index > 2)
                index = 0;
            EnableMove(players[index]);
        }
        CurrentPlayer = players[index];
    }

    public void DisableMove(GameObject Player) {
        Player.GetComponent<PlayerController>().canMove = false;
        Player.GetComponent<PlayerController>().onTop = false;
    }

    public void EnableMove(GameObject Player) {
        Player.GetComponent<PlayerController>().canMove = true;
        Player.GetComponent<PlayerController>().onTop = true;

    }
}
