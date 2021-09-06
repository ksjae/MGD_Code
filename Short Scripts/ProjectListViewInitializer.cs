using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ProjectListViewInitializer : MonoBehaviour
{
    [SerializeField] Manager status;
    public GameObject panelPrefab;
    void Start()
    {
        InvokeRepeating("Draw", 5.0f, 100.0f);
    }

    // Update is called once per frame
    void Update()
    {
        Draw();
    }

    void Draw(){
        foreach (Transform child in transform) {
            GameObject.Destroy(child.gameObject);
        }
        foreach (GameProject proj in status.Company.GamesInMaking()) {
            GameObject panel = Instantiate(panelPrefab, new Vector3(0,0,0), Quaternion.Euler(0,0,90), gameObject.transform);
            panel.GetComponent<GameProjSummaryUpdater>().project = proj;
        }
    }
}
