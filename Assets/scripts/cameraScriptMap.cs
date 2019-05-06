using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScriptMap : MonoBehaviour
{
    public   AudioClip[] musics1;
    public static  AudioClip[] musics;
    private static  AudioSource _as;
    public static bool mainthemPalying = true;
    public static bool battlePalying = false;
    public static  bool goindOut = false;
    public static bool goindOut1 = false;
    private void Awake()
    {
        _as = GetComponent<AudioSource>();
    }
    void Start()
    {
        musics = musics1;
        _as.clip = musics[13];
        _as.PlayOneShot(_as.clip);
    }


    void Update()
    {
        if (player_controller.player.transform.position.x > -12 && player_controller.player.transform.position.x < 12 && player_controller.player.transform.position.y < 3.4f && player_controller.player.transform.position.y > -3)
        {
            playInStartPos();
        }
        if (goindOut)
        {         
            playOutStartPos();
        }


    }
    

        public void playInStartPos()
    {
        if (player_controller.player.transform.position.x > 7 && player_controller.player.transform.position.x < 13 && player_controller.player.transform.position.y < -1 && player_controller.player.transform.position.y > -3 && GameObject.Find("wolfenemy1")!=null)
        {
            if (battlePalying == false)
            {
                _as.Stop();
                battlePalying = true;
                _as.clip = musics[2];
                _as.PlayOneShot(_as.clip);
                mainthemPalying = false;
            }

        }
        else
        {
            battlePalying = false;
            if (mainthemPalying == false)
            {
                _as.Stop();
                mainthemPalying = true;
                _as.clip = musics[13];
                _as.PlayOneShot(_as.clip);
            }
        }
    }
    public static  void playOutStartPos()
    {
        if (goindOut1 == false)
        {
            _as.Stop();
            goindOut1 = true;
            _as.clip = musics[11];
            _as.PlayOneShot(_as.clip);
        }
    }
    public static void playBattlemusic()
    {
        _as.Stop();
        _as.clip = musics[2];
        _as.PlayOneShot(_as.clip);
        
    }
    public static  void stopBattlemusic()
    {
        goindOut1 = false;
        goindOut = true;
    }
    public static void playTavernmusic()
    {
        _as.Stop();
        _as.clip = musics[5];
        _as.PlayOneShot(_as.clip);

    }

}
