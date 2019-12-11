using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    //Components
    protected GameController mGameController;
    protected Transform mTransform;
    protected Rigidbody2D mRigidbody;
    protected Collider2D mCollider;
    protected SpriteRenderer mRenderer;
    
    private void Update()
    {
    }
    public void Initialize(GameController controller)
    {
        mGameController = controller;
        mTransform = GetComponent<Transform>();
        mRigidbody = GetComponent<Rigidbody2D>();
        mCollider = GetComponent<Collider2D>();
        mRenderer = GetComponent<SpriteRenderer>();
    }
    public void SetPosition(Vector2 position)
    {
        mTransform.position = position;
    }
    private void OnMouseEnter()
    {
        mGameController.mMouse.SetInteractable(this);
        print("mouse overlapping " + gameObject);
    }
    private void OnMouseExit()
    {
        mGameController.mMouse.SetInteractable(null);
    }
}
