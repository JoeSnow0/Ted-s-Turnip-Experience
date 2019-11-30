using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSettings : MonoBehaviour
{
    //Components
    private Image mImage;
    private GameController mGameController;
    private Interactable InteractablePrefab;
    private int mMaxUses;
    private int mCurrentUsesLeft;
    
    public void InitializeButton(GameController gameController, int maxUses, Sprite sprite, Interactable prefab)
    {
        mGameController = gameController;
        mMaxUses = maxUses;
        mCurrentUsesLeft = mMaxUses;
        mImage = GetComponent<Image>();
        mImage.sprite = sprite;
        InteractablePrefab = prefab;
    }
    
    private void AddInteractableToScene()
    {
        if(CheckIfAvailable())
        {
            mCurrentUsesLeft--;
            mGameController.SpawnInteractable(InteractablePrefab);
        }
    }
    bool CheckIfAvailable()
    {
        if(mCurrentUsesLeft > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
