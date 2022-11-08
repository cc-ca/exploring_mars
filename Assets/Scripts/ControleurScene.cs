using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleurScene : MonoBehaviour
{
    public StockageScene sceneHist;
    public ControleurBoiteDiag boiteText;
    //public SwitchSprites controleurArrierePlan;

    // Start is called before the first frame update
    void Start()
    {
        boiteText.SceneJoue(sceneHist);
        //controleurArrierePlan.SetImage(sceneHist.fond);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(boiteText.EstComplet())
            {
                if(boiteText.EstDernierePhrase())
                {
                    sceneHist = sceneHist.sceneSuivante;
                    boiteText.SceneJoue(sceneHist);
                    //controleurArrierePlan.TransiImage(sceneHist.fond);
                }
                boiteText.JouerPhraseSuivante();
            }
        }
    }
}
