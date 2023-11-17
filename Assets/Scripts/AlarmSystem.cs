using System.Collections;
using UnityEngine;

[RequireComponent(
    typeof(AudioSource))]

public class AlarmSystem : MonoBehaviour
{
    private AudioSource _audioSource;
    private int _speedVolume = 2;
    private Coroutine _coroutineAlarm;
    private int _on = 1;
    private int _off = -1;

    private void Awake() => 
        _audioSource = GetComponent<AudioSource>();

    private void OnDisable()
    {
        if (_coroutineAlarm is not null)
            StopCoroutine(_coroutineAlarm);
    }

    public void AlarmOn()
    {
        if (_coroutineAlarm is not null)
            StopCoroutine(_coroutineAlarm);
            
        _coroutineAlarm = StartCoroutine(Alarm(_on));
    }

    public void AlarmOff()
    {
        if (_coroutineAlarm is not null)
            StopCoroutine(_coroutineAlarm);
            
        _coroutineAlarm = StartCoroutine(Alarm(_off));
    }
    
    private IEnumerator Alarm(int direction)
    {
        if (_audioSource.isPlaying is false)
            _audioSource.Play();
        
        while (direction == _on)
        {
            _audioSource.volume += Time.deltaTime  / _speedVolume;
            
            yield return null;
        }
        
        while (direction == _off)
        {
            _audioSource.volume -= Time.deltaTime  / _speedVolume;
            
            yield return null;
        }
    }
    
    
}