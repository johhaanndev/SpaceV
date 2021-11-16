using UnityEngine;
using System.IO;

public static class SaveManager
{
    public static string directory = "/SaveData/";
    public static string filename = "MyData.txt";

    public static void Save(ClipData clip)
    {
        string dir = Application.persistentDataPath + directory;

        if (!Directory.Exists(dir))
            Directory.CreateDirectory(dir);

        string json = JsonUtility.ToJson(clip);
        File.WriteAllText(dir + filename, json);
    }

    public static ClipData Load()
    {
        string fullpath = Application.persistentDataPath + directory + filename;
        ClipData clip = new ClipData();

        if (File.Exists(fullpath))
        {
            string json = File.ReadAllText(fullpath);
            clip = JsonUtility.FromJson<ClipData>(json);
        }
        else
        {
            Debug.Log("File don't exist");
        }

        return clip;
    }

}
