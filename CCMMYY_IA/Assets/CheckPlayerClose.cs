using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CheckPlayerClose : MonoBehaviour
{
    public GameObject player;
    public Transform movePointL;
    public Transform movePointR;
    public Transform movePointU;
    public Transform movePointD;
    public Transform goal;
    //private bool stopPush = false;
    //private int i = 0;

    private bool affiancatoLeft = false;
    private bool affiancatoRight = false;
    private bool affiancatoUp = false;
    private bool affiancatoDown = false;
    
    public bool stopPlayerBlockOnWall = false;
    public Tilemap wall;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 posAttuale = transform.position;
        if (goal.transform.position == posAttuale) {
            Debug.Log("Stop Hai vinto Winner");
            //stopPush = true;
        }
        
        Vector3 posizioneAttualePlayer = player.GetComponent<Transform>().position;
        Vector3 posAttualeCubo = transform.position;
        if (movePointL.position == posizioneAttualePlayer)
            affiancatoLeft = true;
        else if(movePointL.position != posizioneAttualePlayer && posizioneAttualePlayer != posAttualeCubo)
            affiancatoLeft = false;

        if (movePointR.position == posizioneAttualePlayer)
            affiancatoRight = true;
        else if(movePointR.position != posizioneAttualePlayer && posizioneAttualePlayer != posAttualeCubo)
            affiancatoRight = false;

        if (movePointD.position == posizioneAttualePlayer)
            affiancatoDown = true;
        else if(movePointD.position != posizioneAttualePlayer && posizioneAttualePlayer != posAttualeCubo)
            affiancatoDown = false;


        if (movePointU.position == posizioneAttualePlayer)
            affiancatoUp = true;
        else if(movePointU.position != posizioneAttualePlayer && posizioneAttualePlayer != posAttualeCubo)
            affiancatoUp = false;

        Vector3Int obstacleMapRight = wall.WorldToCell(movePointR.position);
        if(wall.GetTile(obstacleMapRight) == null){
            if(posizioneAttualePlayer == posAttualeCubo && affiancatoLeft){
                Vector3 vec = new Vector3(transform.position.x + 1.0f, transform.position.y, transform.position.z);
                transform.position = vec;
                //print("collisione da sx -> dx ");
            }
        }

        Vector3Int obstacleMapLeft = wall.WorldToCell(movePointL.position);
        if(wall.GetTile(obstacleMapLeft) == null){
            if(posizioneAttualePlayer == posAttualeCubo && affiancatoRight){
                Vector3 vec = new Vector3(transform.position.x - 1.0f, transform.position.y, transform.position.z);
                transform.position = vec;
                //print("collisione da dx <- sx ");
            }
        }

        Vector3Int obstacleMapUp = wall.WorldToCell(movePointU.position);
        if(wall.GetTile(obstacleMapUp) == null){
            if(posizioneAttualePlayer == posAttualeCubo && affiancatoDown){
                Vector3 vec = new Vector3(transform.position.x, transform.position.y + 1.0f, transform.position.z);
                transform.position = vec;
                //print("collisione da giu /\\ up ");
            }
        }

        Vector3Int obstacleMapDown = wall.WorldToCell(movePointD.position);
        if(wall.GetTile(obstacleMapDown) == null){
            if(posizioneAttualePlayer == posAttualeCubo && affiancatoUp){
                Vector3 vec = new Vector3(transform.position.x, transform.position.y - 1.0f, transform.position.z);
                transform.position = vec;
                //print("collisione da Up \\/ giu ");
            }
        }
    }


    /*if(posizioneAttualePlayer == posAttualeCubo && affiancatoLeft){
            Vector3 vec = new Vector3(transform.position.x + 1.0f, transform.position.y, transform.position.z);
            transform.position = vec;
            //print("collisione da sx -> dx ");
        }
        if(posizioneAttualePlayer == posAttualeCubo && affiancatoRight){
            Vector3 vec = new Vector3(transform.position.x - 1.0f, transform.position.y, transform.position.z);
            transform.position = vec;
            //print("collisione da dx <- sx ");
        }
        if(posizioneAttualePlayer == posAttualeCubo && affiancatoUp){
            Vector3 vec = new Vector3(transform.position.x, transform.position.y - 1.0f, transform.position.z);
                transform.position = vec;
                //print("collisione da Up \\/ giu ");
        }
        if(posizioneAttualePlayer == posAttualeCubo && affiancatoDown){
            Vector3 vec = new Vector3(transform.position.x, transform.position.y + 1.0f, transform.position.z);
                transform.position = vec;
                //print("collisione da giu /\\ up ");
        }*/

    /*private void OnCollisionEnter2D(Collision2D collision) {
        //if (!stopPush) {
            Vector3 posAttualeCubo = transform.position;
            Vector3 posizioneAttualePlayer = player.GetComponent<Transform>().position;
            
            
            while (movePointL.position == posizioneAttualePlayer) {
                Vector3 vec = new Vector3(transform.position.x + 1.0f, transform.position.y, transform.position.z);
                transform.position = vec;
                //print("collisione da sx -> dx ");
            }
            while (movePointR.position == posizioneAttualePlayer) {
                Vector3 vec = new Vector3(transform.position.x - 1.0f, transform.position.y, transform.position.z);
                transform.position = vec;
                //print("collisione da dx <- sx ");
            }
            while (movePointU.position == posizioneAttualePlayer) {
                Vector3 vec = new Vector3(transform.position.x, transform.position.y - 1.0f, transform.position.z);
                transform.position = vec;
                //print("collisione da Up \\/ giu ");
            }
            while (movePointD.position == posizioneAttualePlayer) {
                Vector3 vec = new Vector3(transform.position.x, transform.position.y + 1.0f, transform.position.z);
                transform.position = vec;
                //print("collisione da giu /\\ up ");
            }
         //   print("collisione " + i);
            i++;
       // }
    }*/
}
