using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShiftUIShape : MonoBehaviour
{
    public RectTransform BigSideBarRT, SmallSideBarRT, ContentRT;
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
        /*
        if (isbarMin){
            BigSideBarRT.rect.x -= BigSideBarRT.rect.width;
            SmallSideBarRT.rect.x += SmallSideBarRT.rect.width;
            ContentRT.rect.x = SmallSideBarRT.rect.width/2;
            
        } else {
            BigSideBarRT.rect.x += BigSideBarRT.rect.width;
            SmallSideBarRT.rect.x -= SmallSideBarRT.rect.width;
            ContentRT.rect.x = BigSideBarRT.rect.width/2;
        }
        */
    }
    public void OnClickGoGlobalView(){

    }
}
