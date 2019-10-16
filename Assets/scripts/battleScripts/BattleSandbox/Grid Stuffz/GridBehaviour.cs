using System.Collections.Generic;
using UnityEngine;
using Utilities;

public enum Directions //Csak azért, hogy olvashatóbb legyen a kód.
{
    Up, Right, Down, Left
}

public class GridBehaviour : MonoBehaviour
{
    /**
     * Alapjában véve ez a script az AI, ami az útkeresést végzéi.
     * Magához a kereséshez a Hullámfront-terjesztés algoritmust használjuk, annak is a von Neumann szomszédság féle verzióját.
     * Vagyis, csak élek mentén keresünk szomszédokat, így a négyzetnek csak 4 szomszédja lesz:
     *   1                      0           Up
     * 4 C 2  A mi esetünkben 3 C 1 => Left C Right
     *   3                      2          Down
    **/

    //TODO: Láthatósági paraméterek beállítása

    //Grid méretek
    public int rows = 10;
    public int columns = 10;
    public int scale = 1;  //Távolág az elemek között, méretarány megtartása végett

    //A grid létrehozásához használt sprite
    public GameObject gridPrefab;

    public Vector3 leftBottomLocation = new Vector3(0, 0, 0); //Bal alsó sarok
    public GameObject[,] gridArray;

    //Kapcsoló, hogy csak akkor keressen utat, amikor szükség van rá
    public bool findDistance = false;

    //A karakter kezdő pozíciója a griden
    //TODO: Nagyjából véletlenszerűen elhelyezni őket a grid szélén
    public int startX = 0;
    public int startY = 0;

    //A karakter céljának pozíciója.
    //TODO: Input alapján meghatározni a pozíciót
    public int endX = 2;
    public int endY = 2;

    //A legrövidebb utat tartalmazó mezők listája
    public List<GameObject> path = new List<GameObject>();

    GridBase grid;

    private void Awake()
    {
        gridArray = new GameObject[columns, rows];

        if (gridPrefab)
        {            
           GenerateGrid();
        }
        else
        {
            print("Missing grid prefab, please assign.");
        }

        grid = new GridBase(columns, rows, scale, leftBottomLocation);
    }

    private void Update()
    {
        if (findDistance)
        {
            SetDistance();
            SetPath();

            findDistance = false;
        }

        //Teszteléshez: Bal egér beír, Jobb egér kiolvas
        if (Input.GetMouseButtonDown(0))
        {
            grid.SetValue(UtilsClass.GetMouseWorldPosition(), 56);
        }
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log(grid.GetValue(UtilsClass.GetMouseWorldPosition()));
        }
    }

    //Grid háló létrehozása. Dun, Dunn, Duunn
    void GenerateGrid()
    {
        //Oszlopok feltöltése
        for (int col = 0; col < columns; col++)
        {
            //Sorok feltöltése
            for (int row = 0; row < rows; row++)
            {
                GameObject tile = Instantiate(gridPrefab, new Vector3(leftBottomLocation.x + (scale * col), leftBottomLocation.y + (scale * row),
                                             leftBottomLocation.z), Quaternion.identity);

                tile.transform.SetParent(gameObject.transform);
                tile.GetComponent<GridStat>().x = col;
                tile.GetComponent<GridStat>().y = row;

                //Hozzárendelés a grid tömbhöz
                gridArray[col, row] = tile;
            }
        }
    }

    void SetDistance()
    {
        InitialSetUp();
        int x = startX;
        int y = startY;
        int[] testArray = new int[rows * columns];

        for (int step = 1; step < (rows * columns); step++)
        {
            foreach (GameObject obj in gridArray)
            {
                //Az ellenörző hullámok csak előrefelé terjednek, hogy véletlenül se írják felül a már megvizsgált mezők értékét.
                if (obj && obj.GetComponent<GridStat>().visited == step - 1)
                {
                    TestFourDirections(obj.GetComponent<GridStat>().x, obj.GetComponent<GridStat>().y, step);
                }
            }
        }
    }
    
    void SetPath()
    {
        int step;
        int x = endX;
        int y = endY;

        List<GameObject> tempList = new List<GameObject>();
        path.Clear();

        if (gridArray[endX, endY] && gridArray[endX, endY].GetComponent<GridStat>().visited > 0)
        {
            path.Add(gridArray[x, y]);
            step = gridArray[x, y].GetComponent<GridStat>().visited - 1;
        }
        else
        {
            //Itt majd talán lehetne egy spec kurzor visszajelzést adni, a kiírás helyett.
            print("Can't reach the deisred location.");
            return;
        }

        for (int i = step; step > -1; step--)
        {
            if (TestDirection(x, y, step, Directions.Up))
            {
                tempList.Add(gridArray[x + 1, y]);
            }
            if (TestDirection(x, y, step, Directions.Right))
            {
                tempList.Add(gridArray[x, y + 1]);
            }
            if (TestDirection(x, y, step, Directions.Down))
            {
                tempList.Add(gridArray[x, y - 1]);
            }
            if (TestDirection(x, y, step, Directions.Left))
            {
                tempList.Add(gridArray[x - 1, y]);
            }

            //Megkeresi a célhoz legközelebbi cellát az adott hullámból, és hozzáadja a útvonal listához.
            GameObject tempObject = FindClosest(gridArray[endX, endY].transform, tempList);

            //Minimális vizualizáció, nem tűnik el a régi út
            tempObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
            path.Add(tempObject);

            x = tempObject.GetComponent<GridStat>().x;
            y = tempObject.GetComponent<GridStat>().y;

            tempList.Clear();
        }        
    }

    //Alap beállítás az útkeresés számára
    void InitialSetUp()
    {
        foreach (GameObject obj in gridArray)
        {
            obj.GetComponent<GridStat>().visited = -1;
        }

        gridArray[startX, startY].GetComponent<GridStat>().visited = 0;
    }

    private bool TestDirection(int x, int y, int step, Directions direction)
    {
        switch (direction)
        {            
            case Directions.Left:
                if (x - 1 > -1 && gridArray[x - 1, y] && gridArray[x - 1, y].GetComponent<GridStat>().visited == step)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            case Directions.Down:
                if (y - 1 > -1 && gridArray[x, y - 1] && gridArray[x, y - 1].GetComponent<GridStat>().visited == step)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            case Directions.Right:
                if (x + 1 < columns && gridArray[x + 1, y] && gridArray[x + 1, y].GetComponent<GridStat>().visited == step)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            case Directions.Up:
                if (y + 1 < rows && gridArray[x, y + 1] && gridArray[x, y + 1].GetComponent<GridStat>().visited == step)
                {
                    return true;
                }
                else
                {
                    return false;
                }           
        }
        return false;
    }

    //Mezők többszörös ellenőrzésének elkerülés végett kell.
    //Csak akkor állít be lépésszámot, ha az előző hullámban még nem jártunk itt.
    void TestFourDirections(int x, int y, int step)
    {
        if (TestDirection(x, y, -1, Directions.Up))
        {
            SetVisited(x, y + 1, step);
        }
        if (TestDirection(x, y, -1, Directions.Right))
        {
            SetVisited(x +1, y, step);
        }
        if (TestDirection(x, y, -1, Directions.Down))
        {
            SetVisited(x, y - 1, step);
        }
        if (TestDirection(x, y, -1, Directions.Right))
        {
            SetVisited(x - 1, y, step);
        }
    }

    void SetVisited(int x, int y, int step)
    {
        if (gridArray[x, y])
        {
            gridArray[x, y].GetComponent<GridStat>().visited = step;
        }
    }

    GameObject FindClosest(Transform targetLocation, List<GameObject> list)
    {
        float currentDistance = scale * rows * columns;
        int indexNumber = 0;

        for (int i = 0; i < list.Count; i++)
        {
            if (Vector3.Distance(targetLocation.position, list[i].transform.position) < currentDistance)
            {
                currentDistance = Vector3.Distance(targetLocation.position, list[i].transform.position);
                indexNumber = i;
            }
        }

        return list[indexNumber];
    }
}
