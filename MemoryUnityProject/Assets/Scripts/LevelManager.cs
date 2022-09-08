using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject tilePrefab;
    public int line;
    public int column;
    public float paddingX;
    public float paddingY;
    public float timeBeforeUnreveal = 0.5f;
    public Material[] listMaterials; // liste brut des matérieux existants
    private List<Material> potentialMaterials = new List<Material>(); // liste du nombre exacte de matériaux à distribuer (2 materiaux identiques)
    private List<TileBehaviour> tiles = new List<TileBehaviour>(); // liste de toutes les tuiles
    private List<TileBehaviour> tilesRevealed = new List<TileBehaviour>();
    private List<TileBehaviour> tilesMatched = new List<TileBehaviour>();


    void Start()
    {
        paddingX += 3.2f;
        paddingY += 5.2f;

        if(line * column % 2 != 0)
        {
            Debug.LogError("The Level need a even number of tiles", gameObject);
            return;
        }
        for(int i=0; i<listMaterials.Length; i++) // same liste que celle des materiaux , sauf qu'il possède tout 2x pour pouvoir l'appliquer sur les tuiles
        {
            potentialMaterials.Add(listMaterials[i]);// x1
            potentialMaterials.Add(listMaterials[i]);// x2
        }
        // 
        for(float y = 0; (y+0.01) < paddingY * line; y += paddingY) // + 0.001 pour éviter les problème d'arrindis et que lors de l'incrémentation il y ai pas un chouilla qui dépasse et qui provoque une ligne en plus
        {
            for (float x = 0; (x+0.01) < paddingX * column; x += paddingX)
            {
                Vector3 position = new Vector3(x,y,0f); //positionner les tuiles en fonction de leur situation dans le tableau en liste et colonnes
                CreateTile(position);
            }
        }
        
    }

   IEnumerator UnRevealTiles(){
        yield return new WaitForSeconds(timeBeforeUnreveal); // attend avant de recacher les couleurs
        for(int i = 0; i < tilesRevealed.Count; i++){ //les 2 tuiles révélées...
            tilesRevealed[i].UnrevealColor();// se recacher
        }
        tilesRevealed.Clear(); // nettoyer la liste de selection active
    }

    public void TileRevealed(TileBehaviour tile)
    {
        if(tilesRevealed.Contains(tile)) return; // je ne peux pas me toucher moi meme car je suis deja dans la liste des objects sélectionnés
        if(tilesMatched.Contains(tile)) return; // je ne peux pas toucher un object déjà matché avec son jumeau
        tile.RevealColor(); // révèle couleur et anime la carte
        tilesRevealed.Add(tile);

        if(tilesRevealed.Count >= 2)
        {
            if(tilesRevealed[0].hiddenMaterial == tilesRevealed[1].hiddenMaterial)
            {
                Debug.Log("Same Color");
                tilesMatched.Add(tilesRevealed[0]);
                tilesMatched.Add(tilesRevealed[1]);
                tilesRevealed.Clear();
            }
            else
            {
                StartCoroutine(UnRevealTiles());
            }
        }
    }
    void CreateTile(Vector3 position)
    {
        GameObject actualTile = Instantiate(tilePrefab, position, Quaternion.identity); // 3d dans scene
        TileBehaviour tile = actualTile.GetComponent<TileBehaviour>();// recupération du behaviour
        tiles.Add(tile);// ajout dans la liste des tuiles
        //tile.manager = this; //affectation de la variable manager (de la tuile) de type level manager par ce script LevelManager

        int index = Random.Range(0, potentialMaterials.Count); // random index parmis la liste des materiaux à doublon
        tile.hiddenMaterial = potentialMaterials[index]; // une fois le materiel attribué, 
        potentialMaterials.RemoveAt(index);// le supprimer de la liste pour pas qu'il soit repris 
    }
}
