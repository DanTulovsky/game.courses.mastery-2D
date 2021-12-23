using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    private List<Checkpoint> _checkpoints;
    
    private void Start()
    {
        _checkpoints = new List<Checkpoint>(GetComponentsInChildren<Checkpoint>());
    }

    public Checkpoint GetLastCheckpointPassed()
    {
        return _checkpoints.LastOrDefault(t => t.Passed);
    }
}