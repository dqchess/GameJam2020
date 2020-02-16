using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public int id;

    public bool canDrawBorder = false;
    public Color borderColor = Color.black;

    private Vector2 size = Vector2.zero;

    private List<Collider2D> contactTiles;

    public bool canPlacePiece = false;

    public GameObject closestTile = null;

    public bool occupied = false;

    private void Awake()
    {
        contactTiles = new List<Collider2D>();
    }

    private void Start()
    {
        size = GetComponent<Collider2D>().bounds.size;
        //contactTiles = new List<Collider2D>();
    }

    void Update()
    {
        closestTile = null;

        if (contactTiles.Count > 0)
        {
            FindClosestCollidedTile();
            if(!closestTile.GetComponent<Tile>().occupied)
            {
                canPlacePiece = true;
            }
            else
            {
                canPlacePiece = false;
            }
        }

        if (canDrawBorder)
        {
            Vector2 topLeft = new Vector2(transform.position.x - (size.x / 2f), transform.position.y - (size.y / 2f));
            Vector2 bottomRight = new Vector2(transform.position.x + (size.x / 2f), transform.position.y + (size.y / 2f));

            Debug.DrawLine(topLeft, new Vector2(bottomRight.x, topLeft.y), borderColor);
            Debug.DrawLine(new Vector2(bottomRight.x, topLeft.y), bottomRight, borderColor);
            Debug.DrawLine(bottomRight, new Vector2(topLeft.x, bottomRight.y), borderColor);
            Debug.DrawLine(new Vector2(topLeft.x, bottomRight.y), topLeft, borderColor);
        }
    }

    private void FindClosestCollidedTile()
    {
        float minDistance = float.MaxValue;

        foreach(Collider2D collider in contactTiles)
        {
            float distance = Vector2.Distance(transform.position, collider.transform.position);

            if(distance < minDistance)
            {
                minDistance = distance;
                closestTile = collider.gameObject;
            }
        }

        if(closestTile == null)
        {
            closestTile = contactTiles[0].gameObject;
            Debug.Log("Error: Tile: could not determine closest grid tile.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("GridTile"))
        {
            contactTiles.Add(collision);
            //Debug.Log("ADDED:" + id + " / count: " + contactTiles.Count);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("GridTile"))
        {
            contactTiles.Remove(collision);
            //Debug.Log("REMOVED:" + id + " / count: " + contactTiles.Count);
        }
    }
}
