using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pusher : Interactable
{
    
    //Values
    [Header("Pushing Values")]
    [Range(0, 100)]
    [SerializeField] protected float mPushPower = 5f;
    [Tooltip("Under construction")]
    [Range(0, 20)]
    [SerializeField] protected float PushDelay = 0f;
    [SerializeField] protected ForceMode2D pushMode = ForceMode2D.Force;
    [SerializeField] protected bool isForceRelative;
    [SerializeField] protected Vector2 mDirection;
    protected Vector2 mForce;
    [Header("Feedback")]
    [SerializeField] List<Rigidbody2D> BodiesOnPlatform = new List<Rigidbody2D>();
    
    private void CalculateForce()
    {
        mForce = mPushPower * mDirection;
    }
    virtual protected void Update()
    {
        if(CheckIfBodyOnPusher())
        {
            PushObjects(BodiesOnPlatform, mForce, isForceRelative, pushMode);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        AddBody(collision.attachedRigidbody);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        PushObjects(BodiesOnPlatform, mForce, isForceRelative, pushMode);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        RemoveBody(collision.attachedRigidbody);
    }

    private void PushObjects(List<Rigidbody2D> pushTargets, Vector2 push, bool relativeForce, ForceMode2D mode)
    {
        CalculateForce();
        for(int i = 0; i <  pushTargets.Count; i++)
        {
            PushObject(pushTargets[i], mForce, isForceRelative, pushMode);
        }
    }
    private void PushObject(Rigidbody2D pushTarget, Vector2 push, bool relativeForce, ForceMode2D mode)
    {
        if (relativeForce)
        {
            pushTarget.AddRelativeForce(push, mode);
        }
        else if (!relativeForce)
        {
            pushTarget.AddForce(push, mode);
        }
    }
    void AddBody(Rigidbody2D newBody)
    {
        if (!BodiesOnPlatform.Contains(newBody))
        {
            BodiesOnPlatform.Add(newBody);
        }
    }
    void RemoveBody(Rigidbody2D oldRigidbody)
    {
        if(BodiesOnPlatform.Contains(oldRigidbody))
        {
            BodiesOnPlatform.Remove(oldRigidbody);
        }
    }
    bool CheckIfBodyOnPusher()
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
