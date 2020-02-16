using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using System.IO;
using System.Diagnostics;

public class LevelGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject grassTile;
    public GameObject caveTile;
    public GameObject stormTile;
    public GameObject waterTile;
    public GameObject dirtTile;
    public GameObject forestTile;
    public GameObject iceTile;
    public GameObject lavaTile;
    public GameObject canyonTile;
    public GameObject blockingTile;
    public float zstart = -224f;
    public float xstart = -160f;
    float currentX;
    float currentZ;
    public TextAsset world;

    void Start()
    {
        currentX = xstart;
        string[] tileTable = world.ToString().Split(new[] { System.Environment.NewLine }, System.StringSplitOptions.None);
        foreach (string tileRow in tileTable) 
        {
            currentZ = zstart;
            string[] tiles = tileRow.Split(',');
            foreach (string tile in tiles)
            {
                switch (tile)
                {
                    case "c":
                        Instantiate(caveTile, new Vector3(currentX, 0, currentZ), Quaternion.identity);
                        break;
                    case "g":
                        Instantiate(grassTile, new Vector3(currentX, 0, currentZ), Quaternion.identity);
                        break;
                    case "e":
                        Instantiate(dirtTile, new Vector3(currentX, 0, currentZ), Quaternion.identity);
                        break;
                    case "f":
                        Instantiate(forestTile, new Vector3(currentX, 0, currentZ), Quaternion.identity);
                        break;
                    case "i":
                        Instantiate(iceTile, new Vector3(currentX, 0, currentZ), Quaternion.identity);
                        break;
                    case "l":
                        Instantiate(lavaTile, new Vector3(currentX, 0, currentZ), Quaternion.identity);
                        break;
                    case "t":
                        Instantiate(stormTile, new Vector3(currentX, 0, currentZ), Quaternion.identity);
                        break;
                    case "u":
                        Instantiate(blockingTile, new Vector3(currentX, 0, currentZ), Quaternion.identity);
                        break;
                    case "v":
                        Instantiate(canyonTile, new Vector3(currentX, 0, currentZ), Quaternion.identity);
                        break;
                    case "r":
                        Instantiate(waterTile, new Vector3(currentX, 0, currentZ), Quaternion.identity);
                        break;
                    default:
                        Instantiate(dirtTile, new Vector3(currentX, 0, currentZ), Quaternion.identity);
                        break;
                }
                currentZ += 4f;
            }

            currentX += 4f;
        }    
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
