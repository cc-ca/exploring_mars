using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NouveauScene", menuName = "Data/ Nouv Scene")]
[System.Serializable]

public class StockageScene : ScriptableObject
{
   public List<Sentence> phrases;
   public Sprite fond;
   public StockageScene sceneSuivante;

   [System.Serializable]

   public struct Sentence
   {
        public string text;
        public Interlocuteur personnage;
        public List<Action> actions;

        [System.Serializable]
        public struct Action
        {
            public Interlocuteur personnage;
            public int spriteIndex;
            public Type actionType;
            public Vector2 coords;
            public float moveSpeed;

            [System.Serializable]
            public enum Type
            {
                AUCUN, APPARU, DEPLACEMENT, DISPARU
            }
        }
   }
}