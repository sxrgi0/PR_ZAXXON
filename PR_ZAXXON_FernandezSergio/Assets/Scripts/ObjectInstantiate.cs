using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInstantiate : MonoBehaviour
{

    [SerializeField] GameObject[] arrayObst;
    [SerializeField] Transform initPos;
    InitGame initGame;
    float intervalo;
    int level;

    // Start is called before the first frame update
    void Start()
    {
        intervalo = 0.5f;
        initGame = GameObject.Find("InitGame").GetComponent<InitGame>();
        StartCoroutine("CreateObstacles");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CreateObstacles()
    {
        while (true)
        {
            Vector3 instPos = new Vector3(Random.Range(-9f, 9f), 0f, initPos.position.z);
            int randomnum;

            level = initGame.levelGame;

            if(level == 0)
            {
                randomnum = 0;
            }
            else if (level > 0 && level < 4)
            {
                randomnum = Random.Range(0, 2);
            }
            else
            {
                randomnum = Random.Range(0, arrayObst.Length);
            }

            Instantiate(arrayObst[randomnum], instPos, Quaternion.identity);
            yield return new WaitForSeconds(intervalo);
        }
    }
}
