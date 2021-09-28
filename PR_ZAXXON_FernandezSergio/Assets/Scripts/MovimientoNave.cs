using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoNave : MonoBehaviour
{

    float despX;
    float despY;
    [SerializeField] float speed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        despX = Input.GetAxis("Horizontal");
        transform.Translate (Vector3.right * despX * speed * Time.deltaTime);

        despY = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * despY * speed * Time.deltaTime);




    }
}
