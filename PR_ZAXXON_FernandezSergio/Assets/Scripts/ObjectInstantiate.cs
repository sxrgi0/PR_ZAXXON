using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInstantiate : MonoBehaviour
{

    [SerializeField] GameObject Obstacles;
    [SerializeField] Transform initPos;
    float intervalo;

    // Start is called before the first frame update
    void Start()
    {
        intervalo = 1f;
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
            Instantiate(Obstacles, instPos, Quaternion.identity);
            yield return new WaitForSeconds(intervalo);

        }
    }
}
