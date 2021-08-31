using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MiniInfoUpdater : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI m_Object;
    [SerializeField] Manager state;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Sprite companyLogo;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        m_Object.text = state.Company.Name;
    }
}
