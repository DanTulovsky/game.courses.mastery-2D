using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int maxLives = 3;
    
    
    public static GameManager Instance { get; private set; }
    public int Lives { get; private set; }
    public event Action<int> OnLivesChanged;
    public event Action<int> OnCoinsChanged;

    private int _coins;
    private int currentLevelIndex;
    
    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            RestartGame();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void RestartGame()
    {
        Lives = maxLives;
        _coins = 0;
        OnCoinsChanged?.Invoke(_coins);
        SceneManager.LoadScene(0);
    }
    
    private void SendPlayerToCheckpoint()
    {
        CheckpointManager checkpointManager = FindObjectOfType<CheckpointManager>();
        if (!checkpointManager) return;

        Checkpoint checkpoint = checkpointManager.GetLastCheckpointPassed();
        PlayerMovementController player = FindObjectOfType<PlayerMovementController>();
        
        player.transform.position = checkpoint.transform.position;
    }
    
    public void KillPlayer()
    {
        Lives--;
        OnLivesChanged?.Invoke(Lives);

        if (Lives <= 0)
            RestartGame();
        else
        {
            SendPlayerToCheckpoint();
        }
    }

    public void AddCoin()
    {
        _coins++;
        OnCoinsChanged?.Invoke(_coins);
    }

    public void MoveToNextLevel()
    {
        currentLevelIndex++;
        SceneManager.LoadScene(currentLevelIndex);

    }
}