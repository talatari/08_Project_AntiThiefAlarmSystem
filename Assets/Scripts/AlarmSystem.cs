using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AlarmSystem : MonoBehaviour
{
    private AudioSource _audioSource;
    private int _speedVolume = 2;

    private void OnValidate() => _audioSource ??= GetComponent<AudioSource>();

    public IEnumerator AlarmOn()
    {
        _audioSource.Play();
        
        while (_audioSource.volume < 1)
        {
            _audioSource.volume += Time.deltaTime / _speedVolume;
            
            yield return null;
        }
    }
    
    public IEnumerator AlarmOff()
    {
        while (_audioSource.volume > 0)
        {
            _audioSource.volume -= Time.deltaTime / _speedVolume;
            
            yield return null;
        }
        
        _audioSource.Stop();
    }
    
    
}