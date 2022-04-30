using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchPlayer : MonoBehaviour
{
    public GameObject[] players;
    public GameObject[] boxs;
    public GameObject[] eyes;
    private int index = 0;
    [SerializeField] public GameObject CurrentPlayer;
    [SerializeField] public GameObject CurrentBox;

    void Start()
    {
        for (int i = 0; i < players.Length; i++) {
            DisableMove(players[i], boxs[i], eyes[i]);
        }
        CurrentPlayer = players[0];
        CurrentBox = boxs[0];
        
        EnableMove(CurrentPlayer, CurrentBox, eyes[0]);

    }

    void Update()
    {
        if (Input.GetKeyDown("escape")) {
            SceneManager.LoadScene(0); // Da rivedere se viene gestito con un menu di pausa ripristino livello corrente!
        }

        if (Input.GetKeyDown("space")) {
            Debug.Log("Switch Player");
            DisableMove(players[index], boxs[index], eyes[index]);
            index++;
            if (index > 2)
                index = 0;
            EnableMove(players[index], boxs[index], eyes[index]);
        }
        CurrentPlayer = players[index];
    }


    public void DisableMove(GameObject Player, GameObject box, GameObject eye) {
        Player.GetComponent<PlayerController>().canMove = false;
        Player.GetComponent<PlayerController>().onTop = false;
        box.GetComponent<BoxOnTop>().onTop = false;
        eye.GetComponent<SpriteRenderer>().enabled = false;
    }

    public void EnableMove(GameObject Player, GameObject box, GameObject eye) {
        Player.GetComponent<PlayerController>().canMove = true;
        Player.GetComponent<PlayerController>().onTop = true;
        box.GetComponent<BoxOnTop>().onTop = true;
        eye.GetComponent<SpriteRenderer>().enabled = true;
    }
}
