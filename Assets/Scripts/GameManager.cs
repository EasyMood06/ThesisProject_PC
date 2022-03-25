using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private float gameTime;
    public float remainTime;
    public float initialTime;
    public int ItemCollectionTimes;
    public int CollisionTimes;
    public float maximumSpeed;
    public float CurrentSpeed;
    public float TravelDistance;
    public float HPbarWidth;
    public GameObject HPBar;

    public int HackerScore = 99999;
    public int ProScore = 9999;
    public int NoobScore = 99;
    public Text Num1ScoreText;
    public Text Num1Name;
    public Text Num2ScoreText;
    public Text Num2Name;
    public Text Num3ScoreText;
    public Text Num3Name;
    public Text Num4ScoreText;
    public Text Num4Name;
    
    public Text SpeedText;

    Controller controller;
    public PlayerScore playerScore;
    private int CurrentRank;

    // Start is called before the first frame update
    void Start()
    {
        controller = FindObjectOfType<Controller>();
        

        gameTime = 0f;
        remainTime = 10f;
        initialTime = remainTime;
        ItemCollectionTimes = 0;
        CollisionTimes = 0;
        maximumSpeed = 0f;
        CurrentSpeed = 0f;
        TravelDistance = 0f;
        CurrentRank = 4;
        HPbarWidth = 700.0f;

        Num1ScoreText.text = HackerScore.ToString();
        Num2ScoreText.text = ProScore.ToString();
        Num3ScoreText.text = NoobScore.ToString();
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

        UpdateUI();
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

        playerScore.gameObject.SetActive(true);
        playerScore.DisplayPlayerScore(gameTime, ItemCollectionTimes, CollisionTimes, maximumSpeed, TravelDistance);
    }

    void UpdateUI() {
        // Update Rank Board
        TravelDistance = controller.ComputeTravelDistance();
        RankBoardUpdate();

        // Update Speed Text
        CurrentSpeed = controller.GetPlayerCurrentSpeed();
        SpeedText.text = "Speed: " + ((int) CurrentSpeed).ToString() + "m/s";

        // Update Time
        RectTransform BarRectTransform = HPBar.GetComponent<RectTransform>();
        BarRectTransform.sizeDelta = new Vector2 ((remainTime / initialTime) * HPbarWidth, BarRectTransform.sizeDelta.y);
    }

    void RankBoardUpdate() 
    {
        if (TravelDistance > HackerScore && CurrentRank != 1)
        {
            CurrentRank = 1;
            Num1Name.text = "You";
            Num1Name.color = Color.red;
            Num2Name.text = "Hacker";
            Num2Name.color = Color.white;
            Num2ScoreText.text = HackerScore.ToString();
            Num3Name.text = "Pro Player";
            Num3ScoreText.text = ProScore.ToString();
            Num4Name.text = "Noob";
            Num4ScoreText.text = NoobScore.ToString();
        }
        else if (TravelDistance < HackerScore && TravelDistance > ProScore && CurrentRank != 2)
        {
            CurrentRank = 2;
            Num2Name.text = "You";
            Num2Name.color = Color.red;
            Num3Name.text = "Pro Player";
            Num3Name.color = Color.white;
            Num3ScoreText.text = ProScore.ToString();
            Num4Name.text = "Noob";
            Num4ScoreText.text = NoobScore.ToString();
        }
        else if (TravelDistance < ProScore && TravelDistance > NoobScore && CurrentRank != 3) {
            CurrentRank = 3;
            Num3Name.text = "You";
            Num3Name.color = Color.red;
            Num4Name.text = "Noob";
            Num4Name.color = Color.white;
            Num4ScoreText.text = NoobScore.ToString();
        }

        if (CurrentRank == 1) 
        {
            Num1ScoreText.text = ((int) TravelDistance).ToString();
        }
        else if (CurrentRank == 2) 
        {
            Num2ScoreText.text = ((int) TravelDistance).ToString();
        }
        else if (CurrentRank == 3) 
        {
            Num3ScoreText.text = ((int) TravelDistance).ToString();
        }
        else if (CurrentRank == 4) 
        {
            Num4ScoreText.text = ((int) TravelDistance).ToString();
        }
    }
}
