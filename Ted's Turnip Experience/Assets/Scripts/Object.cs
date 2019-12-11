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

    virtual protected void Start()
    {
        InitializeObject();
    }
    virtual protected void Update()
    {
        
    }
    public void InitializeObject()
    {
        mRigidbody = GetComponent<Rigidbody2D>();
        mRigidbody.mass = mWeight;
    }
    protected void SetPosition(Transform newTransform)
    {
        transform.position = newTransform.position;
        transform.rotation = newTransform.rotation;
    }
    protected void SetVelocity(Vector3 velocity)
    {
        mRigidbody.velocity = velocity;
    }
    public void Reset(Transform newTransform)
    {
        SetPosition(newTransform);
        SetVelocity(Vector3.zero);
        PauseMovement();
    }
    public void PauseMovement()
    {
        mRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
    }
    public void PlayMovement()
    {
        mRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}
