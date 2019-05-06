using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraSript : MonoBehaviour
{
    public AudioClip [] musics;
    private AudioSource _as;

    private void Awake()
    {
        _as = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        _as.clip = musics[Random.Range(0, musics.Length)];
        _as.PlayOneShot(_as.clip);
    }

   
}
