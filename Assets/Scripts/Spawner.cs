using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] prefabs;
    public float time;
    GameObject player;
    public float border1, border2;

    public bool isSpawnerLoots;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<TapToPlay>().ButtonPlay.onClick.AddListener(Go1);

        if (!isSpawnerLoots)
        {
            time = Random.Range(2f, 5f);
            player.GetComponent<TapToPlay>().ButtonPlay.onClick.AddListener(Go1);
        }
        else
        {
            player.GetComponent<TapToPlay>().ButtonPlay.onClick.AddListener(Go2);
        }
    }

    void SpawnDangerous()
    {
        if(player.GetComponent<Live>().lives == 1)
        {
            GameObject obj = Instantiate(prefabs[Random.Range(0, prefabs.Length)], new Vector2(transform.position.x, Random.Range(border1,border2)), Quaternion.identity);
            Destroy(obj, 10);
            Invoke("SpawnDangerous", time);
            time = Random.Range(2.5f, 5.5f);
        }
        else if(player.GetComponent<Live>().lives == 0)
        {
            Invoke("SpawnDangerous", time);
        }
    }

    void SpawnerLoots()
    {
        if (player.GetComponent<Live>().lives == 1)
        {
            GameObject obj = Instantiate(prefabs[Random.Range(0, prefabs.Length)], new Vector2(transform.position.x, Random.Range(border1, border2)), Quaternion.identity);
            Destroy(obj, 10);
            Invoke("SpawnerLoots", time);
        }
        else if (player.GetComponent<Live>().lives == 0)
        {
            Invoke("SpawnerLoots", time);
        }
    }

    void Go1()
    {
        Invoke("SpawnDangerous", time);
    }

    void Go2()
    {
        Invoke("SpawnerLoots", time);
    }
}
