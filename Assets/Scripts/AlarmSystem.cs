using System.Collections;
using UnityEngine;

[RequireComponent(
    typeof(AudioSource))]

public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private ThiefDetector _thiefDetector;
    
    private AudioSource _audioSource;
    private int _speedVolume = 2;
    private Coroutine _coroutineAlarm;
    private int _on = 1;
    private int _off = -1;

    private void Awake() => 
        _audioSource = GetComponent<AudioSource>();

    private void OnEnable()
    {
        _thiefDetector.ThiefEnter += Alarm;
        _thiefDetector.ThiefExit += Alarm;
    }

    private void OnDisable()
    {
        if (_coroutineAlarm is not null)
            StopCoroutine(_coroutineAlarm);
        
        _thiefDetector.ThiefEnter -= Alarm;
        _thiefDetector.ThiefExit -= Alarm;
    }

    private void Alarm(int volumeDirection)
    {
        if (_coroutineAlarm is not null)
            StopCoroutine(_coroutineAlarm);

        _coroutineAlarm = StartCoroutine(OnAlarm(volumeDirection));
    }
    
    private IEnumerator OnAlarm(int volumeDirection)
    {
        if (_audioSource.isPlaying is false)
            _audioSource.Play();
        
        while (volumeDirection == _on)
        {
            _audioSource.volume += Time.deltaTime  / _speedVolume;
            
            yield return null;
        }
        
        while (volumeDirection == _off)
        {
            _audioSource.volume -= Time.deltaTime  / _speedVolume;
            
            yield return null;
        }
    }
}