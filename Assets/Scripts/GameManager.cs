using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class GameManager : NetworkBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    [SyncVar]
    public float remainingTime = 60;

    // Update is called once per frame
    void Update()
    {
        if (!isServer)
        {
            return;
        }

        remainingTime -= Time.deltaTime;
        if(remainingTime <= 0)
        {
            // something
        }
    }



}
