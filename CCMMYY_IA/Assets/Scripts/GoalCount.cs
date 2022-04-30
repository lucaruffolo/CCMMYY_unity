using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalCount : MonoBehaviour
{
    public GameObject[] childsG;
    public bool[] arrivedOnGoal;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(transform.childCount);
        arrivedOnGoal = new bool[transform.childCount];
        for(int j = 0; j< arrivedOnGoal.Length; j++)
        {
            arrivedOnGoal[j] = false;
        }
        childsG = new GameObject[transform.childCount];
        int i = 0;
        foreach (Transform child in transform)
        {
            childsG[i] = child.gameObject;
            Debug.Log(childsG[i]);
            i++;
        }

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i<childsG.Length; i++) {
            if(childsG[i].GetComponent<GoalChekArrived>().arrived == true)
            {
                arrivedOnGoal[i] = true;
            }
            else
            {
                arrivedOnGoal[i] = false;
            }
        }

        if (finito())
        {
            Debug.Log("YEEEE");
        }

    }

    bool finito()
    {
        bool counter = true;
        for (int i = 0; i < arrivedOnGoal.Length; i++)
        {
            if (arrivedOnGoal[i] == false)
                counter = false;
        }
        if (counter)
            return true;
        else
            return false;
    }

        
}
