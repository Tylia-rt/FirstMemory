using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public TextMeshProUGUI affichageEssais;
    public GameObject tilePrefab;
    public int line;
    public int column;
    public float paddingX;
    public float paddingY;
    private int essais;
//     public Material[] materials;
//     private List<Material> potentialMaterials;
//     private List<TileBehaviour> tiles = new List<TileBehaviour>();
//     private List<TileBehaviour> tilesRevealed = new List<TileBehaviour>();
//     private List<TileBehaviour> tilesMatched = new List<TileBehaviour>();


    void Start()
    {
        paddingX += 1.8f;
        paddingY += 2.8f;
        essais = 0;
        affichageEssais.text = essais.ToString();
    

//         if(line * column % 2 != 0)
//         {
//             Debug.LogError("The Level need a even number of tiles", gameObject);
//             return;
//         }
//         potentialMaterials = new List<Material>();
//         for(int i=0; i<materials.Length; i++)
//         {
//             potentialMaterials.Add(materials[i]);
//             potentialMaterials.Add(materials[i]);
//         }
        
        for(float y = 0; (y+0.001) < paddingY * line; y += paddingY) // + 0.001 pour éviter les problème d'arrindis et que lors de l'incrémentation il y ai pas un chouilla qui dépasse et qui provoque une ligne en plus
        {
            for (float x = 0; (x+0.001) < paddingX * column; x += paddingX)
            {
                Vector3 position = new Vector3(x,y,0f);
                CreateTile(position);
            }
        }
        
    }

   

//     public void TileRevealed(TileBehaviour tile)
//     {
//         if(tilesRevealed.Contains(tile)) return;
//         if(tilesMatched.Contains(tile)) return;
//         tile.RevealColor();
//         tilesRevealed.Add(tile);

//         if(tilesRevealed.Count >= 2)
//         {
//             essais +=1;
//             affichageEssais.text = essais.ToString();
//             if(tilesRevealed[0].hiddenMaterial == tilesRevealed[1].hiddenMaterial)
//             {
//                 Debug.Log("Same Color");
//                 tilesMatched.Add(tile);
//             }
//             else
//             {
//                 for(int i=0; i<tilesRevealed.Count;i++)
//                 {
//                     tilesRevealed[i].UnrevealColor();
//                 }
//             }
//             tilesRevealed.Clear();
//         }
//     }
    void CreateTile(Vector3 position)
    {
        GameObject actualTile = Instantiate(tilePrefab, position, Quaternion.identity);
        // TileBehaviour tile = actualTile.GetComponent<TileBehaviour>();
        // tiles.Add(tile);
        // tile.manager = this;

        // int index = Random.Range(0, potentialMaterials.Count-1);
        // tile.hiddenMaterial = materials[index];
        // potentialMaterials.RemoveAt(index);
    }


//     void Update()
//     {
        
//     }
}
