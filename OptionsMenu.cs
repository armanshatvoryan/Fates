using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour {

    public AudioMixer audioMixer;

    Resolution[] resolutions;

    public Dropdown resolutionsDD;

    void Start()
    {
        resolutions = Screen.resolutions;

        resolutionsDD.ClearOptions();

        List<string> options = new List<string>();

        int currentResolInd = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolInd = i;
            }
        }
        resolutionsDD.AddOptions(options);
        resolutionsDD.value = currentResolInd;
        resolutionsDD.RefreshShownValue();
   }

    public void SetResolution(int resolInd)
    {
        Resolution resolution = resolutions[resolInd];

        Screen.SetResolution(resolution.width, resolution.height , Screen.fullScreen);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex); 
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
}

