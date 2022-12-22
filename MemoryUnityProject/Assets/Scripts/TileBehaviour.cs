using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBehaviour : MonoBehaviour
{

    public Material hiddenMaterial;// la couleur véritable, cachée
    private Material originalMaterial; // couleur par défaut
    private Animator animator;

    void Start()
    {
        originalMaterial = GetComponent<Renderer>().material;
        animator = GetComponent<Animator>();
    }

    void OnMouseEnter()
    {
        animator.SetBool("mouseOver", true);
    }
    void OnMouseExit()
    {
        animator.SetBool("mouseOver", false);
    }
    void OnMouseUp()
    {
        RevealColor();
    }
    public void RevealColor()
    {
        GetComponent<Renderer>().material = hiddenMaterial;
        animator.SetBool("CubeSelected", true);
    }
    public void UnrevealColor()
    {
        GetComponent<Renderer>().material = originalMaterial;
        animator.SetBool("CubeSelected", false);
    }
    
}
