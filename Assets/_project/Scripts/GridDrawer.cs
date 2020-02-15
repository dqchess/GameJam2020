using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridDrawer : MonoBehaviour
{
    public bool canDrawGrid = false;

    // universal grid scale
    public float gridScale = 2f;

    // extents of the grid
    public int minX = -3;
    public int minY = -3;
    public int maxX = 3;
    public int maxY = 3;

    // nudges the whole grid rel
    public Vector3 gridOffset = Vector3.zero;

    // is this an XY or an XZ grid?
    public bool topDownGrid = false;

    // choose a colour for the gizmos
    public int gizmoMajorLines = 3;
    //public Color gizmoLineColor = new Color(0.4f, 0.4f, 0.3f, 1f);
    public Color gizmoLineColor = Color.black;

    private void OnDrawGizmos()
    {
        if (canDrawGrid)
        {
            // orient to the gameobject, so you can rotate the grid independently if desired
            Gizmos.matrix = transform.localToWorldMatrix;

            // set colours
            Color dimColor = new Color(gizmoLineColor.r, gizmoLineColor.g, gizmoLineColor.b, 0.25f * gizmoLineColor.a);
            Color brightColor = Color.Lerp(Color.white, gizmoLineColor, 0.75f);

            // draw the horizontal lines
            for (int x = minX; x < maxX + 1; x++)
            {
                // find major lines
                Gizmos.color = (x % gizmoMajorLines == 0 ? gizmoLineColor : dimColor);
                if (x == 0)
                   Gizmos.color = dimColor;

                Vector3 pos1 = new Vector3(x, minY, 0) * gridScale;
                Vector3 pos2 = new Vector3(x, maxY, 0) * gridScale;

                // convert to topdown/overhead units if necessary
                if (topDownGrid)
                {
                    pos1 = new Vector3(pos1.x, 0, pos1.y);
                    pos2 = new Vector3(pos2.x, 0, pos2.y);
                }

                Gizmos.DrawLine((gridOffset + pos1), (gridOffset + pos2));
            }

            // draw the vertical lines
            for (int y = minY; y < maxY + 1; y++)
            {
                // find major lines
                Gizmos.color = (y % gizmoMajorLines == 0 ? gizmoLineColor : dimColor);
                if (y == 0)
                    Gizmos.color = dimColor;

                Vector3 pos1 = new Vector3(minX, y, 0) * gridScale;
                Vector3 pos2 = new Vector3(maxX, y, 0) * gridScale;

                // convert to topdown/overhead units if necessary
                if (topDownGrid)
                {
                    pos1 = new Vector3(pos1.x, 0, pos1.y);
                    pos2 = new Vector3(pos2.x, 0, pos2.y);
                }

                Gizmos.DrawLine((gridOffset + pos1), (gridOffset + pos2));
            }
        }
    }
}
