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
        GameTime.GetComponent<Text>().text = "Game time is " + System.Math.Round(gameTime,2) + " sec";
        ItemCollectionTime.GetComponent<Text>().text = "Number of items collect is " + itemCollectionTimes;
        CollisionTime.GetComponent<Text>().text = "Collision time is " + collisionTimes;
        MaxSpeed.GetComponent<Text>().text = "Maximum speed is " + System.Math.Round(maximumSpeed,2);
        TravelDistance.GetComponent<Text>().text = "Travel distance is " + System.Math.Round(travelDistance,2);
    }
}