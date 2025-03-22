using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pausePanel;
    public Button resumeButton;
    public Button menuButton;
    public Button pauseButton;
    public GameObject pauseObj;

    private void Start()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
        menuButton.onClick.AddListener(menu);
    }

    private void Update()
    {
        pauseButton.onClick.AddListener(pause);
        resumeButton.onClick.AddListener(resume);

        if(GetComponent<Live>().lives == 1)
        {
            pauseObj.SetActive(true);
        }
        else if(GetComponent<Live>().lives == 0)
        {
            pauseObj.SetActive(false);
        }
    }

    void pause()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        pauseObj.SetActive(false);
    }

    void resume()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
        pauseObj.SetActive(true);
    }

    void menu()
    {
        SceneManager.LoadScene(0);
    }
}
