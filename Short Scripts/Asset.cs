using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asset : MonoBehaviour
{
    [SerializeField] Manager state;
    public int money=1923870000;
    void Start()
    {
        money = state.Company.asset;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
