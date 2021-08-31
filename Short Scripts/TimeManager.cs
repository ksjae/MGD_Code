using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public Button pause, play, fast, faster;
    public int playTime, fastTime, fasterTime;
    public System.DateTime date;
    [SerializeField] Manager state;
    // Start is called before the first frame update
    void Start()
    {
        pause.onClick.AddListener(() => {state.TimeToNextDay = 0;});
        play.onClick.AddListener(() => {state.TimeToNextDay = playTime;});
        fast.onClick.AddListener(() => {state.TimeToNextDay = fastTime;});
        faster.onClick.AddListener(() => {state.TimeToNextDay = fasterTime;});
    }

    // Update is called once per frame
    void Update()
    {
    }
}
