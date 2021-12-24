using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    private List<Checkpoint> _checkpoints;
    
    private void Start()
    {
        _checkpoints = new List<Checkpoint>(GetComponentsInChildren<Checkpoint>());
        
        // Set first Checkpoint as passed
        _checkpoints[0].Passed = true;
    }

    public Checkpoint GetLastCheckpointPassed()
    {
        return _checkpoints.LastOrDefault(t => t.Passed);
    }
}