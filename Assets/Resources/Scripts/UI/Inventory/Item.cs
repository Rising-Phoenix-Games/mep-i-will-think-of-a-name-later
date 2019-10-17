using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Item: MonoBehaviour
{
    public string id;
    public string title;
    public double weight;
    public Sprite pic;
    public bool equiped;
    public Dictionary<string, int> stats = new Dictionary<string, int>();

    public Item (string id, string title, double weight, Sprite pic, Dictionary<string, int> stats, bool equiped) {
        this.title = title;
        this.weight = weight;
        this.pic = Resources.Load<Sprite>("Art/items/" + id);
        this.stats = stats;
        this.id = id;
        this.equiped = equiped;
    }
    public Item(Item item) {
        this.title = item.title;
        this.weight = item.weight;
        this.pic = Resources.Load<Sprite>("Art/items/" + item.id);
        this.stats = item.stats;
        this.id = item.id;
        this.equiped = item.equiped;
    }
}
