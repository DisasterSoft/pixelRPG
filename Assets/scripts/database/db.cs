using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class db : MonoBehaviour
{
    public GameObject kkir;
    public static  GameObject kkir_st;
    public static string realPath = "" ;
    public static string realPath2 = "" ;
    public static string path ="" ;
    public static string savePath ="" ;

    public void Awake()
    {
        realPath = Application.persistentDataPath + "/dbWoreven/db.txt";
        realPath2 = Application.persistentDataPath + "/dbWoreven/save.txt";
       
        if (!System.IO.File.Exists(realPath))
        {
            if (!System.IO.Directory.Exists(Application.persistentDataPath + "/dbWoreven/"))
            {
                System.IO.Directory.CreateDirectory(Application.persistentDataPath + "/dbWoreven/");
               
            }
            WWW reader = new WWW(Application.streamingAssetsPath + "/dbWoreven/" + realPath);
            while (!reader.isDone) { }
            System.IO.File.WriteAllBytes(realPath, reader.bytes);
            System.IO.File.WriteAllText(realPath, "Worewen;0;0;0;0;0;0;0;0;0;0;0;0;0;0;;0&0;0;;0,0,0,0,0,0,0,0,0,0");
            reader = new WWW(Application.streamingAssetsPath + "/dbWoreven/" + realPath2);
            while (!reader.isDone) { }
            System.IO.File.WriteAllBytes(realPath2, reader.bytes);
            System.IO.File.WriteAllText(realPath2, "0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;;0&0;0;;0,0,0,0,0,0,0,0,0,0");
        }
        //Application.OpenURL(realPath);
        path = realPath;
        savePath = realPath2;
        kkir_st = kkir;
        kkir_st.GetComponent<Text>().text = path;
    }
    //read the special data from the file
    public static string readTheData(int what)
    {
        string resoult = "";
        string theFile = "";
        StreamReader reader = new StreamReader(path);
        theFile = reader.ReadToEnd();
        string[] theFile_a = theFile.Split(';');
        reader.Close();
        resoult = theFile_a[what];
       /* if(theFile=="")
        {
            StreamWriter writer = new StreamWriter(path, true);
            writer.WriteLine("Worewen;0;0;0;0;0;0;0;0;0;0;0;0;0;0;;0&0;0;;");
            writer.Close();
        }*/

        return resoult;
    }

    public static void addObjectToList(string objectToAdd)
    {
        string theFile = "";
        StreamReader reader = new StreamReader(path);
        theFile = reader.ReadLine();
        reader.Close();
        string[] theFile_a = theFile.Split(';');
        string objects = theFile_a[18] +  objectToAdd+",";
        string newFileText = "";
        for (int i=0;i<theFile_a.Length;i++)
        {
           // Debug.Log(theFile_a[i]+","+i);
            if(i==18)
            {
               // Debug.Log(theFile_a[i].Split(',').Length);
                if (theFile_a[i].Split(',').Length > 1)
                {
                    newFileText = newFileText + ";" + objects;
                }
                else
                {
                    newFileText = newFileText + ";" + objectToAdd+",";
                }
            }
            else if(i==0)
            {
                newFileText = newFileText + theFile_a[i];
            }
            else
            {
                newFileText = newFileText + ";" + theFile_a[i];
            }
        }
        writeTheResult(newFileText);
       
       
    }
    public static void addThingToList(int where,string what)
    {
        kkir_st.GetComponent<Text>().text = "where " + where + " What " + what;
        
        string theFile = "";
        StreamReader reader = new StreamReader(path);
        theFile = reader.ReadLine();
        reader.Close();
        string[] theFile_a = theFile.Split(';');
        string newFileText = "";
        for (int i = 0; i < theFile_a.Length; i++)
        {
            if(i==where)
            {
                newFileText = newFileText + ";" + what;
            }
            else if (i == 0)
            {
                newFileText = newFileText + theFile_a[i];
            }
            else
            {
                newFileText = newFileText + ";" + theFile_a[i];
            }
        }
        writeTheResult(newFileText);
    }
    public static void writeTheResult(string result)
    {
        StreamWriter writer = new StreamWriter(path, false);
        writer.WriteLine(result);
        writer.Close();
    }
    public static void writeTheResultSaveGame(string result)
    {
        StreamWriter writer = new StreamWriter(savePath, false);
        writer.WriteLine(result);
        writer.Close();
    }
    public static void  youLose()
    {
        string newGame = "Worewen;0;0;0;0;0;0;0;0;0;0;0;0;0;0;;0&0;0;;0,0,0,0,0,0,0,0,0,0";
        writeTheResult(newGame);

    }
    public static void  saveGame()
    {
        StreamReader reader = new StreamReader(path);
        string theFile = reader.ReadLine();
        reader.Close();
        writeTheResultSaveGame(theFile);

    }
    public static void loadGame()
    {
        StreamReader reader = new StreamReader(savePath);
        string theFile = reader.ReadLine();
        reader.Close();
        writeTheResult(theFile);
    }

}

/*CREATE TABLE IF NOT EXISTS 'profile' ( " +
                                  "  'name' TEXT NOT NULL DEFAULT 'Worewen'," +0
                                  "  'loaded' TEXT NOT NULL DEFAULT '0'," +1
                                  "  'slot1I' TEXT NOT NULL DEFAULT '0', " +2
                                  "  'slot2I' TEXT NOT NULL DEFAULT '0', " +3
                                  "  'slot3I' TEXT NOT NULL DEFAULT '0', " +4
                                  "  'slot4I' TEXT NOT NULL DEFAULT '0', " +5
                                  "  'slot5I' TEXT NOT NULL DEFAULT '0', " +6
                                  "  'slot6I' TEXT NOT NULL DEFAULT '0', " + 7
                                  "  'slot1T' TEXT NOT NULL DEFAULT '0', " +8
                                  "  'slot2T' TEXT NOT NULL DEFAULT '0', " +9
                                  "  'slot3T' TEXT NOT NULL DEFAULT '0', " +10
                                  "  'slot4T' TEXT NOT NULL DEFAULT '0', " +11
                                  "  'slot5T' TEXT NOT NULL DEFAULT '0', " +12
                                  "  'slot6T' TEXT NOT NULL DEFAULT '0', " +13
                                  "  'Money' TEXT NOT NULL DEFAULT '0', " +14
                                  "  'Cards' TEXT NOT NULL DEFAULT '0', " +15
                                  "  'Coordinate' TEXT NOT NULL DEFAULT '0', " +16
                                  "  'loadCount' TEXT NOT NULL DEFAULT '0', " +17
                                  "  'ObjectHelper' TEXT NOT NULL " +18
                                  "  'quest' TEXT NOT NULL " +19
*/