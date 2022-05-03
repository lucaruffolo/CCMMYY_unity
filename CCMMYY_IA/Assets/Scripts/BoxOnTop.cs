using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxOnTop : MonoBehaviour
{
    public bool onTop = false;
    //public Transform pos;
    
    // Update is called once per frame
    void Update()
    {
        if (onTop) {
            Vector3 up = new Vector3(transform.position.x, transform.position.y, -2.0f);
            transform.position = up;
        } else {
            Vector3 down = new Vector3(transform.position.x, transform.position.y, 0);
            transform.position = down;
        }
    }
}
