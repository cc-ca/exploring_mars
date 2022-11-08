using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchSprites : MonoBehaviour
{
    public bool estTransitio = false;
    public Image image1;
    public Image image2;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void TransiImage(Sprite sprite)
    {
        if(!estTransitio)
        {
            image2.sprite = sprite;
            animator.SetTrigger("PremTransi");
        }
        else 
        {
            image1.sprite = sprite;
            animator.SetTrigger("SecTransi");
        }
        estTransitio = !estTransitio;
    }

    public void SetImage(Sprite sprite)
    {
        if(!estTransitio)
        {
            image1.sprite = sprite;
        }
        else 
        {
            image2.sprite = sprite;
        }
    }

    public Sprite GetImage()
    {
        if(!estTransitio)
        {
            return image1.sprite;
        }
        else 
        {
            return image2.sprite;
        }
    }

}