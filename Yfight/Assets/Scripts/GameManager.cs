using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject player1;
    public GameObject player2;

    public GameObject LifeP1_1;
    public GameObject LifeP1_2;
    public GameObject LifeP2_1;
    public GameObject LifeP2_2;

    public int P1Life = 2;
    public int P2Life = 2;
    public float P1health;
    public float P2health;

    public static int PlayerWin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        P1health = player1.GetComponent<PlayerHealth>().currentHealth;
        P2health = player2.GetComponent<PlayerHealth>().currentHealth;



        if (P1health <= 0)
        {
            P1Life--;
            if(P1Life < 0)
            {
                player1.SetActive(false);
                PlayerWin = 2;
                SceneManager.LoadScene(4);
            } else
            {
                if(P1Life == 1)
                {
                    LifeP1_2.SetActive(false);
                }
                if (P1Life == 0)
                {
                    LifeP1_1.SetActive(false);
                }
                player1.GetComponent<PlayerHealth>().restoreHealth();
            }
        }

        if (P2health <= 0)
        {
            P2Life--;
            if (P2Life < 0)
            {
                player2.SetActive(false);
                PlayerWin = 1;
                SceneManager.LoadScene(4);
            }
            else
            {
                if (P2Life == 1)
                {
                    LifeP2_1.SetActive(false);
                }
                if (P2Life == 0)
                {
                    LifeP2_2.SetActive(false);
                }
                player2.GetComponent<PlayerHealth>().restoreHealth();
            }
        }
        /*if (P2Life <= 0)
        {
            player2.SetActive(false);
        }*/

    }

    public void HurtP1()
    {
        P1Life -= 1;
    }
    public void HurtP2()
    {
        P2Life -= 1;
    }
}
