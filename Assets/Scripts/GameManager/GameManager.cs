using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public interface IRestartGameElement
{
    void RestartGame();
}
public class GameManager : MonoBehaviour
{
    public static GameManager m_instanceGameManager;

    //UI panels
    public GameObject m_startMenuUI;
    public GameObject m_pauseMenuUI;
    public GameObject m_gameOverUI;

    List<IRestartGameElement> m_RestartGameElements = new List<IRestartGameElement>();


    private void Awake()
    {
        if (m_instanceGameManager == null)
        {
            m_instanceGameManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        OpenStartMenu();
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }


    }



    public void OpenStartMenu()
    {
        m_gameOverUI.SetActive(false);
        m_pauseMenuUI.SetActive(false);
        m_startMenuUI.SetActive(true);
        PauseGameSettings();
    }



    public void PauseGame()
    {
        m_gameOverUI.SetActive(false);
        m_startMenuUI.SetActive(false);
        m_pauseMenuUI.SetActive(true);
        PauseGameSettings();
    }

    public void ResumeGame()
    {
        m_gameOverUI.SetActive(false);
        m_startMenuUI.SetActive(false);
        m_pauseMenuUI.SetActive(false);
        ResumeGameSettings();
    }

    public void GameOver()
    {
        m_pauseMenuUI.SetActive(false);
        m_startMenuUI.SetActive(false);
        m_gameOverUI.SetActive(true);
        PauseGameSettings();
    }

    public void QuitGame()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }

    private void PauseGameSettings()
    {
        Time.timeScale = 0.0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void ResumeGameSettings()
    {
        Time.timeScale = 1.0f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    public void AddRestartGameElement(IRestartGameElement RestartGameElement)
    {
        m_RestartGameElements.Add(RestartGameElement);
    }

    public void RestartGame()
    {
        m_gameOverUI.SetActive(false);
        m_startMenuUI.SetActive(false);
        m_pauseMenuUI.SetActive(false);
        ResumeGameSettings();

        foreach (IRestartGameElement l_RestartGameElement in m_RestartGameElements)
        {
            l_RestartGameElement.RestartGame();
        }
        

    }
}

