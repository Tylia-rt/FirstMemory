using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBehaviour : MonoBehaviour
{
    public Material hiddenMaterial;// la couleur véritable, cachée
    private Material originalMaterial; // couleur par défaut
    public LevelManager manager;
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
         manager.TileRevealed(this);
    }
    public void RevealColor()
    {
        GetComponent<Renderer>().materials[1] = hiddenMaterial; // monstre couleur
        animator.SetBool("TileSelected", true);// anime
    }
    public void UnrevealColor()
    {
        GetComponent<Renderer>().materials[1] = originalMaterial;
        animator.SetBool("TileSelected", false);
    }
}
