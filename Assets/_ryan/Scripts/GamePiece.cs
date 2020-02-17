using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class GamePiece : MonoBehaviour
{
    public PackingManager packingManager = null;

    private Vector2 mouseOffset = Vector2.zero;

    private bool rotating = false;

    private bool dragging = false;

    private Vector2 mouseWorldPosition = Vector2.zero;

    private Quaternion currentRotation = Quaternion.identity;
    private Quaternion finalRotation = Quaternion.identity;

    private float rotationTimer = 0f;

    private float rotationSpeed = 16f;

    private List<GameObject> children = null;

    private bool canPlacePiece = false;

    private bool placed = false;

    //public UnityAction onSuccessfulPlace = null;

    public Action<GameObject> OnSuccessfulPlace = null;
    public Action<GameObject> OnRemove = null;

    private void Awake()
    {
        children = new List<GameObject>();

        foreach (Transform child in transform)
        {
            if (child.GetComponent<Tile>())
            {
                children.Add(child.gameObject);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (dragging)
        {
            if(Input.GetMouseButtonDown(1))
            {
                if(!rotating)
                {
                    currentRotation = transform.rotation; //transform.rotation
                    finalRotation = Quaternion.Euler(0f, 0f, 90f) * transform.rotation; //transform.rotation

                    rotating = true;
                }
            }

            transform.position = mouseWorldPosition;// - mouseOffset;

            //r.Log(transform.position);


            // check if piece is able to be placed
            canPlacePiece = true;

            foreach(GameObject child in children)
            {
                Tile childTile = child.GetComponent<Tile>();
                if(!childTile.canPlacePiece || childTile.closestTile == null)
                {
                    canPlacePiece = false;
                }
            }

            //Debug.Log("can place: " + canPlacePiece);
        }

        if(rotating)
        {
            if(rotationTimer < 1f)
            {
                transform.rotation = Quaternion.Lerp(currentRotation, finalRotation, rotationTimer);
                rotationTimer += (Time.deltaTime * rotationSpeed);
            }
            else
            {
                transform.rotation = finalRotation;
                rotationTimer = 0f;
                rotating = false;
            }
        }

    }
    private void OnMouseDown()
    {
        //Debug.Log("DOWN");
        mouseOffset = mouseWorldPosition - (Vector2) transform.position;
        dragging = true;

        if(placed)
        {
            foreach (GameObject child in children)
            {
                GameObject gridTileObject = child.GetComponent<Tile>().closestTile;
                Tile gridTile = gridTileObject.GetComponent<Tile>();
                gridTile.occupied = false;
            }

            placed = false;
            OnRemove?.Invoke(this.gameObject);
        }
    }

    private void OnMouseUp()
    {
        //Debug.Log("");
        dragging = false;

        // Place Piece here
        if(canPlacePiece)
        {
            GameObject firstTileObject = children[0];
            Tile firstTile = firstTileObject.GetComponent<Tile>();

            float halfTileSize = firstTileObject.GetComponent<Collider2D>().bounds.size.x / 2f;

            // check if within acceptable bounds so we don't get a piece sticking off of the grid
            Bounds bounds = DetermineCompositeBounds(gameObject);
            Vector2 min = bounds.min;
            Vector2 max = bounds.max;

            //DrawBounds(bounds);

            if(min.x < packingManager.minBound.x - halfTileSize)
            {
                return;
            }

            if(min.y < packingManager.minBound.y - halfTileSize)
            {
                return;
            }

            if(max.x > packingManager.maxBound.x + halfTileSize)
            {
                return;
            }

            if(max.y > packingManager.maxBound.y + halfTileSize)
            {
                return;
            }

            Vector2 offset = firstTile.closestTile.transform.position - firstTileObject.transform.position;

            //Debug.DrawLine(firstTile.closestTile.transform.position, firstTileObject.transform.position, Color.green, 1000f);
            //Debug.Log("OFFSET: " + offset);

            transform.position = new Vector3(transform.position.x + offset.x, transform.position.y + offset.y, transform.position.z);

            foreach (GameObject child in children)
            {
                GameObject gridTileObject = child.GetComponent<Tile>().closestTile;
                Tile gridTile = gridTileObject.GetComponent<Tile>();
                gridTile.occupied = true;
            }

            placed = true;

            OnSuccessfulPlace?.Invoke(this.gameObject);
        }
    }


    private void DrawBounds(Bounds bounds)
    {
        Vector2 min = bounds.min;
        Vector2 max = bounds.max;
        Vector2 topRight = new Vector2(max.x, min.y);
        Vector2 bottomLeft = new Vector2(min.x, max.y);

        Debug.DrawLine(min, topRight, Color.yellow, 1000f);
        Debug.DrawLine(bottomLeft, max, Color.yellow, 1000f);
        Debug.DrawLine(min, bottomLeft, Color.yellow, 1000f);
        Debug.DrawLine(topRight, max, Color.yellow, 1000f);
    }

    private Bounds DetermineCompositeBounds(GameObject go)
    {
        List<BoxCollider2D> colliders = new List<BoxCollider2D>();

        foreach (Transform child in go.transform)
        {
            if (child.GetComponent<BoxCollider2D>())
            {
                colliders.Add(child.GetComponent<BoxCollider2D>());
            }
        }


        //BoxCollider2D[] colliders = GetComponents<BoxCollider2D>();

        float minX = float.MaxValue;
        float minY = float.MaxValue;
        float maxX = float.MinValue;
        float maxY = float.MinValue;

        foreach(BoxCollider2D collider in colliders)
        {
            if(collider.bounds.min.x < minX)
            {
                minX = collider.bounds.min.x;
            }

            if (collider.bounds.min.y < minY)
            {
                minY = collider.bounds.min.y;
            }

            if (collider.bounds.max.x > maxX)
            {
                maxX = collider.bounds.max.x;
            }

            if (collider.bounds.max.y > maxY)
            {
                maxY = collider.bounds.max.y;
            }

            //Debug.Log(collider.bounds.min.x + " " + collider.bounds.min.y + " " + collider.bounds.max.x + " " + collider.bounds.max.y);
        }

        //Debug.Log("FINAL: " + minX + " " + minY + " " + maxX + " " + maxY);

        return new Bounds(go.transform.position, new Vector3(maxX - minX, maxY - minY, 0f));
    }
}
