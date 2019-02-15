using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Player : NetworkBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        if(isServer)
        {
            SpawnUnits();
        }
        
    }

    public GameObject unitPrefab;
    GameObject myUnit;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnUnits()
    {
        // This method should only be called by the server
        if (!isServer)
        {
            return;
        }

        myUnit = Instantiate(unitPrefab);
        NetworkServer.SpawnWithClientAuthority(myUnit, connectionToClient);
    }
}
