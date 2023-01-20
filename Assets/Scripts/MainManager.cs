using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    public Color TeamColor;

    private void Awake()
    {
        if (Instance != null)
        {
            //すでにインスタンスが作成済みの場合は、何もせず自身を破棄する。
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadColor();
    }

    public void SaveColor()
    {
        SaveData data = new SaveData();
        data.TeamColor = TeamColor;

        string json = JsonUtility.ToJson(data);

        string path = Application.persistentDataPath + "/savefile.json";
        File.WriteAllText(path, json);

        Debug.Log("SaveColor : paht" + path);
        Debug.Log("SaveColor : json" + json);
    }

    public void LoadColor()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            TeamColor = data.TeamColor;

            Debug.Log("LoadColor : paht" + path);
            Debug.Log("LoadColor : json" + json);
        }
        else
        {
            Debug.Log("LoadColor : paht not found.");
        }
    }


    [System.Serializable]
    class SaveData
    {
        public Color TeamColor;
    }

}
