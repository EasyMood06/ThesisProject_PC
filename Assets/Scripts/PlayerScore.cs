using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    public GameObject GameTime;
    public GameObject ItemCollectionTime;
    public GameObject CollisionTime;
    public GameObject MaxSpeed;
    public GameObject TravelDistance;

    public void DisplayPlayerScore(float gameTime, int itemCollectionTimes, int collisionTimes, float maximumSpeed, float travelDistance)
    {
        GameTime.GetComponent<Text>().text = "Game time is " + gameTime;
        ItemCollectionTime.GetComponent<Text>().text = "Item collection time is " + itemCollectionTimes;
        CollisionTime.GetComponent<Text>().text = "Collision time is " + collisionTimes;
        MaxSpeed.GetComponent<Text>().text = "Maximum speed is " + maximumSpeed;
        TravelDistance.GetComponent<Text>().text = "Travel distance is " + travelDistance;
    }
}