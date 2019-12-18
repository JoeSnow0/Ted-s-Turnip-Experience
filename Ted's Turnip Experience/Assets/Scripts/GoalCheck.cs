using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalCheck : MonoBehaviour
{
    [Header("Feedback")]
    [Tooltip("Indicates if player is within the bounds of the goal square")]
    [SerializeField] private bool mPlayerInGoal = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SetPlayerInGoal(true);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        SetPlayerInGoal(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        SetPlayerInGoal(false);
    }
    public bool IsPlayerInGoal()
    {
        return mPlayerInGoal;
    }
    private void SetPlayerInGoal(bool isPlayerInGoal)
    {
        mPlayerInGoal = isPlayerInGoal;
    }
}
