using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleurSprites : MonoBehaviour
{
   private SwitchSprites echangeur;
   private Animator animator;
   private RectTransform rect;

   private void Awake()
   {
        echangeur = GetComponent<SwitchSprites>();
        animator = GetComponent<Animator>();
        rect = GetComponent<RectTransform>();
   }

   public void Setup(Sprite sprite)
   {
        echangeur.SetImage(sprite);
   }

    public void Spawn(Vector2 coords)
    {
        animator.SetTrigger("Spawn");
        rect.localPosition = coords;
    }

    public void Despawn()
    {
        animator.SetTrigger("Despawn");
    }

    public void Move(Vector2 coords, float speed)
    {
        StartCoroutine(MoveCoroutine(coords, speed));
    }

    private IEnumerator MoveCoroutine(Vector2 coords, float speed)
    {
        while(rect.localPosition.x != coords.x || rect.localPosition.y != coords.y)
        {
            rect.localPosition = Vector2.MoveTowards(rect.localPosition, coords, Time.deltaTime * 1000f * speed);
            yield return new WaitForSeconds(0.01f);
        }
    }

    public void EchangeSprite(Sprite sprite)
    {
        if(echangeur.GetImage() != sprite)
        {
            echangeur.TransiImage(sprite);
        }
    }

}