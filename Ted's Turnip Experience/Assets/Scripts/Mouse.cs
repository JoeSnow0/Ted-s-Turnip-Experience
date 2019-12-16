using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    GameController mGameController;
    [Tooltip("Set the depth of the play area, to keep the interactables visible")]
    [SerializeField] int playAreaDepth = 0;
    [Header("")]
    [SerializeField] Interactable mHeldInteractable;
    private void Start()
    {
        mGameController = FindObjectOfType<GameController>();
    }
    private void Update()
    {
        GetMouseInput();
    }
    private void GetMouseInput()
    {
        if (Input.GetMouseButtonDown(0))
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
            newPos.z = playAreaDepth;
            mHeldInteractable.transform.position = newPos;
        }
    }
    public void GrabInteractable()
    {
        if(HandIsEmpty())
        {
            mHeldInteractable = mGameController.FindInteractableInListByPosition(Input.mousePosition);
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
        mHeldInteractable = newInteractable;
    }
}
