using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControleurBoiteDiag : MonoBehaviour
{
    public TextMeshProUGUI boiteText;
    public TextMeshProUGUI textNomPerso;

    public StockageScene sceneActuelle;
    private int indexPhrase = -1;
    private State etat = State.COMPLET;
    private Animator animator;
    private bool estCache = false;

    public Dictionary<Interlocuteur, ControleurSprites> sprites;
    public GameObject spritesPrefab;

    private enum State
    {
        ENCOURS, COMPLET
    }

    public void Start()
    {
        sprites = new Dictionary<Interlocuteur, ControleurSprites>();
        animator = GetComponent<Animator>();
    }

    public void Despawn()
    {
        if (!estCache)
        {
            animator.SetTrigger("Despawn");
            estCache = true;
        }
    }

    public void Spawn()
    {
        animator.SetTrigger("Spawn");
        estCache = false;
    }

    public void ClearText()
    {
        boiteText.text = "";
    }

    public void SceneJoue(StockageScene scene)
    {
        sceneActuelle = scene;  
        indexPhrase = -1;
        JouerPhraseSuivante();
    }

    
    public void JouerPhraseSuivante()
    {
        StartCoroutine(TypeText(sceneActuelle.phrases[++indexPhrase].text));
        textNomPerso.text = sceneActuelle.phrases[indexPhrase].personnage.nomPerso;
        textNomPerso.color = sceneActuelle.phrases[indexPhrase].personnage.couleurText;
        //ActionInterlocs();
    }

    public bool EstComplet()
    {
        return etat == State.COMPLET;
    }

    public bool EstDernierePhrase()
        {
            return indexPhrase + 1 == sceneActuelle.phrases.Count;
        }
    

    private IEnumerator TypeText(string text)
    {
        boiteText.text = "";
        etat = State.ENCOURS;
        int wordIndex = 0; 

        while(etat != State.COMPLET)
        {
            boiteText.text += text[wordIndex];
            yield return new WaitForSeconds(0.05f);
            if(++wordIndex == text.Length)
            {
                etat = State.COMPLET;
                break;
            }
        }
    }

    //private void ActionInterlocs()
    //{
    //    List<StockageScene.Sentence.Action> actions = sceneActuelle.phrases[indexPhrase].actions;
    //    for(int i = 0; i < actions.Count; i++)
    //    {
    //        ActionInterloc(actions[i]);
    //    }
    //}

    //private void ActionInterloc(StockageScene.Sentence.Action action)
    //{
    //    ControleurSprites controller = null;
    //    switch (action.actionType)
    //    {
    //        case StockageScene.Sentence.Action.Type.APPARU:
    //        if (!sprites.ContainsKey(action.personnage))
    //        {
    //            controller = Instantiate(action.personnage.prefab.gameObject, spritesPrefab.transform).GetComponent<ControleurSprites>();
    //            sprites.Add(action.personnage, controller);
    //        }
    //        else
    //        {
    //            controller = sprites[action.personnage];
    //        }
    //        controller.Setup(action.personnage.sprites[action.spriteIndex]);
    //        controller.Spawn(action.coords);
    //        return;
    //    case StockageScene.Sentence.Action.Type.DEPLACEMENT:
    //        if (sprites.ContainsKey(action.personnage))
    //        {
    //            controller = sprites[action.personnage];
    //            controller.Move(action.coords, action.moveSpeed);
    //        }
    //        break;
    //    case StockageScene.Sentence.Action.Type.DISPARU:
    //        if (sprites.ContainsKey(action.personnage))
    //        {
    //            controller = sprites[action.personnage];
    //            controller.Despawn();
    //        }
    //        break;
    //    case StockageScene.Sentence.Action.Type.AUCUN:
    //        if (sprites.ContainsKey(action.personnage))
    //        {
    //            controller = sprites[action.personnage];
    //        }
    //        break;
    //    }
    //    if(controller != null)
    //    {
    //        controller.EchangeSprite(action.personnage.sprites[action.spriteIndex]);
    //    }
    //}
}