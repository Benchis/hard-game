using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public float speed = 0.5f; // Speed of the bobbing
    public float height = 0.5f; // Height of the bobbing
    private Vector3 startPos;


    void Start()
    {
        startPos = transform.position;
    }

    
    void Update()
    {
        if (gameObject.tag == "title")
        {
            float newY = Mathf.Sin(Time.time * speed) * height;
            transform.position = new Vector3(transform.position.x, startPos.y + newY, transform.position.z);
        }

        
    }


}
