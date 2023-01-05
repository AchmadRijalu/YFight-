using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleManager : MonoBehaviour
{
    public GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player1")
        {

            gameManager.GetComponent<GameManager>().HoleP1();

            Debug.Log("Dead");
        }

        if (collision.gameObject.tag == "Player2")
        {

            gameManager.GetComponent<GameManager>().HoleP2();

            Debug.Log("Dead");
        }
    }
}
