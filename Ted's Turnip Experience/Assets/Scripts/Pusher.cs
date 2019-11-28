using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pusher : MonoBehaviour
{
    [SerializeField] private Vector2 mPusherPower;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.attachedRigidbody.AddRelativeForce(mPusherPower,ForceMode2D.Impulse);
    }
}
