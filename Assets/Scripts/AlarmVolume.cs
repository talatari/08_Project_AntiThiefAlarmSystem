using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class AlarmVolume : MonoBehaviour
{
    [SerializeField] private ThiefDetector _thiefDetector;
    
    private AudioSource _audioSource;
    private int _speedVolume = 2;
    private Coroutine _coroutineAlarm;
    
    private void Awake() => _audioSource ??= GetComponent<AudioSource>();

    private void OnEnable()
    {
        _thiefDetector.ThiefEnter += OnAlarm;
        _thiefDetector.ThiefExit += OnAlarm;
    }

    private void OnDisable()
    {
        if (_coroutineAlarm is not null)
            StopCoroutine(_coroutineAlarm);
        
        _thiefDetector.ThiefEnter -= OnAlarm;
        _thiefDetector.ThiefExit -= OnAlarm;
    }

    private void OnAlarm(int volumeDirection)
    {
        if (_coroutineAlarm is not null)
            StopCoroutine(_coroutineAlarm);

        _coroutineAlarm = StartCoroutine(Alarm(volumeDirection));
    }
    
    private IEnumerator Alarm(int volumeDirection)
    {
        if (_audioSource.isPlaying is false)
            _audioSource.Play();
        
        while (true)
        {
            _audioSource.volume += volumeDirection * Time.deltaTime  / _speedVolume;
            
            yield return null;
        }
    }
}