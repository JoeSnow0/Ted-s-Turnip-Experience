using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [Header("Scene References")]
    PlayerController mPlayer;
    [SerializeField] Canvas mCanvas;
    [SerializeField] HorizontalLayoutGroup mButtonHolder;
    [SerializeField] Transform InteractablesHolder;
    [SerializeField] Text mVictoryText;
    [SerializeField] public Mouse mMouse;
    [Header("Spawn and Goal points")]
    [SerializeField] Transform mSpawn;
    [SerializeField] GoalCheck mGoal;
    [Header("Prefabs")]
    [SerializeField] PlayerController mPlayerPrefab;
    [SerializeField] ButtonSettings mButtonPrefab;
    [SerializeField] public Interactable[] ListOfInteractablePrefabs;
    [Header("Lists")]
    [SerializeField] List<Interactable> ListOfInteractablesInScene = new List<Interactable>();
    [SerializeField] int[] ListOfAmounts;
    [SerializeField] Sprite[] ListOfSprites;
    
    
    private void Start()
    {
        initializeScene();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ResetAttempt();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            StartAttempt();
        }
        CheckIfPlayerAtGoal();
    }
    void initializeScene()
    {
        mMouse = GetComponent<Mouse>();
        SpawnPlayer();
        CreateButtons();
        
    }
    private void SpawnPlayer()
    {
        mPlayer = Instantiate(mPlayerPrefab, mSpawn);
        mPlayer.InitializeObject();
    }
    public void SpawnInteractable(Interactable prefab)
    {
        Interactable newInteractable = Instantiate(prefab, InteractablesHolder);
        newInteractable.Initialize(this);
        AddNewToList(newInteractable);
        
    }
    public void AddNewToList(Interactable newInteractable)
    {
        if (!ListOfInteractablesInScene.Contains(newInteractable))
        {
            ListOfInteractablesInScene.Add(newInteractable);
        }
    }
    public void RemoveFromList(Interactable newInteractable)
    {
        if (ListOfInteractablesInScene.Contains(newInteractable))
        {
            ListOfInteractablesInScene.Remove(newInteractable);
        }
    }
    private void ResetAttempt()
    {
        mPlayer.Reset(mSpawn);
    }
    private void StartAttempt()
    {
        mPlayer.PlayMovement();
    }
    private void CheckIfPlayerAtGoal()
    {
        if(mGoal.IsPlayerInGoal())
        {
            mVictoryText.gameObject.SetActive(true);
        }
        else
        {
            mVictoryText.gameObject.SetActive(false);
        }
    }
    protected void CreateButtons()
    {
        for (int i = 0; i < ListOfInteractablePrefabs.Length; i++)
        {
            ButtonSettings newButton = Instantiate(mButtonPrefab, mButtonHolder.transform);
            newButton.InitializeButton(this, ListOfAmounts[i], ListOfSprites[i], ListOfInteractablePrefabs[i]);
        }
    }
}
