using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("Spawn and Goal points")]
    [SerializeField] Transform mSpawn;
    [SerializeField] GoalCheck mGoal;
    [SerializeField] PlayerController mPlayerPrefab;
    [SerializeField] Canvas mCanvas;
    PlayerController mPlayer;
    private void Start()
    {
        SpawnPlayer();
    }
    void SpawnPlayer()
    {
        mPlayer = Instantiate(mPlayerPrefab, mSpawn);
    }

    void DisplayText(bool displayIt)
    {
        
    }
}
