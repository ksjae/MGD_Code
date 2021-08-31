using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarGraphManager : MonoBehaviour
{
    public float progress=0.5f;
    Material m_Material;
    // Start is called before the first frame update
    void Start()
    {
        m_Material = gameObject.GetComponent<Image>().material;
    }

    // Update is called once per frame
    void Update()
    {
        m_Material.SetFloat("_Progress", progress);
    }
}
