using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Sprites;

public class MusicControl4 : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    public Button soundButton;
    public Sprite soundOnIcon;
    public Sprite soundOffIcon;
    Image thisImg;

    void Start()
    {
        thisImg = GetComponent<Image>();
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }
        else
        {
            Load();
        }
    }


    private void Update()
    {
        if (AudioListener.volume != 0)
        {
            thisImg.overrideSprite= soundOnIcon;
        }
        else
        {
            thisImg.overrideSprite = soundOffIcon;
        }
    }
 

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
        //ChangeButton();
    }
    public void Mute()
    {
        // 현재 음소거 되어 있으면 소리를 풀로 키움
        if (AudioListener.volume == 0)
        {
            AudioListener.volume = 1;
            volumeSlider.value = 1;
        }
        // 현재 소리 나오면 음소거
        else
        {
            AudioListener.volume = 0;
            volumeSlider.value = 0;
        }
        Save();
        //ChangeButton();
    }
    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
        AudioListener.volume = volumeSlider.value;
        //ChangeButton();
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }
}
