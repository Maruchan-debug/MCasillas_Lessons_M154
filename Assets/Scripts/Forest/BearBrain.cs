using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearBrain : MonoBehaviour
{
    // Wander if it can't see the player
    //If we can see the bear, it will evade
    //If the hive is dropped we will seek hive
    private Bot bot;
    private Vector3 hivePoS;
    private bool hiveDropped = false;

    void Start()
    {
        bot = GetComponent<Bot>();
        NavPlayerMovement.DroppedHive += HiveReady;
    }

    void HiveReady(Vector3 pos)
    {
        hivePoS = pos;
        hiveDropped = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (hiveDropped)
        {
            bot.Seek(hivePoS);
        }
        else
        {
            if (bot.CanSeeTarget())
            {
                bot.Evade();
            }
            else if (bot.CanSeeTarget())
            {
                bot.Pursue();
            }
            else
            {
                bot.Wander();
            }
        }
    }
}
