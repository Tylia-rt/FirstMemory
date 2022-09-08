using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBehaviour : MonoBehaviour
{
    public Material hiddenMaterial;// la couleur véritable, cachée
    private Material originalMaterial; // couleur par défaut
    public LevelManager manager;
    private Animator animator;
    [HideInInspector] public Material[] mats;

    void Start()
    {
        originalMaterial = GetComponent<Renderer>().materials[1];
        animator = GetComponent<Animator>();
        mats = GetComponent<Renderer>().materials;
    }

    void OnMouseEnter()
    {
        animator.SetBool("MouseOver", true);
    }
    void OnMouseExit()
    {
        animator.SetBool("MouseOver", false);
    }
    void OnMouseUp()
    {
         manager.TileRevealed(this);
    }
    public void RevealColor()
    {
        mats[1] = hiddenMaterial; // monstre couleur
        GetComponent<Renderer>().materials = mats;
        animator.SetBool("TileSelected", true);// anime
    }
    public void UnrevealColor()
    {
        mats[1] = originalMaterial;
        GetComponent<Renderer>().materials = mats;
        animator.SetBool("TileSelected", false);
    }
}
