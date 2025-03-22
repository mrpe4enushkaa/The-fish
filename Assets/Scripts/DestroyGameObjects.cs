using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameObjects : MonoBehaviour
{
    GameObject Player;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Player && collision.gameObject.GetComponent<Shield>().shields == true)
        {
            Player.GetComponent<Shield>().count = 0;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == Player && collision.gameObject.GetComponent<Shield>().shields == true)
        {
            Player.GetComponent<Shield>().count = 0;
            Destroy(gameObject);
        }
    }
}
