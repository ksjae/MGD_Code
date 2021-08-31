using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnClickNewGame()
    {
        Debug.Log("새 게임");
    }

    public void OnClickLoad()
    {
        Debug.Log("불러오기");
    }

    public void OnClickCustomgame()
    {
        Debug.Log("사용자겜");
    }

    public void OnClickOption()
    {
        Debug.Log("옵션");
    }

    // 종료 버튼을 눌렀을 때 버튼이 호출할 함수
    public void OnClickQuit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit(); // 실행되고 있는 게임 프로그램을 종료
        #endif
    }
}
