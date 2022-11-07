using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{


    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform cameraTransform;
    private float timeleft;
    // Start is called before the first frame update


private void SpawnBalle()
{


    GameObject balle = Instantiate(bullet,cameraTransform.position+ 0.2f * cameraTransform.forward, Quaternion.identity);

    //on recupère son rigide body
    Rigidbody balleRigidbody = balle.GetComponent<Rigidbody>();

    //on applique une impulsion
    balleRigidbody.AddForce(cameraTransform.forward * 1000); //*la puissance
        
}
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            SpawnBalle();
  
        }

        if(Input.GetButton("Fire2"))
        {
            timeleft -= Time.deltaTime;
            if (timeleft<0)
            {
                SpawnBalle();
                timeleft= 0.05f ;
            } 
                
        }
        
        else 
        {
            timeleft= 0 ;
            
        }
    }
}
