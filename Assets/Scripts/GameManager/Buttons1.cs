using UnityEngine;
using UnityEngine.UI;
public class Buttons1 : MonoBehaviour
{
    
    public int sceneChanger; //0=start,1=exit;
    void Start()
    {
        Button btn = GetComponent<Button>();
        switch (sceneChanger)
        {
            case 0: btn.onClick.AddListener(() => GameManager.m_instanceGameManager.StartGame()); break;
            case 1: btn.onClick.AddListener(() => GameManager.m_instanceGameManager.QuitGame()); break;
            default: Debug.Log("Error en buttons1 script"); break;
        }
    }
}
