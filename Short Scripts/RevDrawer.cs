using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RevDrawer : MonoBehaviour
{
    public GameObject graphBar;
    public Material UIMaterial;
    public int count=0, margin=0;

    UnityEvent dayPasses = new UnityEvent();
    private int[] _revenueHistory={34632,34765,31857,98121,21634,21389,21347,56432,23476,76584,12347,87652};
    private int maxVal = 1;
    void Start()
    {
        maxVal = _revenueHistory.Max();
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
        return (float)_revenueHistory[index]/maxVal;
    }
}
