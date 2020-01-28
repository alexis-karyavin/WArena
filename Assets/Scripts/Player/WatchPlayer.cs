using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Photon.Pun;

public class WatchPlayer : MonoBehaviour
{
    Transform player;
    Vector3 playerVector;
    Stopwatch sw;
    bool flag = true;
 
    void Start()
    {
        sw = new Stopwatch();
        sw.Start();
        
    }

    private void Update()
    {
        if (sw.ElapsedMilliseconds > 2000 && flag)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            flag = false;
        }
    }

    private void FixedUpdate()
    {
        if(player != null)
        {
            playerVector = player.position;
            playerVector.z = -10;
            transform.position = Vector3.Lerp(transform.position, playerVector, Time.deltaTime);
        }

    }
}
