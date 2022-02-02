using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NextOrBack : MonoBehaviour
{
    public GameObject[] fons;
    public AudioClip[] music;
    public Button buttonNext, buttonBack;
    public Image image, loop;
    public Sprite play, pause;
    public TextMeshProUGUI timeText;
    public TMP_InputField inputHours, inputMinutes;
    private float hours, minutes, seconds;
    private AudioSource audioSours;
    private int i = 0;
    private bool stopNext, timeGo = false;
    private void Start()
    {
        audioSours = GetComponent<AudioSource>();
        audioSours.clip = music[i];
        audioSours.Play();
    }
    void Update()
    {
        if (i == 9)
        { buttonNext.interactable = false; }
        else buttonNext.interactable = true;

        if (i == 0)
        { buttonBack.interactable = false; }
        else buttonBack.interactable = true;

        if (!audioSours.isPlaying && stopNext)
        { Next(); }

        if (timeGo)
        { TimeMinutes(); }
    }
    private void TimeMinutes()
    {
        seconds -= Time.deltaTime;

        timeText.text = Math.Ceiling(hours) + ":" + Math.Ceiling(minutes) + ":" + Math.Ceiling(seconds);
        
        if (seconds <= 0)
        {
            minutes = minutes - 1;

            if(minutes < 0)
            {
                hours = hours - 1;

                if (hours < 0)
                {
                    hours = 0;
                    minutes = 0;
                    seconds = 0;
                }
                else minutes = 60;
            }
            else seconds = 60;
        }
        if (seconds <= 0 && minutes <= 0 && hours <= 0)
        { Pause(); timeGo = false; timeText.text = ""; }
    }
    public void TimeGo()
    {
        hours = float.Parse(inputHours.text);
        minutes = float.Parse(inputMinutes.text);
        seconds = 0; 
        timeGo = true;
    }
    public void Next()
    {
        if (i >= 0 && i < 9)
        {
            image.sprite = pause;
            fons[i].SetActive(false);
            i++;
            fons[i].SetActive(true);
            audioSours.clip = music[i];
            audioSours.Play();
        }
    }
    public void Back()
    {
        if (i > 0 && i <= 9)
        {
            image.sprite = pause;
            fons[i].SetActive(false);
            i--;
            fons[i].SetActive(true);
            audioSours.clip = music[i];
            audioSours.Play();
        }
    }
    public void Pause()
    {
        if (audioSours.isPlaying)
        { audioSours.Pause(); image.sprite = play; stopNext = false; }
        else { audioSours.Play(); image.sprite = pause; stopNext = true; }
    }
    public void Loop()
    {
        if (audioSours.loop == false)
        {
            audioSours.loop = true;
            loop.color = Color.green;
        }
        else { audioSours.loop = false; loop.color = Color.white; }
        
    }
}
