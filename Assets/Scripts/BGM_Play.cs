using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BGM_Play : MonoBehaviour
{
    [SerializeField] AudioSource[] bgmList;
    [SerializeField] AudioClip[] playList;
    [SerializeField] GameObject fatherSoundSpeaker;
    [SerializeField] private int currentNumberIndex = 0, pastNumber01 = 0, pastNumber02 = 0;

    AudioSource audiosource;
    AudioClip audioMain;
    [SerializeField] AudioSource[] soundSpeakersInScene;

    void Start()
    {
        currentNumberIndex = GetRandomNumber(currentNumberIndex);
        bgmList = gameObject.GetComponentsInChildren<AudioSource>();
        soundSpeakersInScene = fatherSoundSpeaker.GetComponentsInChildren<AudioSource>();
        audiosource = bgmList[currentNumberIndex].GetComponent<AudioSource>();
        audioMain = playList[currentNumberIndex];
        audiosource.PlayOneShot(audioMain, 1);
        for (int i = 0; i < soundSpeakersInScene.Length; i++)
        {
            soundSpeakersInScene[i].PlayOneShot(audioMain, 1) ;
            //soundSpeakersInScene[i].
        }
    }

    void Update()
    {

        if (!audiosource.isPlaying)
        {
            pastNumber02 = pastNumber01;
            pastNumber01 = currentNumberIndex;
            currentNumberIndex = GetRandomNumber(currentNumberIndex);

            if (pastNumber01 != currentNumberIndex && pastNumber02 != currentNumberIndex)
            {
                /*switch(currentNumberIndex)
                {
                    case 0:
                    case 3:
                    case 6:
                    case 9:
                    for(int i = 0; i < bgmList.Length; i += 3)
                    {
                        bgmList[i].Play();
                    }
                    break;

                    case 1:
                    case 4:
                    case 7:
                    case 10:
                    for(int i = 1; i < bgmList.Length; i += 3)
                    {
                        bgmList[i].Play();
                    }
                    break;

                    case 2:
                    case 5:
                    case 8:
                    case 11:
                    for(int i = 2; i < bgmList.Length; i += 3)
                    {
                        bgmList[i].Play();
                    }
                    break;


                }*/

                //audiosource = bgmList[currentNumberIndex].GetComponent<AudioSource>();
                audioMain = playList[currentNumberIndex];
                //audiosource.Play();
                audiosource.PlayOneShot(audioMain, 1);
                for (int i = 0; i < soundSpeakersInScene.Length; i++)
                {
                    soundSpeakersInScene[i].PlayOneShot(audioMain, 1);
                }
            }
            else
            {
                currentNumberIndex = GetRandomNumber(currentNumberIndex);
            }

        }
        //else
        //{

        //}
    }

    private int GetRandomNumber(int number)
    {
        number = Random.Range(0, 4);
        return number;
    }

}