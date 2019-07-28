using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraSript : MonoBehaviour
{
    public AudioClip [] musics;
    public GameObject loading;
    private AudioSource _as;

    private void Awake()
    {
        loading.SetActive(true);
        _as = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        _as.clip = musics[Random.Range(0, musics.Length)];
        _as.PlayOneShot(_as.clip);
        StartCoroutine(loadThings());
        
    }
    IEnumerator loadThings()
    {
        yield return new WaitForSeconds(4);
        loading.SetActive(false);

    }


}
