using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Perso", menuName = "Data/Nouv Perso")]
[System.Serializable]


public class Interlocuteur : ScriptableObject
{
   public string nomPerso;
   public Color couleurText;

   //public List<Sprite> sprites;
   //public ControleurSprites prefab;
   
}
