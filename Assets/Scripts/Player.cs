using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject ObjButton;
    float swimForce;
    public float Force;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ButtonUp();
        ObjButton.SetActive(true);
    }

    private void Update()
    {
        swimForce = Force;

        if (GetComponent<Live>().lives == 1)
        {
            gameObject.SetActive(true);
        }
        else if (GetComponent<Live>().lives == 0)
        {
            gameObject.SetActive(true);
        }
    }

    public void ButtonDown()
    {
        rb.velocity = new Vector2(0, -swimForce);
    }

    public void ButtonUp()
    {
        rb.velocity = new Vector2(0, swimForce);
    }

    void SwimForce()
    {
        if(GetComponent<Live>().lives == 1)
        {
            swimForce = Force;
        }
        else if(GetComponent<Live>().lives == 0)
        {
            swimForce = 0;
        }
    }    
}
