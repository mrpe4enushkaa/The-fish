using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public string tagShield;
    public GameObject shield;
    public float time;

    [HideInInspector]
    public bool shields;
    [HideInInspector]
    public int count;

    private void Start()
    {
        shield.SetActive(false);
        shields = false;
        count = 0;
    }

    private void Update()
    {
        if(count == 0)
        {
            OffShield();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == tagShield)
        {
            ApplyShield();
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == tagShield)
        {
            ApplyShield();
            Destroy(collision.gameObject);
        }
    }

    private void ApplyShield()
    {
        if (!shields)
        {
            shield.SetActive(true);
            GetComponent<Live>().tagDeath = "OnShield";
            count = 1;
            shields = true;
        }
        if (shields)
        {
            CancelInvoke("OffShield");
        }

        Invoke("OffShield", time);
    }

    void OffShield()
    {
        if (shields)
        {
            shield.SetActive(false);
            GetComponent<Live>().tagDeath = "Death";
            shields = false;
            count = 0;
        }
    }
}
