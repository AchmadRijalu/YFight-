using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{

    int win;
    public GameObject winText;
    // Start is called before the first frame update
    void Start()
    {
        win = GameManager.PlayerWin;
    }

    // Update is called once per frame
    void Update()
    {
        winText.GetComponent<TMPro.TextMeshProUGUI>().text = "Player " + win + " Win";
    }
}
