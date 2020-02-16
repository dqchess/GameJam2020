using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using System.IO;
using System.Diagnostics;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.FileIO;

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
    public float zstart = -56f;
    public float xstart = 40f;
    float currentX;
    float currentZ;

    void Start()
    {
        currentX = xstart;
        using (TextFieldParser parser = new TextFieldParser("world.csv"))
        {
            parser.TextFieldType = FieldType.Delimited;
            parser.SetDelimiters(",");
            while (!parser.EndOfData) 
            {
                currentZ = zstart;
                string[] tiles = parser.ReadFields();
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
