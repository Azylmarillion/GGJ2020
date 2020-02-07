using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundRandomiser : MonoBehaviour
{
    [SerializeField] private ClipsCollection _clicks = null;


    public AudioSource _source { get; private set; }
    private int era => TimeShifter.CurrentEra;

    private void Start()
    {
        _source = GetComponent<AudioSource>();
    }

    public void Play()
    {
        if(_source == null)
            _source = GetComponent<AudioSource>();
        _source.pitch = Random.Range(_clicks.pitch[era][0], _clicks.pitch[era][1]);
        _source.volume = Random.Range(_clicks.volume[era][0], _clicks.volume[era][1]);
        _source.clip = _clicks.list[era];
        _source.Play();
        if(_source.GetComponent<CloseButton>())
            StartCoroutine(DestroyAtEndOfPlay());

    }

    private IEnumerator DestroyAtEndOfPlay()
    {
        while(_source.isPlaying)
            yield return null;
        Destroy(gameObject);
    }
}
