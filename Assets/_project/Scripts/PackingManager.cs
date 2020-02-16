using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackingManager : MonoBehaviour
{
    [SerializeField] private Transform BlocksParent = null;

    public int cols = 0;
    public int rows = 0;
    public GameObject TileObject = null;
    public Transform parent = null;

    private List<GameObject> blocks;

    public Vector2 minBound = Vector2.zero;
    public Vector2 maxBound = Vector2.zero;

    private void Awake()
    {
        blocks = new List<GameObject>();

        foreach (Transform child in BlocksParent)
        {
            if (child.GetComponent<GamePiece>())
            {
                blocks.Add(child.gameObject);
            }
        }

        foreach(GameObject block in blocks)
        {
            GamePiece gamePiece = block.GetComponent<GamePiece>();
            gamePiece.packingManager = this;
            gamePiece.OnSuccessfulPlace += OnPlace;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        BuildGrid(cols, rows);
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void BuildGrid(int cols, int rows)
    {
        Vector3 currentPosition = Vector3.zero;

        float tileSize = TileObject.GetComponent<BoxCollider2D>().size.x;

        float totalWidth = tileSize * cols;
        float totalHeight = tileSize * rows;


        Vector2 halfTileOffset = new Vector2(tileSize / 2f, tileSize / 2f);
        Vector2 halfGridOffset = new Vector2(totalWidth / 2f, totalHeight / 2f);

        Vector3 topLeftOffset = Vector3.zero;

        int id = 0;

        for (int y = rows - 1; y >= 0; y--)
        {
            for (int x = 0; x < cols; x++)
            {
                currentPosition = new Vector2(x * tileSize, y * tileSize) + halfTileOffset - halfGridOffset;
                GameObject newTileObject = Instantiate(TileObject, currentPosition, Quaternion.identity, parent) as GameObject;
                newTileObject.tag = "GridTile";

                Tile newTile = newTileObject.GetComponent<Tile>();
                newTile.id = id++;
                newTile.canDrawBorder = true;
            }
        }
        
        minBound = (Vector2)transform.position - halfGridOffset;
        maxBound = (Vector2)transform.position + halfGridOffset;
    }

    private void OnPlace(GameObject go)
    {
        Debug.Log("placed: " + go.name);

        GamePiece piece = go.GetComponent<GamePiece>();
    }
}
