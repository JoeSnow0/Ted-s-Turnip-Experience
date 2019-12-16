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

    [SerializeField] private Text mVictoryText;
    [SerializeField] public Mouse mMouse;

    [Header("Spawn and Goal points")]
    [SerializeField] private Transform mSpawn;
    [SerializeField] private GoalCheck mGoal;

    [Header("Prefabs")]
    [SerializeField] private PlayerController mPlayerPrefab;
    [SerializeField] private ButtonSettings mButtonPrefab;

    [Header("KEEP THESE THE SAME SIZE")]
    [SerializeField] public Interactable[] ListOfInteractablePrefabs;
    [SerializeField] public Sprite[] ListOfInteractableSprites;
    [SerializeField] public int[] ListOfInteractableAmounts;

    [Header("Buttons")]
    [SerializeField] private KeyCode ResetButton;
    [SerializeField] private KeyCode StartButton;
    private bool isPlaying;

    [Header("Feedback")]
    [SerializeField] private List<Interactable> ListOfInteractablesInScene = new List<Interactable>();
    [SerializeField] private Transform InteractablesHolder;
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
    public Interactable FindInteractableInListByPosition(Vector2 position)
    {
        for(int i = 0; i > ListOfInteractablesInScene.Count; i++)
        {
            if(ListOfInteractablesInScene[i].GetCollider().OverlapPoint(position))
            {
                return ListOfInteractablesInScene[i];
            }
        }
        return null;
    }
    public void ClearInteractableList()
    {
        for (int i = ListOfInteractablesInScene.Count; i > 0; i--)
        {
            Interactable oldInteractable = ListOfInteractablesInScene[i];
            ListOfInteractablesInScene.Remove(oldInteractable);
            DestroyInteractable(oldInteractable);
        }
    }
    private void DestroyInteractable(Interactable interactable)
    {
        Destroy(interactable);
    }
    public void SpawnInteractable(Interactable prefab)
    {
        Interactable newInteractable = Instantiate(prefab, InteractablesHolder);
        newInteractable.Initialize(this);
        AddNewToList(newInteractable);

    }
    
    private void Start()
    {
        initializeScene();

    }
    void initializeScene()
    {
        SpawnPlayer();
        CreateButtons();

    }
    private void SpawnPlayer()
    {
        mPlayer = Instantiate(mPlayerPrefab, mSpawn);
        mPlayer.InitializeObject(mSpawn);
    }


    public void ResetAttempt()
    {
        SetIsPlaying(false);
        mPlayer.Reset();
    }
    private void StartAttempt()
    {
        SetIsPlaying(true);
        mPlayer.PlayMovement();
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
            newButton.InitializeButton(this, ListOfInteractableAmounts[i], ListOfInteractableSprites[i], ListOfInteractablePrefabs[i]);
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
    public PlayerController GetPlayer()
    {
        return mPlayer;
    }
}
