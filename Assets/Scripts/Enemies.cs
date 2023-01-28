using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies:MonoBehaviour
{
    public int amount;
    public bool trigger;
    [SerializeField] Transform player;
    private PlayerManager playerManager;

    public bool state;
    void Start()
    {
        playerManager = player.GetComponent<PlayerManager>();
    }
    void Update()
    {
        if (transform.childCount <= 0 && state)
        {
            playerManager.roadSpeed = playerManager.currentRoadSpeed;
            playerManager.ResetStickMan();
            state = false;   
        }
    }

}
