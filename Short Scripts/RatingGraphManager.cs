using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RatingGraphManager : MonoBehaviour
{
    [SerializeField] Manager status;
    Material m_Material;
    // Start is called before the first frame update
    void Start()
    {
        m_Material = gameObject.GetComponent<Image>().material;
    }

    // Update is called once per frame
    void Update()
    {
        m_Material.SetFloat("_Progress", status.Company.rating);
    }
}
