using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackingManager : MonoBehaviour
{
    public int gridSize = 6;
    public GameObject TileObject = null;
    public Transform parent = null;

    private GameObject[][] grid = null;

    // Start is called before the first frame update
    void Start()
    {
        BuildGrid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void BuildGrid()
    {
        Vector3 currentPosition = Vector3.zero;


        float tileSize = TileObject.GetComponent<BoxCollider2D>().size.x;

        Vector3 topLeftOffset = tileSize

        int id = 0;

        for (int y = gridSize; y >= 0; y--)
        {
            for (int x = 0; x < gridSize; x++)
            {
                currentPosition = new Vector2(x * tileSize, y * tileSize);
                GameObject newTile = Instantiate(TileObject, currentPosition, Quaternion.identity, parent) as GameObject;
                newTile.GetComponent<Tile>().id = id;
            }
        }
    }
}
