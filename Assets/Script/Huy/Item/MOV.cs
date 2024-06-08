using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Threading;
using System.IO;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MOV : MonoBehaviour
{
    GameObject player;
    public Transform pointA; 
    public Transform pointB; 
    public float speed = 2.0f; 

    private bool movingToB = true;
    
    private void Start()
    {
        player = GameObject.Find("Player");
    }
    void Update()
    {
        if (movingToB)
        {
            // Di chuyển từ A đến B
            transform.position = Vector3.MoveTowards(transform.position, pointB.position, speed * Time.deltaTime);
            if (transform.position == pointB.position)
            {
                movingToB = false; 
            }
        }
        else
        {
            // Di chuyển từ B đến A
            transform.position = Vector3.MoveTowards(transform.position, pointA.position, speed * Time.deltaTime);
            if (transform.position == pointA.position)
            {
                movingToB = true; 
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.transform.parent = gameObject.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.transform.parent = null;
        }
    }
}
