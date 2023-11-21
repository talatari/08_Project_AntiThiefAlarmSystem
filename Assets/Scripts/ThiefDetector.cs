using System;
using UnityEngine;

public class ThiefDetector : MonoBehaviour
{
    [SerializeField] private VolumeControl _volumeControl;

    private int _directionVolume = -1;
    
    public event Action<int> ThiefEnter;
    public event Action<int> ThiefExit;
    
    private void Awake() => 
        _volumeControl = FindObjectOfType<VolumeControl>();

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.TryGetComponent(out Thief thief)) 
            ThiefEnter?.Invoke(_directionVolume * _directionVolume);
    }

    private void OnTriggerExit2D(Collider2D collider2D)
    {
        if (collider2D.TryGetComponent(out Thief thief)) 
            ThiefExit?.Invoke(_directionVolume);
    }
}