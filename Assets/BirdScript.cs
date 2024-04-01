using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;

    public float deadZone = -16;
    public float ceiling = 16;

    public LogicScript Logic;
    public bool isAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        Logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetMouseButtonDown(0) || Input.touchCount > 0 || Input.GetKeyDown(KeyCode.Space) == true) && isAlive)
        {
            myRigidbody.velocity = Vector2.up * flapStrength;
        }

        if (transform.position.y < deadZone || transform.position.y > ceiling)
        {
            Logic.gameOver();
            isAlive = false;
        }

        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Logic.gameOver();
        isAlive = false;
    }
}
