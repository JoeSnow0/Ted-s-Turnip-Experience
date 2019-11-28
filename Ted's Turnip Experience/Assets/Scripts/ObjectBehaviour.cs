using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBehaviour : MonoBehaviour
{
    protected class ObjectValues
    {
        protected Vector2 mOldPosition;
        protected Vector2 mForce;
    }
    void ApplyForce(Vector2 force, Rigidbody2D rigidbody, bool relativeForce)
    {
        if(relativeForce)
        {
            rigidbody.AddRelativeForce(force);
        }
        else
        {
            rigidbody.AddForce(force);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        //ApplyForce(ObjectValues.mForce, collision.rigidbody, true);
    }
}
