using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalCheck : MonoBehaviour
{
    bool mPlayerInGoal = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        mPlayerInGoal = true;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        mPlayerInGoal = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        mPlayerInGoal = false;
    }
    public bool IsPlayerInGoal()
    {
        return mPlayerInGoal;
    }
}
