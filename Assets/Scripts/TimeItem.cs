using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeItem : MonoBehaviour
{
    GameManager gameManager;
    public AudioClip getCoin;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // players will get 10 bonus time, when trigger item
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            // find game manager, remain time += 10
            gameManager.remainTime += 3f;
            gameManager.ItemCollectionTimes++;

            // play audio
            gameObject.GetComponent<AudioSource>().PlayOneShot(getCoin);
            Destroy(gameObject, 2f);
        }
    }
}
