using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class InvenList : MonoBehaviour
{
    public List<Item> inventory;
    public InvenFileStuff InvenFileStuff;
    public GameObject buttonPrefab;
    public GameObject invenItems;
    public GameObject inventoryList;
    public int numOfItems = 0;

    // Start is called before the first frame update
    void Start()
    {
        inventoryList = this.gameObject;
        InvenList invenList = inventoryList.AddComponent<List<Item>()>();

        InvenFileStuff = new InvenFileStuff();

        inventory = new List<Item>();

        InvenFileStuff.Load();

        foreach (Item item in inventory)
        {
            numOfItems++;

            GameObject itemButton = GameObject.Instantiate(buttonPrefab);

            itemButton.GetComponent<RectTransform>().SetParent(invenItems.transform);

            float maxAnchorY = itemButton.GetComponent<RectTransform>().anchorMax.y;
            maxAnchorY = (float) (100-(16.6666666666666666*(numOfItems - 1))/100);

            float minAnchorY = itemButton.GetComponent<RectTransform>().anchorMin.y;
            minAnchorY = (float) (100-(16.6666666666666666*(numOfItems))/100);

            itemButton.GetComponent<RectTransform>().offsetMax = Vector2.zero;
            itemButton.GetComponent<RectTransform>().offsetMin = Vector2.zero;


            Text toolTip = GameObject.Find(itemButton.name + "/Tooltip/Text").GetComponent<Text>();

            toolTip.GetComponent<Text>().text = "moo";
        }
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
