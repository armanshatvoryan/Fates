using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManagerScript:MonoBehaviour  {

    public static AudioClip
        demonSpawnSound,
        fightStartSound, 
        goblinDiesSound,
        meetingSnakeSound,
        monkeyDiesSound, 
        playerDiesSound,
        shamanDiesSound,
        shootingSound, 
        swordHitSound,
        winningWitcherSound,
        witcherDiesSound;
    static AudioSource audioSource;

     void Start()
    {
        demonSpawnSound = Resources.Load<AudioClip>("demonSpawn");
        fightStartSound = Resources.Load<AudioClip>("fightStart");
        goblinDiesSound = Resources.Load<AudioClip>("goblinDies");
        meetingSnakeSound = Resources.Load<AudioClip>("meetingSnake");
        monkeyDiesSound = Resources.Load<AudioClip>("monkeyDies");
        playerDiesSound = Resources.Load<AudioClip>("playerDies");
        shamanDiesSound = Resources.Load<AudioClip>("shamanDies");
        shootingSound = Resources.Load<AudioClip>("shooting");
        swordHitSound = Resources.Load<AudioClip>("swordHit");
        winningWitcherSound = Resources.Load<AudioClip>("winningWitcher");
        witcherDiesSound = Resources.Load<AudioClip>("witcherDies");

        audioSource = GetComponent<AudioSource>();
    }
    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "demonSpawn":
                audioSource.PlayOneShot(demonSpawnSound);
                break;
            case "fightStart":
                audioSource.PlayOneShot(fightStartSound);
                break;
            case "goblinDies":
                audioSource.PlayOneShot(goblinDiesSound);
                break;
            case "meetingSnake":
                audioSource.PlayOneShot(meetingSnakeSound);
                break;
            case "monkeyDies":
                audioSource.PlayOneShot(monkeyDiesSound);
                break;
            case "playerDies":
                audioSource.PlayOneShot(playerDiesSound);
                break;
            case "shamanDies":
                audioSource.PlayOneShot(shamanDiesSound);
                break;
            case "shooting":
                audioSource.PlayOneShot(shootingSound);
                break;
            case "swordHit":
                audioSource.PlayOneShot(swordHitSound);
                break;
            case "winningWitcher":
                audioSource.PlayOneShot(winningWitcherSound);
                break;
            case "witcherDies":
                audioSource.PlayOneShot(witcherDiesSound);
                break;

        }
    }

}
