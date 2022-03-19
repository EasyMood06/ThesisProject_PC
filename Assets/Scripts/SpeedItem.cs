using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedItem : MonoBehaviour
{
    GameManager gameManager;
    Controller controller;
    public AudioClip speedUp;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        controller = FindObjectOfType<Controller>();
    }

    // when players trigger speed item
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            controller.speed += 2f;
            controller.maxSpeed += 2.5f;

            gameManager.ItemCollectionTimes++;

            // audio
            gameObject.GetComponent<AudioSource>().Play();

            Destroy(gameObject, 2f);
        }
    }
}
