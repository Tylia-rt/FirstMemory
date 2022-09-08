using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBehaviour : MonoBehaviour
{
    public Material hiddenMaterial;// la couleur véritable, cachée
    private Material originalMaterial; // couleur par défaut
    public LevelManager manager;
    void Start()
    {
        originalMaterial = GetComponent<Renderer>().material;// récupère la couleur par défaut djéà present sur le cube
    }
    void OnMouseUp()
    {
        RevealColor();
    }
    public void RevealColor()
    {
        GetComponent<Renderer>().material = hiddenMaterial;
    }
    public void UnrevealColor()
    {
        GetComponent<Renderer>().material = originalMaterial;
    }
    void Update()
    {
        
    }
}
