using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [Header("Scene References")]
    private PlayerController mPlayer;
    [SerializeField] private Canvas mCanvas;
    [SerializeField] private HorizontalLayoutGroup mButtonHolder;
    [SerializeField] private Transform InteractablesHolder;
    [SerializeField] private Text mVictoryText;
    [SerializeField] public Mouse mMouse;

    [Header("Spawn and Goal points")]
    [SerializeField] private Transform mSpawn;
    [SerializeField] private GoalCheck mGoal;

    [Header("Prefabs")]
    [SerializeField] private PlayerController mPlayerPrefab;
    [SerializeField] private ButtonSettings mButtonPrefab;
    [SerializeField] public Interactable[] ListOfInteractablePrefabs;

    [Header("Lists")]
    [SerializeField] private List<Interactable> ListOfInteractablesInScene = new List<Interactable>();
    [SerializeField] private int[] ListOfAmounts;
    [SerializeField] private Sprite[] ListOfSprites;
    [SerializeField] private KeyCode ResetButton;
    [SerializeField] private KeyCode StartButton;

    private bool isPlaying;
    
    
    private void Start()
    {
        initializeScene();
    }
    private void Update()
    {
        if (Input.GetKeyDown(ResetButton))
        {
            SetIsPlaying(false);
            ResetAttempt();
        }
        if (Input.GetKeyDown(StartButton))
        {
            SetIsPlaying(true);
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
    public void ResetAttempt()
    {
        SetIsPlaying(false);
        mPlayer.Reset(mSpawn);
    }
    private void StartAttempt()
    {
        SetIsPlaying(true);
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
    public void SetIsPlaying(bool newState)
    {
        isPlaying = newState;
    }
    public bool GetIsPlaying()
    {
        return isPlaying;
    }
    public void NextLevel()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        //Application.Quit();
    }
}
