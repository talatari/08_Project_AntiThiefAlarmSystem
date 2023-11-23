using System;
using UnityEngine;

public class ThiefDetector : MonoBehaviour
{
    private int _directionVolume = -1;
    
    public event Action<int> ThiefEnter;
    public event Action<int> ThiefExit;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Thief thief)) 
            ThiefEnter?.Invoke(_directionVolume * _directionVolume);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out Thief thief)) 
            ThiefExit?.Invoke(_directionVolume);
    }
}