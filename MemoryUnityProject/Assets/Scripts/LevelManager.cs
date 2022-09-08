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
    public Material[] materials;
    private List<Material> potentialMaterials;
    private List<TileBehaviour> tiles = new List<TileBehaviour>();
    private List<TileBehaviour> tilesRevealed = new List<TileBehaviour>();


    // Start is called before the first frame update
    void Start()
    {
        paddingX +=2f;
        paddingY += 2.9f;
        if(line * column % 2 != 0)
        {
            Debug.LogError("The Level need a even number of tiles", gameObject);
            return;
        }
        potentialMaterials = new List<Material>();
        for(int i=0; i<materials.Length; i++)
        {
            potentialMaterials.Add(materials[i]);
            potentialMaterials.Add(materials[i]);
        }
        
        for(float z = 0; z < paddingY * line; z += paddingY)
        {
            for (float x = 0; x < paddingX * column; x += paddingX)
            {
                Vector3 position = new Vector3(x,0f,z);
                CreateTile(position);
            }
        }
    }

    public void TileRevealed(TileBehaviour tile)
    {
        if(tilesRevealed.Contains(tile)) return;
        tile.RevealColor();
        tilesRevealed.Add(tile);

        if(tilesRevealed.Count >= 2)
        {
            if(tilesRevealed[0].hiddenMaterial == tilesRevealed[1].hiddenMaterial)
            {
                Debug.Log("Same");
            }
            tilesRevealed.Clear();
        }
    }
    void CreateTile(Vector3 position)
    {
        GameObject actualTile = Instantiate(tilePrefab, position, Quaternion.identity);
        TileBehaviour tile = actualTile.GetComponent<TileBehaviour>();
        tiles.Add(tile);
        tile.manager = this;

        int index = Random.Range(0, potentialMaterials.Count-1);
        tile.hiddenMaterial = materials[index];
        potentialMaterials.RemoveAt(index);
    }


    void Update()
    {
        
    }
}
