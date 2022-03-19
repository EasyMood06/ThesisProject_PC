using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float gameTime;
    public float remainTime;
    public int ItemCollectionTimes;
    public int CollisionTimes;
    public float maximumSpeed;
    public float TravelDistance;

    Controller controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = FindObjectOfType<Controller>();
        gameTime = 0f;
        remainTime = 100f;
        ItemCollectionTimes = 0;
        CollisionTimes = 0;
        maximumSpeed = 0f;
        TravelDistance = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(controller.isControllable == false)
            return;
        gameTime += Time.deltaTime;
        remainTime -= Time.deltaTime;
        if(remainTime <= 0)
        {
            // game over
            // players cannot control anything
            // display all the game data for players
            controller.isControllable = false;
            GameOverDataPrint();
            
        }
    }

    void GameOverDataPrint()
    {
        print("Game total time is " + gameTime);
        print("Item collection times is " + ItemCollectionTimes);
        print("Collision times is " + CollisionTimes);
        maximumSpeed = controller.GetPlayerMaxSpeed();
        TravelDistance = controller.ComputeTravelDistance();
        print("Maximum speed is " + maximumSpeed);
        print("Travel distance is " + TravelDistance);
    }
}
