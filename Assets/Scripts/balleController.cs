using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balleController : MonoBehaviour
{

    void Update()
    {
        //Debug.Log(transform.position);
        if ((transform.position.x > 100) || (transform.position.y > 100) ||  (transform.position.z > 100) || (transform.position.x <-100) || (transform.position.y < -100) ||  (transform.position.z < -100))
        {    
            //Debug.Log("transform.position");
            Destroy(gameObject);
        }
        
    }

}
