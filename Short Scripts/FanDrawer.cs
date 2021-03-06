using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class FanDrawer : MonoBehaviour
{
    public GameObject graphBar;
    public Material UIMaterial;
    public int count=0, margin=0;
    [SerializeField] Manager state;

    UnityEvent dayPasses = new UnityEvent();
    private int[] _followerHistory={0,0,0,0,0,0,0,0,0,0,0,0};
    private int maxVal = 1;
    void Start()
    {
        _followerHistory = state.FollowerHistory(12);
        maxVal = _followerHistory.Max();
        if (maxVal == 0){ //STOP DBZ
            maxVal = 1;
        }
        Draw();
        dayPasses.AddListener(Draw);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Draw(){
        
        foreach (Transform child in transform) {
            GameObject.Destroy(child.gameObject);
        }
        for(int i=0;i<count;i++){
            Material mat =  Instantiate(UIMaterial);
            mat.SetFloat("_Progress", GetProgress(i));
            GameObject bar = Instantiate(graphBar, new Vector3(i*margin, 0, 0), Quaternion.Euler(0,0,90), gameObject.transform);
            bar.GetComponent<Image>().material = mat;
            //Debug.Log(GetProgress(i));
        }
    }

    float GetProgress(int index){
        return (float)_followerHistory[index]/maxVal;
    }
}
