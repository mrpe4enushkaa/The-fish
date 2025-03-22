using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonToExit : MonoBehaviour
{
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(Close);
    }

    void Close()
    {
        Application.Quit();
    }
}
