using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    //Values
    [Header("Weight")]
    [Range(0, 20)]
    [SerializeField] protected float mWeight;
    [Header("Sprite")]
    [SerializeField] protected Sprite mSprite;
    [SerializeField] protected Rigidbody2D mRigidbody;
    //Reset
    [Header("Reset")]
    [SerializeField] Transform mResetTransform;
    [SerializeField] Vector3 mResetVelocity = Vector3.zero;

    virtual protected void Start()
    {
    }
    virtual protected void Update()
    {
        
    }
    public void InitializeObject(Transform resetTransform)
    {
        mRigidbody = GetComponent<Rigidbody2D>();
        mRigidbody.mass = mWeight;
        mResetTransform = resetTransform;
    }
    protected void SetTransform(Transform newTransform)
    {
        transform.position = newTransform.position;
        transform.rotation = newTransform.rotation;
        transform.localScale = newTransform.localScale;
    }
    protected void SetVelocity(Vector3 velocity)
    {
        mRigidbody.velocity = velocity;
    }
    public void Reset()
    {
        SetTransform(mResetTransform);
        SetVelocity(mResetVelocity);
        PauseMovement();
    }
    public void PauseMovement()
    {
        mRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
    }
    public void PlayMovement()
    {
        mRigidbody.constraints = RigidbodyConstraints2D.None;
    }
}
