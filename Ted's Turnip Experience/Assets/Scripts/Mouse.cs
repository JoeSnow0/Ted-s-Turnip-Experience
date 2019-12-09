using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    GameController mGameController;
    [SerializeField] Interactable mHeldInteractable;

    private void Start()
    {
        mGameController = FindObjectOfType<GameController>();
    }
    private void Update()
    {
        
        if(Input.GetMouseButtonDown(0))
        {
            GetInteractable();
        }
        if (Input.GetMouseButton(0))
        {
            MoveInteractable();
        }
        if (Input.GetMouseButtonUp(0))
        {
            DropInteractable();
        }
    }
    private void MoveInteractable()
    {
        if (mHeldInteractable != null)
        {
            Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            newPos.z = 0;
            mHeldInteractable.transform.position = newPos;
        }
    }
    public void GrabInteractable(Interactable interactable)
    {
        if(HandIsEmpty())
        {
            mHeldInteractable = interactable;
        }
    }
    public void DropInteractable()
    {
        if (!HandIsEmpty())
        {
            mHeldInteractable = null;
        }
    }
    private bool HandIsEmpty()
    {
        if(mHeldInteractable = null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private Interactable GetInteractable()
    {
        return mHeldInteractable;
    }
    public void SetInteractable(Interactable newInteractable)
    {
        mGameController.mMouse.mHeldInteractable = newInteractable;
    }
}
