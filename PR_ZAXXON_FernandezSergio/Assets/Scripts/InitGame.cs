using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitGame : MonoBehaviour
{

    public float spaceshipspeed;
    public int levelGame;
    static float score;

    [SerializeField] Text scoreText;
    [SerializeField] Text levelText;

    // Start is called before the first frame update
    void Start()
    {

        spaceshipspeed = 15f;

        levelGame = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Text();
    }

    void Text()
    {
        float tiempo = Time.time;

        score = Mathf.Round(tiempo) * spaceshipspeed;
        scoreText.text = Mathf.Round(score) + " mts.";
        levelText.text = "LEVEL: " + levelGame.ToString();
        if (score > 0 && score < 500)
        {
            levelGame = 1;
        }
        else if (score > 500)
        {
            levelGame = 2;
        }


    }



    public void Morir()
    {
        spaceshipspeed = 0f;
        ObjectInstantiate objectInstantiate = GameObject.Find("ObjectInstantiate").GetComponent<ObjectInstantiate>();
        objectInstantiate.SendMessage("StopGame");
    }
}
