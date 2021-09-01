using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShiftUIShape : MonoBehaviour
{
    [SerializeField] GameObject BigSideBar, SmallSideBar;
    [SerializeField] RectTransform ContentRT;
    private bool isbarMin = false;
    private bool isGlobalView = false;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnClickMinMax(){
        isbarMin = !isbarMin;
        if (isbarMin){
            BigSideBar.SetActive(false);
            SmallSideBar.SetActive(true);
            ContentRT.sizeDelta = new Vector2(1920-80,0);
            ContentRT.anchoredPosition = new Vector2(40,0);
            
        } else {
            BigSideBar.SetActive(true);
            SmallSideBar.SetActive(false);
            ContentRT.sizeDelta = new Vector2(1920-250,0);
            ContentRT.anchoredPosition = new Vector2(125,0);
        }
    }
    public void OnClickGoGlobalView(){

    }
}
