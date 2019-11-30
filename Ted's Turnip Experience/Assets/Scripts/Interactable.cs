using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    //Components
    protected Transform mTransform;
    protected Rigidbody2D mRigidbody;
    protected Collider2D mCollider;
    protected SpriteRenderer mRenderer;

    //Values
    string mName;
    Sprite mSprite;

    private void Start()
    {
        Initialize();
    }
    public void Initialize()
    {
        mTransform = GetComponent<Transform>();
        mRigidbody = GetComponent<Rigidbody2D>();
        mCollider = GetComponent<Collider2D>();
        mRenderer = GetComponent<SpriteRenderer>();

    }
}
