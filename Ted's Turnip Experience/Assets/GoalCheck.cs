using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalCheck : MonoBehaviour
{
    bool mPlayerInGoal = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IsPlayerInGoal(true);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        IsPlayerInGoal(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        IsPlayerInGoal(false);
    }

    void IsPlayerInGoal(bool yesNo)
    {
        mPlayerInGoal = yesNo;
    }
}
