using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSettings : MonoBehaviour
{
    //Components
    private GameController mGameController;
    private Image mImage;
    private Button mButton;
    private Text mButtonText;
    private Interactable InteractablePrefab;
    [Header("Feedback")]
    [SerializeField] private int mMaxUses;
    [SerializeField] private int mCurrentUsesLeft;
    [SerializeField] private const int mMinUses = 0;
    
    public void InitializeButton(GameController gameController, int maxUses, Sprite sprite, Interactable prefab)
    {
        mGameController = gameController;
        mMaxUses = maxUses;
        mCurrentUsesLeft = mMaxUses;
        mImage = GetComponent<Image>();
        mImage.sprite = sprite;
        mButton = GetComponent<Button>();
        mButtonText = GetComponentInChildren<Text>();
        UpdateButton();
        InteractablePrefab = prefab;
    }
    public void ResetButton()
    {
        mCurrentUsesLeft = mMaxUses;
        UpdateButton();
    }
    public void UpdateButton()
    {
        mButtonText.text = mCurrentUsesLeft.ToString();
    }
    private void AddInteractableToScene()
    {
        if(CheckIfAvailable())
        {
            mCurrentUsesLeft--;
            UpdateButton();
            mGameController.SpawnInteractable(InteractablePrefab);
        }
    }
    private bool CheckIfAvailable()
    {
        if(mCurrentUsesLeft > mMinUses)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
