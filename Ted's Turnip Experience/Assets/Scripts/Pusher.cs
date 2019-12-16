using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pusher : Interactable
{
    
    //Values
    [Header("Pushing Values")]
    [Range(0, 200)]
    [SerializeField] protected float mPushPower = 5f;
    [Tooltip("Delay before push in seconds")]
    [Range(0, 20)]
    [SerializeField] protected float PushDelay = 0f;
    [SerializeField] protected ForceMode2D pushMode = ForceMode2D.Force;
    [SerializeField] protected Vector2 mDirection;
    [SerializeField] private bool mIsCollisionSafe = true;
    protected Vector2 mForce;
    [Header("Feedback")]
    [SerializeField] private List<Rigidbody2D> BodiesOnPlatform = new List<Rigidbody2D>();


    private void CalculateForce(Rigidbody2D bodyToPush)
    {
        mForce = mPushPower * mDirection;
    }
    virtual protected void Update()
    {
        Pushing();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        AddBody(collision.attachedRigidbody);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        RemoveBody(collision.attachedRigidbody);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!mIsCollisionSafe && mGameController.GetIsPlaying() && collision.gameObject == mGameController.GetPlayer().gameObject)
        {
            mGameController.ResetAttempt();
        }
    }
    private void Pushing()
    {
        if (CheckIfBodyOnPusher())
        {
            if (PushDelay <= 0)
            {
                PushObjects();
            }
            else
            {
                //print("started Coroutine");
                StartCoroutine(DelayedPushObject());
            }

        }
    }
    private void PushObjects()
    {
        for(int i = 0; i <  BodiesOnPlatform.Count; i++)
        {
            CalculateForce(BodiesOnPlatform[i]);
            PushObject(BodiesOnPlatform[i]);
        }
    }
    private void PushObject(Rigidbody2D pushTarget)
    {
        pushTarget.AddForceAtPosition(mForce, transform.position);
    }
    private IEnumerator DelayedPushObject()
    {
        yield return new WaitForSeconds(PushDelay);
        PushObjects();
    }
    private void AddBody(Rigidbody2D newBody)
    {
        if (!BodiesOnPlatform.Contains(newBody))
        {
            BodiesOnPlatform.Add(newBody);
        }
    }
    private void RemoveBody(Rigidbody2D oldRigidbody)
    {
        if(BodiesOnPlatform.Contains(oldRigidbody))
        {
            BodiesOnPlatform.Remove(oldRigidbody);
        }
    }
    private bool CheckIfBodyOnPusher()
    {
        if (BodiesOnPlatform.Count > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
