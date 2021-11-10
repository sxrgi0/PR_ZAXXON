using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInstantiate : MonoBehaviour
{

    [SerializeField] GameObject[] arrayObst;
    [SerializeField] Transform initPos;
    InitGame initGame;
    [SerializeField] float intervalo;
    int level;

    // Start is called before the first frame update
    void Start()
    {
        intervalo = 0.4f;
        initGame = GameObject.Find("InitGame").GetComponent<InitGame>();
        StartCoroutine("CreateObstacles"); 
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CreateObstacles()
    {

        bool hasalidopared = false;
        int contadorpared = 0;
        while (true)
        {
            Vector3 instPos = new Vector3(Random.Range(-9f, 9f), 0f, initPos.position.z);
            int randomnum = 0;

            

            level = initGame.levelGame;
            

            if (level == 1)
            {
                randomnum = 0;
            }
            else if (level == 2 && hasalidopared == false)
            {
                randomnum = Random.Range(0, 2);
            }
            else if (level == 3 && hasalidopared == false)
            {
                randomnum = Random.Range(0, arrayObst.Length);
            }
            else
            {
                randomnum = 0;
            }
    


            if(arrayObst[randomnum].tag == "columna")
            {
                instPos = new Vector3(Random.Range(-9f, 9f), 0f, initPos.position.z);
            }
            else if(arrayObst[randomnum].tag == "pared")
            {
                instPos = new Vector3(0f, 0f, initPos.position.z);
               
            }
            else if(arrayObst[randomnum].tag == "pared2")
            {
                instPos = new Vector3(0f, Random.Range(0f, 10f), initPos.position.z);
            }
           
            Instantiate(arrayObst[randomnum], instPos, Quaternion.identity);

            if (arrayObst[randomnum].tag == "pared" && arrayObst[randomnum].tag == "pared2");
            {
                hasalidopared = true;
            }
            if (hasalidopared)
            {
                contadorpared++;
            }
            if(contadorpared == 3)
            {
                hasalidopared = false;
                contadorpared = 0;
            }

            yield return new WaitForSeconds(intervalo);
        }
    }


    public void StopGame()
    {

        StopCoroutine("CreateObstacles");


    }
}
