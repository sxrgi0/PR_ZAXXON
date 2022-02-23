using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitGame : MonoBehaviour
{

    public float spaceshipspeed;
    [SerializeField] float maxspeed;
    bool alive;
    
    public int levelGame;
    static float score;
    GameObject GameOver;
    Canvas GameOverCanvas;

    [SerializeField] Text scoreText;
    [SerializeField] Text levelText;
    [SerializeField] Button retrybutton;

    AudioSource audiosource;

        

    // Start is called before the first frame update
    void Start()
    {
        
        spaceshipspeed = 15f;
        maxspeed = 100f;
        alive = true;
        levelGame = 1;

        

        //score 0
        //score = 0;

        GameOver = GameObject.Find("GameOverCanvas");
        GameOverCanvas = GameOver.GetComponent<Canvas>();
        GameOverCanvas.enabled = false;

        audiosource = GetComponent<AudioSource>();
        audiosource.Play();


    }

    // Update is called once per frame
    void Update()
    {
        if (spaceshipspeed < maxspeed && alive == true)
        {
            spaceshipspeed += 0.001f;


        }
        Text();
    }

    void Text()
    {

        float tiempo = Time.timeSinceLevelLoad;

        if (spaceshipspeed != 0)
        {
            score = Mathf.Round(tiempo) * spaceshipspeed;
        }

        scoreText.text = Mathf.Round(score) + " mts.";
        levelText.text = "LEVEL: " + levelGame.ToString();
        if (score > 0 && score < 500)
        {
            levelGame = 1;
        }
        else if (score > 500 && score < 1500)
        {
            levelGame = 2;
        }
        else if (score > 1500)
        {
            levelGame = 3;
        }


    }



    public void Morir()
    {
        
        spaceshipspeed = 0f;
        alive = false;
        ObjectInstantiate objectInstantiate = GameObject.Find("ObjectInstantiate").GetComponent<ObjectInstantiate>();
        objectInstantiate.SendMessage("StopGame");
        
        Invoke("ShowGameOver", 0.1f);

        audiosource.Stop();

        if (score > GameManager.highscore)
        {
            GameManager.highscore = score;
            

        }

    }

    void ShowGameOver()
    {
        GameOverCanvas.enabled = true;

        retrybutton.Select();
    }

}
