using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class TapToPlay : MonoBehaviour
{
    public GameObject buttonExit;
    public Button ButtonPlay;
    public GameObject butPlay;
    public GameObject textScore;
    [HideInInspector]
    public bool buttonDown;

    private void Start()
    {
        buttonExit.SetActive(true);
        textScore.SetActive(false);
        ButtonPlay.onClick.AddListener(Play);
        butPlay.SetActive(true);
        GetComponent<Pause>().pauseObj.SetActive(false);
        Time.timeScale = 0;
        buttonDown = false;
    }

    public void Play()
    {
        buttonExit.SetActive(false);
        Time.timeScale = 1;
        textScore.SetActive(true);
        butPlay.SetActive(false);
        GetComponent<Player>().ButtonUp();
        GetComponent<Pause>().pauseObj.SetActive(true);
        buttonDown = true;
    }
}
