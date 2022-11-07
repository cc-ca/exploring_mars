using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vide : MonoBehaviour
{

[SerializeField] private Transform player;



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("player"))
        {          
            //Debug.Log("Collision Balle !");
           // Destroy(collision.gameObject);
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
