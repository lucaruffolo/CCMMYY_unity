using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public bool canMove = false;
    public bool onTop = false;
    public Transform movePoint;
    public LayerMask whatStopsMovement;
    public GameObject[] block;


    void Start()
    {
        movePoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        //block.GetComponent<CheckPlayerClose>().BlockOnWallRight;
        //Debug.Log(block.GetComponent<CheckPlayerClose>().BlockOnWallDown);

        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
        if (onTop) {
            Vector3 up = new Vector3(movePoint.position.x, movePoint.position.y, -2.0f);
            movePoint.position = up;
        } else {
            Vector3 down = new Vector3(movePoint.position.x, movePoint.position.y, 0);
            movePoint.position = down;
        }

        if (Vector3.Distance(transform.position, movePoint.position) <= .05f && canMove) {
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f) {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, whatStopsMovement)) {
                    Vector3 prossimoMove = movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                    //Debug.Log(block.GetComponent<Transform>().position);
                    if(Input.GetAxisRaw("Horizontal") == 1)
                    {
                        for (int i = 0; i < block.Length; i++)
                        {
                            if (prossimoMove == block[i].GetComponent<Transform>().position && (block[i].GetComponent<CheckPlayerClose>().BlockOnWallRight == true || block[i].GetComponent<CheckPlayerClose>().BlockOnWallLeft == true || block[i].GetComponent<CheckPlayerClose>().haveBlockNearR == true))
                            {
                                //blocco collisione del player con il blocco che sta al muro
                            }
                            else
                                movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                        }
                    }
                    if(Input.GetAxisRaw("Horizontal") == -1)
                    {
                        for (int i = 0; i < block.Length; i++)
                        {
                            if (prossimoMove == block[i].GetComponent<Transform>().position && (block[i].GetComponent<CheckPlayerClose>().BlockOnWallRight == true || block[i].GetComponent<CheckPlayerClose>().BlockOnWallLeft == true || block[i].GetComponent<CheckPlayerClose>().haveBlockNearL == true))
                            {
                                //blocco collisione del player con il blocco che sta al muro
                            }
                            else
                                movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                        }
                    }
                }
            }
            if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f) {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), .2f, whatStopsMovement)) {
                    Vector3 prossimoMove = movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                    //Debug.Log(Input.GetAxisRaw("Vertical"));
                    if(Input.GetAxisRaw("Vertical") == 1)
                    {
                        for (int i = 0; i < block.Length; i++)
                        {
                            if (prossimoMove == block[i].GetComponent<Transform>().position && (block[i].GetComponent<CheckPlayerClose>().BlockOnWallUp == true || block[i].GetComponent<CheckPlayerClose>().BlockOnWallDown == true || block[i].GetComponent<CheckPlayerClose>().haveBlockNearU == true))
                            {
                                //blocco collisione del player con il blocco che sta al muro
                            }
                            else
                                movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                        }
                    }
                    if(Input.GetAxisRaw("Vertical") == -1)
                    {
                        for (int i = 0; i < block.Length; i++)
                        {
                            if (prossimoMove == block[i].GetComponent<Transform>().position && (block[i].GetComponent<CheckPlayerClose>().BlockOnWallUp == true || block[i].GetComponent<CheckPlayerClose>().BlockOnWallDown == true || block[i].GetComponent<CheckPlayerClose>().haveBlockNearD == true))
                            {
                                //blocco collisione del player con il blocco che sta al muro
                            }
                            else
                                movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                        }
                    }
                }
            }
        }
    }
}
