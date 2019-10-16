using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

/*
 * Grid Generálása átmozgatva ide, hogy meg legyen a saját script-je.
 */

public class GridBase
{
    private int width;
    private int height;
    private float cellSize;
    private Vector3 originPosition;
    private int[,] gridArray;
    private TextMesh[,] debugTextArray;

    public GridBase(int width, int height, float cellSize, Vector3 originPosition)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.originPosition = originPosition;

        gridArray = new int[width, height];
        debugTextArray = new TextMesh[width, height];

        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                //Debug.Log(x + (" ") + y);
                debugTextArray[x, y] = UtilsClass.CreateWorldText(gridArray[x, y].ToString(), null, GetWorldPosition(x, y) +
                                                                 (new Vector3(cellSize, cellSize) * .5f), 5, Color.white, TextAnchor.MiddleCenter);
            }
        }
    }

    //Átkonvertálja a grid pozíciót world pozícióvá
    private Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * cellSize + originPosition;
    }

    //Átkonvertálja a world pozíciót grid pozícióvá
    private void GetXY(Vector3 worldPosition, out int x, out int y)
    {
        x = Mathf.FloorToInt((worldPosition - originPosition).x / cellSize);
        y = Mathf.FloorToInt((worldPosition - originPosition).y / cellSize);
    }

    //Beállít egy értéket az adott cellénak, ignorálva a helytelen értékeket.
    //Grid pozíciót használva
    public void SetValue(int x, int y, int value)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            gridArray[x, y] = value;
            debugTextArray[x, y].text = gridArray[x, y].ToString();
        }        
    }

    //World pozíciót használva
    public void SetValue(Vector3 worldPosition, int value)
    {
        GetXY(worldPosition, out int x, out int y);
        SetValue(x, y, value);
    }

    //Értéket olvas ki az adott cellából
    //Grid pozíciót használva
    public int GetValue(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            return gridArray[x, y];
        }
        else
        {
            return 0;
        }
    }

    //World pozíciót használva
    public int GetValue(Vector3 worldPosition)
    {
        GetXY(worldPosition, out int x, out int y);

        return GetValue(x, y);
    }
}
