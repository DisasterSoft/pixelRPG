using System.Data;
using Mono.Data.Sqlite;
using UnityEngine;

public class sqlCreate : MonoBehaviour
{
    public static string dbPath;

    public void Start()
    {
        //dbPath = "URI=file:" + Application.persistentDataPath + "/WalkDating.db";
        //Debug.Log(Application.streamingAssetsPath);
        dbPath = "URI=file:" + Application.persistentDataPath + "/Worewen.db";
       // CreateSchema();
        /*InsertScore("GG Meade", 3701);
        InsertScore("US Grant", 4242);
        InsertScore("GB McClellan", 107);
        GetHighScores(10);*/
    }

    public void CreateSchema()
    {
        using (var conn = new SqliteConnection(dbPath))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "CREATE TABLE IF NOT EXISTS 'profile' ( " +
                                  "  'name' TEXT NOT NULL DEFAULT 'Worewen'," +
                                  "  'loaded' TEXT NOT NULL DEFAULT '0'," +
                                  "  'slot1I' TEXT NOT NULL DEFAULT '0', " +
                                  "  'slot2I' TEXT NOT NULL DEFAULT '0', " +
                                  "  'slot3I' TEXT NOT NULL DEFAULT '0', " +
                                  "  'slot4I' TEXT NOT NULL DEFAULT '0', " +
                                  "  'slot5I' TEXT NOT NULL DEFAULT '0', " +
                                  "  'slot6I' TEXT NOT NULL DEFAULT '0', " + 
                                  "  'slot1T' TEXT NOT NULL DEFAULT '0', " +
                                  "  'slot2T' TEXT NOT NULL DEFAULT '0', " +
                                  "  'slot3T' TEXT NOT NULL DEFAULT '0', " +
                                  "  'slot4T' TEXT NOT NULL DEFAULT '0', " +
                                  "  'slot5T' TEXT NOT NULL DEFAULT '0', " +
                                  "  'slot6T' TEXT NOT NULL DEFAULT '0', " +
                                  "  'Money' TEXT NOT NULL DEFAULT '0', " +
                                  "  'Cards' TEXT NOT NULL DEFAULT '0', " +
                                  "  'Coordinate' TEXT NOT NULL DEFAULT '0', " +
                                  "  'loadCount' TEXT NOT NULL DEFAULT '0', " +
                                  "  'ObjectHelper' TEXT NOT NULL " +
                                  ");";
                var result = cmd.ExecuteNonQuery();
                Debug.Log("create schema: " + result);
                CheckIfExixst();
              
                cmd.Dispose();
                conn.Close();
            }
        }
    }
    public  void addSlotnonStatic(int slot,int db, string type)
    {
        Debug.Log("addSlotnonStatic"+slot+","+db+","+type);
        string sqlCMD="";
        string returnValue = "";
        string realDB = "";
        switch(slot)
        {
            case 1:
                Debug.Log("bejött slot1 add");
                returnValue = getData("slot1I");
                realDB = (int.Parse(returnValue) + db).ToString();
                sqlCMD= "Update  profile set slot1I='"+ realDB + "',  slot1T='"+type+"' where name = 'Worewen'";
                Debug.Log("bejött slot1 add "+ sqlCMD);
                break;
            case 2:
                returnValue = getData("slot2I");
                realDB = (int.Parse(returnValue) + db).ToString();
                sqlCMD = "Update  profile set slot2I=" + realDB + "  ,slot2T='" + type + "' where name = 'Worewen'";
                break;
            case 3:
                returnValue = getData("slot3I");
                realDB = (int.Parse(returnValue) + db).ToString();
                sqlCMD = "Update  profile set slot3I=" + realDB + ",  slot3T='" + type + "' where name = 'Worewen'";
                break;
            case 4:
                returnValue = getData("slot4I");
                realDB = (int.Parse(returnValue) + db).ToString();
                sqlCMD = "Update  profile set slot4I=s" + realDB + ",  slot4T='" + type + "' where name = 'Worewen'"; ;
                break;
            case 5:
                returnValue = getData("slot5I");
                realDB = (int.Parse(returnValue) + db).ToString();
                sqlCMD = "Update  profile set slot5I=" + realDB + " , slot5T='" + type + "' where name = 'Worewen'";
                break;
            case 6:
                returnValue = getData("slot6I");
                realDB = (int.Parse(returnValue) + db).ToString();
                sqlCMD = "Update  profile set slot6I=" + realDB + " , slot6T='" + type + "' where name = 'Worewen'";
                break;
        }
        using (var conn = new SqliteConnection(dbPath))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sqlCMD;
                var result = cmd.ExecuteNonQuery();
                cmd.Dispose();
                conn.Close();
            }
        }
    }
    public static void addSlot(int slot,int db, string type)
    {
        string sqlCMD = "";
        string returnValue = "";
        string realDB = "";
        switch (slot)
        {
            case 1:
                returnValue = getData("slot1I");
                realDB = (int.Parse(returnValue) + db).ToString();
                sqlCMD = "Update  profile set slot1I=" + realDB + ", slot1T='" + type + "' where name = 'Worewen'";
                break;
            case 2:
                returnValue = getData("slot2I");
                realDB = (int.Parse(returnValue) + db).ToString();
                sqlCMD = "Update  profile set slot2I=" + realDB + ",  slot2T='" + type + "' where name = 'Worewen'";
                break;
            case 3:
                returnValue = getData("slot3I");
                realDB = (int.Parse(returnValue) + db).ToString();
                sqlCMD = "Update  profile set slot3I=" + realDB + ",  slot3T='" + type + "' where name = 'Worewen'";
                break;
            case 4:
                returnValue = getData("slot4I");
                realDB = (int.Parse(returnValue) + db).ToString();
                sqlCMD = "Update  profile set slot4I=s" + realDB + ",  slot4T='" + type + "' where name = 'Worewen'"; ;
                break;
            case 5:
                returnValue = getData("slot5I");
                realDB = (int.Parse(returnValue) + db).ToString();
                sqlCMD = "Update  profile set slot5I=" + realDB + " , slot5T='" + type + "' where name = 'Worewen'";
                break;
            case 6:
                returnValue = getData("slot6I");
                realDB = (int.Parse(returnValue) + db).ToString();
                sqlCMD = "Update  profile set slot6I=" + realDB + ",  slot6T='" + type + "' where name = 'Worewen'";
                break;
        }
        using (var conn = new SqliteConnection(dbPath))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sqlCMD;
                var result = cmd.ExecuteNonQuery();
              
                cmd.Dispose();
                conn.Close();
            }
        }
    }
    public static void fillRecord()
    {
        using (var conn = new SqliteConnection(dbPath))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Insert into profile (Cards,ObjectHelper) values('','')";
                var result = cmd.ExecuteNonQuery();
                CheckIfExixst();
                cmd.Dispose();
                conn.Close();
            }
        }
    }
    
    public void insertMoneyNotStatic(string money) 
    {
        insertMoney(money);
    }
    public static void insertMoney(string money)
    {
        string retunrValue = getData("Money");
        string realMoney = (int.Parse(money) + int.Parse(retunrValue)).ToString();
        using (var conn = new SqliteConnection(dbPath))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Update profile set Money='" + realMoney + "' where name='Worewen';";
                var result = cmd.ExecuteNonQuery();
                cmd.Dispose();
                conn.Close();
            }
        }
    }
    public void InsertScore(string highScoreName, int score)
    {
        using (var conn = new SqliteConnection(dbPath))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO high_score (name, score) " +
                                  "VALUES (@Name, @Score);";

                cmd.Parameters.Add(new SqliteParameter
                {
                    ParameterName = "Name",
                    Value = highScoreName
                });

                cmd.Parameters.Add(new SqliteParameter
                {
                    ParameterName = "Score",
                    Value = score
                });

                var result = cmd.ExecuteNonQuery();
                Debug.Log("insert score: " + result);
                cmd.Dispose();
                conn.Close();
            }
        }
    }  
    public static string getData(string what)
    {
        string returnValue = "";
        using (var conn = new SqliteConnection(dbPath))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT "+what+" FROM profile";
                var reader = cmd.ExecuteReader();
              
                while (reader.Read())
                {
                    returnValue = reader.GetString(0);
                 
                }
                reader.Close();
                cmd.Dispose();
                conn.Close();
            }
    }

        return returnValue;
    }
    public static void setData(string what,string value)
    {
       
        using (var conn = new SqliteConnection(dbPath))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                string sqlCMD= "UPDATE profile set " + what + "='" + value + "' where name='Worewen';";
                Debug.Log(sqlCMD);
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sqlCMD;
                var result = cmd.ExecuteNonQuery();
                cmd.Dispose();
                conn.Close();
            }
        }
       
    }
    public static void newStart()
    {
        int i = 0;
        using (var conn = new SqliteConnection(dbPath))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Delete * FROM profile";
                var reader = cmd.ExecuteReader();
                CheckIfExixst();
                reader.Close();
                cmd.Dispose();
                conn.Close();
            }
        }
        
    }
    public static void CheckIfExixst()
    {
        int i = 0;
        using (var conn = new SqliteConnection(dbPath))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM profile";
                var reader = cmd.ExecuteReader();
                Debug.Log("keresem"+reader.FieldCount);
                while (reader.Read())
                {
                    Debug.Log(reader.GetString(0)+"név");
                    Debug.Log(reader.GetString(16)+"slot");
                        i++;
                }
                Debug.Log(i);
                if(i==0)
                { 
                    fillRecord();
                }
                reader.Close();
                cmd.Dispose();
                conn.Close();
            }
        } 
    }  
}



