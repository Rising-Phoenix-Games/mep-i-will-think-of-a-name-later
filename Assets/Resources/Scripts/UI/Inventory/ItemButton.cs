using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ItemButton : MonoBehaviour
{
    public GameObject toolTip;

    // Start is called before the first frame update
    void Start()
    {
        //toolTip.SetActive(false);
        toolTip.GetComponent<CanvasGroup>().alpha = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        toolTip.transform.position = Input.mousePosition;        
    }

    public void hideTooltip() {
        toolTip.GetComponent<CanvasGroup>().alpha = 0f;
    }

    public void showTooltip() {
        toolTip.GetComponent<CanvasGroup>().alpha = 1f;
    }
}
