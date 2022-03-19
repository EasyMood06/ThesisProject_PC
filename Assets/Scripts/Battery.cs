using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.remainTime >= 100f)
        {
            gameObject.transform.localScale = new Vector3(0.02f,0.02f,0.1f);
        }
        if(gameManager.remainTime <= 0f)
        {
            gameObject.transform.localScale = new Vector3(0.02f, 0.02f, 0f);
        }
        if(gameManager.remainTime>0f && gameManager.remainTime<100f)
        {
            float zScale = gameManager.remainTime / 100f;
            gameObject.transform.localScale = new Vector3(0.02f, 0.02f, 0.1f * zScale);
        }
    }
}
