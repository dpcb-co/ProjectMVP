using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    Camera cam;
    public LayerMask groundLayer;       // The layer where NavMeshAgents should be able to walk on
    public NavMeshAgent playerAgent;    // References object to move on NavMesh

    void Awake()
    {
        cam = Camera.main;      // Set a reference to main camera
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(1))     // TODO: Adapt for mobile
        {
            float distance = Vector3.Distance(playerAgent.transform.position, GetPointUnderCursor());
            //GameObject.Find("Main Camera").GetComponent<GamestateEngine>().stamina = (float)Math.Round(GameObject.Find("Main Camera").GetComponent<GamestateEngine>().stamina - distance);
            playerAgent.SetDestination(GetPointUnderCursor());      // Custom method defined below
        }
    }

    private Vector3 GetPointUnderCursor()
    {
        Vector2 screenPosition = Input.mousePosition;       // Gets location of cursor
        Vector3 mouseWorldPosition = cam.ScreenToWorldPoint(screenPosition);        // Casts from screen point to world point

        RaycastHit hitPosition;     // Catches position where the raycast hits a layer or collider

        Physics.Raycast(mouseWorldPosition, cam.transform.forward, out hitPosition, 100, groundLayer);
        // Raycast: shoots a line from origin (mouseWorldPosition) to direction (cam.transform.forward) of max length (100) until it hits (groundLayer)

        return hitPosition.point;
    }
}
