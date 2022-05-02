using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckOtherBlock : MonoBehaviour
{
    public GameObject[] childblock;
    // Start is called before the first frame update
    void Start()
    {
        childblock = new GameObject[transform.childCount];
        int i = 0;
        foreach (Transform child in transform)
        {
            childblock[i] = child.gameObject;
            Debug.Log(childblock[i]);
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < childblock.Length; i++)
        {
            for (int j = 0; j < childblock.Length; j++)
            {
                if (j != i)
                {
                    //check sul blocco a destra
                    if (childblock[i].GetComponent<CheckPlayerClose>().movePointR.position == childblock[j].GetComponent<Transform>().position)
                    {
                        childblock[i].GetComponent<CheckPlayerClose>().haveBlockNearR = true;
                        childblock[j].GetComponent<CheckPlayerClose>().haveBlockNearL = true;
                        break;
                    }

                    //check sul blocco a sinistra
                    if (childblock[i].GetComponent<CheckPlayerClose>().movePointL.position == childblock[j].GetComponent<Transform>().position)
                    {
                        childblock[i].GetComponent<CheckPlayerClose>().haveBlockNearL = true;
                        childblock[j].GetComponent<CheckPlayerClose>().haveBlockNearR = true;
                        break;
                    }

                    //check sul blocco sopra
                    if (childblock[i].GetComponent<CheckPlayerClose>().movePointU.position == childblock[j].GetComponent<Transform>().position)
                    {
                        childblock[i].GetComponent<CheckPlayerClose>().haveBlockNearU = true;
                        childblock[j].GetComponent<CheckPlayerClose>().haveBlockNearD = true;
                        break;
                    }

                    //check sul blocco sotto
                    if (childblock[i].GetComponent<CheckPlayerClose>().movePointD.position == childblock[j].GetComponent<Transform>().position)
                    {
                        childblock[i].GetComponent<CheckPlayerClose>().haveBlockNearD = true;
                        childblock[j].GetComponent<CheckPlayerClose>().haveBlockNearU = true;
                        break;
                    }
                    /*else
                    {
                        childblock[i].GetComponent<CheckPlayerClose>().haveBlockNearR = false;
                        childblock[j].GetComponent<CheckPlayerClose>().haveBlockNearL = false;
                        childblock[i].GetComponent<CheckPlayerClose>().haveBlockNearL = false;
                        childblock[j].GetComponent<CheckPlayerClose>().haveBlockNearR = false;
                        childblock[i].GetComponent<CheckPlayerClose>().haveBlockNearU = false;
                        childblock[j].GetComponent<CheckPlayerClose>().haveBlockNearD = false;
                        childblock[i].GetComponent<CheckPlayerClose>().haveBlockNearD = false;
                        childblock[j].GetComponent<CheckPlayerClose>().haveBlockNearU = false;
                    }*/
                }
            }
        }
        

        /*
        for (int i = 0; i < childblock.Length; i++)
        {
            for (int j = 0; j < childblock.Length; j++)
            {
                if (j != i)
                {
                    //check sul blocco a sinistra
                    if (childblock[i].GetComponent<CheckPlayerClose>().movePointL.position == childblock[j].GetComponent<Transform>().position)
                    {
                        childblock[i].GetComponent<CheckPlayerClose>().haveBlockNearL = true;
                        childblock[j].GetComponent<CheckPlayerClose>().haveBlockNearR = true;
                        break;
                    }
                    /*else
                    {
                        childblock[i].GetComponent<CheckPlayerClose>().haveBlockNearL = false;
                        childblock[j].GetComponent<CheckPlayerClose>().haveBlockNearR = false;
                    }


                }
            }
        }

        
        for (int i = 0; i < childblock.Length; i++)
        {
            for (int j = 0; j < childblock.Length; j++)
            {
                if (j != i)
                {
                    //check sul blocco sopra
                    if (childblock[i].GetComponent<CheckPlayerClose>().movePointU.position == childblock[j].GetComponent<Transform>().position)
                    {
                        childblock[i].GetComponent<CheckPlayerClose>().haveBlockNearU = true;
                        childblock[j].GetComponent<CheckPlayerClose>().haveBlockNearD = true;
                        break;
                    }
                    /*else
                    {
                        childblock[i].GetComponent<CheckPlayerClose>().haveBlockNearU = false;
                        childblock[j].GetComponent<CheckPlayerClose>().haveBlockNearD = false;
                    }


                }
            }
        }

        for (int i = 0; i < childblock.Length; i++)
        {
            for (int j = 0; j < childblock.Length; j++)
            {
                if (j != i)
                {
                    //check sul blocco sotto
                    if (childblock[i].GetComponent<CheckPlayerClose>().movePointD.position == childblock[j].GetComponent<Transform>().position)
                    {
                        childblock[i].GetComponent<CheckPlayerClose>().haveBlockNearD = true;
                        childblock[j].GetComponent<CheckPlayerClose>().haveBlockNearU = true;
                        break;
                    }
                    /*else
                    {
                        childblock[i].GetComponent<CheckPlayerClose>().haveBlockNearD = false;
                        childblock[j].GetComponent<CheckPlayerClose>().haveBlockNearU = false;
                    }


                }
            }
        }
        /*
        Debug.Log("move to: "+GetComponent<CheckPlayerClose>().movePointR.position);
        Debug.Log("posizioni: "+GetComponent<Transform>().position);
        if (GetComponent<CheckPlayerClose>().movePointR.position == GetComponent<Transform>().position)
        {
            haveBlockNear = true;
        }
        else
            haveBlockNear = false;*/
    }
}
