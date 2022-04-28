using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayerClose : MonoBehaviour
{
    public GameObject player;
    public Transform movePointL;
    public Transform movePointR;
    public Transform movePointU;
    public Transform movePointD;
    public Transform goal;
    private bool stopPush = false;
    private int i = 0;
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
            stopPush = true;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (!stopPush) {
            Vector3 posizioneAttuale = player.GetComponent<Transform>().position;
            while (movePointL.position == posizioneAttuale) {
                Vector3 vec = new Vector3(transform.position.x + 1.0f, transform.position.y, transform.position.z);
                transform.position = vec;
                //print("collisione da sx -> dx ");
            }
            while (movePointR.position == posizioneAttuale) {
                Vector3 vec = new Vector3(transform.position.x - 1.0f, transform.position.y, transform.position.z);
                transform.position = vec;
                //print("collisione da dx <- sx ");
            }
            while (movePointU.position == posizioneAttuale) {
                Vector3 vec = new Vector3(transform.position.x, transform.position.y - 1.0f, transform.position.z);
                transform.position = vec;
                //print("collisione da Up \\/ giu ");
            }
            while (movePointD.position == posizioneAttuale) {
                Vector3 vec = new Vector3(transform.position.x, transform.position.y + 1.0f, transform.position.z);
                transform.position = vec;
                //print("collisione da giu /\\ up ");
            }
         //   print("collisione " + i);
            i++;
        }
    }
}
