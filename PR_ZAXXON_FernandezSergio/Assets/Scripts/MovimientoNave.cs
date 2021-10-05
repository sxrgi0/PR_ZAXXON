using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoNave : MonoBehaviour
{

    float despX;
    float despY;
    [SerializeField] float speed;
    float limiteR = 8;
    float limiteL = -8;
    float limiteDown = 0.9f;
    float limiteUp = 15;
    bool inlimitH = true;
    bool inlimitV = true;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        movimiento();


    }

    void movimiento()
    {
        float posX = transform.position.x;
        float posY = transform.position.y;

        despX = Input.GetAxis("Horizontal");
        despY = Input.GetAxis("Vertical");

        if (inlimitH)
        {
            transform.Translate(Vector3.right * despX * speed * Time.deltaTime);
        }

        if (inlimitV)
        {
            transform.Translate(Vector3.up * despY * speed * Time.deltaTime);
        }



        if (posX > limiteR && despX > 0 || posX < limiteL && despX < 0)
        {
            inlimitH = false;
        }
        else
        {
            inlimitH = true;
        }
        if (posY > limiteUp && despY > 0 || posY < limiteDown && despY < 0)
        {
            inlimitV = false;
        }
        else
        {
            inlimitV = true;
        }
    }
    
}
