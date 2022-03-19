using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Controller : MonoBehaviour
{
    private bool right2Value;
    private bool left2Value;

    private bool right1Value;
    private bool left1Value;

    // Player attributes
    public float speed;
    public float maxSpeed = 10f;
    float maxSpeedPlayerReach = 0f;
    public float movementRestrict;
    public GameObject boost;
    public AudioClip boostAudioClip;
    public AudioClip pongAudioClip;
    public GameObject pong;
    public bool isControllable;

    AudioSource boostAudioSource;
    AudioSource pongAudioSource;
    PlayerTrigger playerTrigger;

    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        

        playerTrigger = FindObjectOfType<PlayerTrigger>();
        gameManager = FindObjectOfType<GameManager>();
        
        boostAudioSource = boost.GetComponent<AudioSource>();
        pongAudioSource = pong.GetComponent<AudioSource>();
        
        
        isControllable = true;
    }

    // Update is called once per frame
    void Update()
    {
        ProcessKeyInput();
        CharacterHorizontalMovement();
        CharacterForwardMovement();
        DetectTrigger();

    }

// Keyboard input
    void ProcessKeyInput()
    {
        if(Input.GetKeyDown(KeyCode.D))
        {
            right2Value = true;
        }
        if(Input.GetKeyDown(KeyCode.A))
        {
            left2Value = true;
        }

        if(Input.GetKeyUp(KeyCode.D))
        {
            right2Value = false;
        }
        if(Input.GetKeyUp(KeyCode.A))
        {
            left2Value = false;
        }

        if(Input.GetKeyDown(KeyCode.W))
        {
            right1Value = true;
        }
        if(Input.GetKeyUp(KeyCode.W))
        {
            right1Value = false;
        }

        if(Input.GetKeyDown(KeyCode.S))
        {
            left1Value = true;
        }
        if(Input.GetKeyUp(KeyCode.S))
        {
            left1Value = false;
        }
    }

    // detect collision with block
    void DetectTrigger()
    {
        if(playerTrigger.isBlock)
        {
            speed = -0.75f;
            playerTrigger.isBlock = false;
            PlayPongAudio();
            gameManager.CollisionTimes++;
        }
    }

    void PlayPongAudio()
    {
        pongAudioSource.PlayOneShot(pongAudioClip);
    }


    void BoostAudio()
    {
        if(!boostAudioSource.isPlaying)
        {
            boostAudioSource.Play();
        }
    }


    void CharacterHorizontalMovement()
    {
        if(!isControllable)
            return;
        // boost
        if(right1Value && !left1Value)
        {
            speed += Time.deltaTime * maxSpeed / 10f;
            if(speed > maxSpeedPlayerReach)
            {
                maxSpeedPlayerReach = speed;
            }
            BoostAudio();
            if(speed > maxSpeed)
            {
                speed = maxSpeed;
            }
        }else{
            boostAudioSource.Stop();
        }
        if(left1Value)
        {
            speed -= Time.deltaTime * maxSpeed / 10f;
            if(speed <= -5f)
            {
                speed = -5f;
            }
        }

        float horizontal_speed = Mathf.Abs(speed) * 0.5f;


        // move right
        if(right2Value)
        {
            gameObject.transform.Translate(Vector3.right * Time.deltaTime * horizontal_speed, Space.Self);
        }
        // move left
        if(left2Value)
        {
            gameObject.transform.Translate(-Vector3.right * Time.deltaTime * horizontal_speed, Space.Self);
        }
        // restrict movement
        if(gameObject.transform.position.x < -movementRestrict)
        {
            gameObject.transform.position = new Vector3(-movementRestrict, gameObject.transform.position.y, gameObject.transform.position.z);
        }
        if(gameObject.transform.position.x > movementRestrict)
        {
            gameObject.transform.position = new Vector3(movementRestrict, gameObject.transform.position.y, gameObject.transform.position.z);
        }

    }

    void CharacterForwardMovement()
    {
        gameObject.transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.Self);
        if(speed >0)
        {
            speed -= Time.deltaTime * 0.1f;
        }
        if(speed <0)
        {
            speed += Time.deltaTime * 0.1f;
        }
        
    }

    public float ComputeTravelDistance()
    {
        float currentZaxis = gameObject.transform.position.z;
        float travelDistance = currentZaxis - (-100f);
        return travelDistance;
    }

    public float GetPlayerMaxSpeed()
    {
        return maxSpeedPlayerReach;
    }


    
}
