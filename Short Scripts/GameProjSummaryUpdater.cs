using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameProjSummaryUpdater : MonoBehaviour
{
    [SerializeField] Manager state;
    [SerializeField] GameObject designStat, codeStat, qaStat;
    public GameProject project;
    public Slider designBar, codeBar, graphicBar, soundBar;
    public TextMeshProUGUI designPts, codePts, graphicPts, soundPts;
    // Start is called before the first frame update
    void Start()
    {
        designPts.text="0";
        codePts.text="0";
        graphicPts.text="0";
        soundPts.text="0";
    }

    // Update is called once per frame
    void Update()
    {
        soundBar.value += 0.001f;
        if (soundBar.value >= 0.99f) soundBar.value = 0.0f;
    }
}
