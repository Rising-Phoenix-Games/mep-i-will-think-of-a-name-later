using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


[System.Serializable]
public class InvenFileStuff
{
    // where should the inventory be saved?
    private string savePath { get { return Path.Combine(Application.persistentDataPath, "inventory.json"); } }
    // items currently in the inventory
    public List<Item> items;
    public InvenFileStuff()
    {
        items = new List<Item>();
    }
    // save the inventory to disk
    public void Save()
    {
        File.WriteAllText(savePath, JsonUtility.ToJson(this));
    }
    // load the inventory from disk
    public void Load()
    {
        if (File.Exists(savePath))
            JsonUtility.FromJsonOverwrite(File.ReadAllText(savePath), this);
    }
}
