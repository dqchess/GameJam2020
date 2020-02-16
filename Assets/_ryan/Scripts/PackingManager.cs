using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackingManager : MonoBehaviour
{
    [SerializeField] private Transform BlocksParent = null;
    [SerializeField] private AbilityDatabase abilityDatabase = null;
    [SerializeField] public Transform gridParent = null;
    [SerializeField] public Transform gridPosition = null;
    [SerializeField] public Transform blockPosition = null;
    [SerializeField] public LineFactory lineFactory = null;

    public int cols = 0;
    public int rows = 0;
    public GameObject TileObject = null;


    //private List<GameObject> blocks;

    public Vector2 minBound = Vector2.zero;
    public Vector2 maxBound = Vector2.zero;

    private float lineWidth = 0.02f;
    private Color gridColor = Color.black;

    private void Awake()
    {
        //blocks = new List<GameObject>();

        //foreach (Transform child in BlocksParent)
        //{
        //    if (child.GetComponent<GamePiece>())
        //    {
        //        blocks.Add(child.gameObject);
        //    }
        //}

        //foreach(GameObject block in blocks)
        //{
        //    GamePiece gamePiece = block.GetComponent<GamePiece>();
        //    gamePiece.packingManager = this;
        //    gamePiece.OnSuccessfulPlace += OnPlace;
        //}
        //lineFactory = GetComponent<LineFactory>();
    }

    // Start is called before the first frame update
    void Start()
    {
        BuildGrid(cols, rows);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SpawnRandomAbility();
        }
    }


    private void BuildGrid(int cols, int rows)
    {
        Vector3 currentPosition = Vector3.zero;

        float tileSize = TileObject.GetComponent<BoxCollider2D>().size.x;

        float totalWidth = tileSize * cols;
        float totalHeight = tileSize * rows;


        Vector2 halfTileOffset = new Vector2(tileSize / 2f, tileSize / 2f);
        Vector2 halfGridOffset = new Vector2(totalWidth / 2f, totalHeight / 2f);
        Vector2 positionOffset = gridPosition.position;

        Vector3 topLeftOffset = Vector3.zero;

        int id = 0;

        for (int y = rows - 1; y >= 0; y--)
        {
            for (int x = 0; x < cols; x++)
            {
                currentPosition = new Vector2(x * tileSize, y * tileSize) + halfTileOffset - halfGridOffset + positionOffset;
                GameObject newTileObject = Instantiate(TileObject, currentPosition, Quaternion.identity, gridParent) as GameObject;
                newTileObject.tag = "GridTile";

                Tile newTile = newTileObject.GetComponent<Tile>();
                newTile.id = id++;
                //newTile.canDrawBorder = true;
            }
        }
        
        minBound = (Vector2)gridPosition.position - halfGridOffset;
        maxBound = (Vector2)gridPosition.position + halfGridOffset;


        Vector3 topLeft = transform.position - new Vector3(halfGridOffset.x, halfGridOffset.y, 0f) + new Vector3(positionOffset.x, positionOffset.y, 0f);


        for(int i = 0; i <= rows; i++)
        {
            Vector3 a = new Vector3(topLeft.x,  topLeft.y + (i * tileSize), topLeft.z);

            lineFactory.GetLine(a, a + (Vector3.right * totalWidth), lineWidth, gridColor);
        }

        for (int i = 0; i <= cols; i++)
        {
            Vector3 a = new Vector3(topLeft.x + (i * tileSize),  topLeft.y, topLeft.z);

            lineFactory.GetLine(a, a + (Vector3.up * totalHeight), lineWidth, gridColor);
        }

        


    }

    private void OnPlace(GameObject go)
    {
        Debug.Log("placed: " + go.name);

        GamePiece piece = go.GetComponent<GamePiece>();
    }

    private void SpawnRandomAbility()
    {
        int rand = UnityEngine.Random.Range(0, Enum.GetNames(typeof(AbilityID)).Length);
        //Enum.GetNames(typeof(MyEnum)).Length;

        AbilityID id = (AbilityID) rand;
        SpawnAbility(id);
    }

    public void SpawnAbility(AbilityID id)
    {
        GameObject abilityPrefab = Array.Find(abilityDatabase.abilities, x => (x.id == id)).block;

        GameObject newAbilityObject = Instantiate(abilityPrefab, blockPosition.position, Quaternion.identity, BlocksParent) as GameObject;
        GamePiece gamePiece = newAbilityObject.GetComponent<GamePiece>();
        gamePiece.packingManager = this;
        gamePiece.OnSuccessfulPlace += OnPlace;
    }
}
