using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    public bool isBlock = false;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Block")
        {
            isBlock = true;
        }
    }
}
