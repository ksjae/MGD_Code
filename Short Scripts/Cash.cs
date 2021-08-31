using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cash : MonoBehaviour
{
    [SerializeField] Manager state;
    public int money=3728400;
    void Start()
    {
        money = state.Company.cash;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
