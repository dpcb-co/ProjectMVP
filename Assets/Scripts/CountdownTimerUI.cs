using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountdownTimerUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    GameManager gameManager;
    TextMeshProUGUI text;
    
    // Update is called once per frame
    void Update()
    {
        if(gameManager == null)
        {
            gameManager = GameObject.FindObjectOfType<GameManager>();

            if(gameManager == null)
            {
                return;
            }
        }
        text.text = gameManager.remainingTime.ToString("#.00");
    }
}
