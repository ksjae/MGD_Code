using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DateReader : MonoBehaviour
{
    [SerializeField] Manager state;
    public System.DateTime date;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        date = state.Date;
    }
}
