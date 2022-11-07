using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plateforme : MonoBehaviour
{

    [SerializeField] private Transform Plateforme;
    [SerializeField] public float Distance = 1f;
    [SerializeField] public float Speed = 1f;
    [SerializeField] public bool X = true;
    [SerializeField] public bool Y = true;
    [SerializeField] public bool Z = true;
    private float cpt = 0f;
    private bool retour = false;
    private float x = 0f;
    private float y = 0f;
    private float z = 0f;

    // Start is called before the first frame update
    void Start()
    {
        cpt = 0f;
        retour = false;
        if(X){x=1f;}
        if(Y){y=1f;}
        if(Z){z=1f;}
    }

    // Update is called once per frame
    void Update()
    {


        if (cpt < Distance && !retour)
        {
            Plateforme.position+= new Vector3(x:x * Speed *Time.deltaTime , y: y * Speed *Time.deltaTime, z: z * Speed *Time.deltaTime);
            cpt += Speed * Time.deltaTime ;
            if (cpt > Distance){retour = true;}
        }



        if (cpt > 0 && retour)
        {
            Plateforme.position-= new Vector3(x:x * Speed *Time.deltaTime , y: y * Speed *Time.deltaTime, z: z * Speed *Time.deltaTime);
            cpt -=Speed * Time.deltaTime ;
            if (cpt < 0f){retour = false;}
        }

        

    }
}
