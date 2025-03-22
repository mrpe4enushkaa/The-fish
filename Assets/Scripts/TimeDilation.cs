using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TimeDilation : MonoBehaviour
{
    public string tagTimeDilation;
    public float time;
    [HideInInspector]
    public bool dilation;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == tagTimeDilation)
        {
            ApplyTimeDilation();
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == tagTimeDilation)
        {
            ApplyTimeDilation();
            Destroy(collision.gameObject);
        }
    }

    private void ApplyTimeDilation()
    {
        if (!dilation)
        {
            Time.timeScale = 0.67f;
            GetComponent<Player>().Force *= 1.5f;
            dilation = true;
        }
        if (dilation)
        {
            CancelInvoke("OffTimeDilation");
        }
        Invoke("OffTimeDilation", time);
    }

    void OffTimeDilation()
    {
        if (dilation)
        {
            Time.timeScale = 1f;
            dilation = false;
            GetComponent<Player>().Force /= 1.5f;
        }
    }
}
