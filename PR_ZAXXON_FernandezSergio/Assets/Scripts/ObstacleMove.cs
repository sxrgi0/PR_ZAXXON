using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{

    [SerializeField] GameObject initobject;
    InitGame InitGame;
    float speed;

    // Start is called before the first frame update
    void Start()
    {

        initobject = GameObject.Find("InitGame");
        InitGame = initobject.GetComponent<InitGame>();

        speed = InitGame.spaceshipspeed;

    }

    // Update is called once per frame
    void Update()
    {
        speed = InitGame.spaceshipspeed;
        transform.Translate(Vector3.back * Time.deltaTime * speed);

        float posZ = transform.position.z;

        if (posZ < -20)
        {
            Destroy(gameObject);
        }
    }
}
