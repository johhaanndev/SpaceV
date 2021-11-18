using UnityEngine;
using System.IO;

public static class SaveManager
{
    public static string directory = "/SaveData/";
    public static string filename = "MyData.txt";

    public static void Save(ClipData clip)
    {
        //Debug.Log("Saved!");
        string dir = Application.persistentDataPath + directory;

        if (!Directory.Exists(dir))
            Directory.CreateDirectory(dir);

        string json = JsonUtility.ToJson(clip);
        File.WriteAllText(dir + filename, json);
    }
}
