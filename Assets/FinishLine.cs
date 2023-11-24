using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public LogicManager logic;
    // Start is called before the first frame update
    void Start()
    {
        // Get the invisible finish line element
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        // If the player collides with the finish line, they win and the end game screen is shown
        if (collision.gameObject.layer == 6)
        {
            logic.YouWin();
        }

    }
}
