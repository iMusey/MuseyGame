using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class pauseMenu : MonoBehaviour
{
    public static pauseMenu pMenu;

    public GameObject pauseContainer;
    public pauseSlide[] slides = new pauseSlide[4];
    public int[] slideIndexes = new int[4];
    public pauseSlide generalSettings;
    public pauseSlide controlsSettings;
    public pauseSlide audioSettings;
    public pauseSlide visualSettings;

    // 0 general
    // 1 controls
    // 2 audio
    // 3 visual
    public int slideIndex = 0;

    public bool paused;

    // Start is called before the first frame update
    void Awake()
    {
        pMenu = this;

        slides[0] = generalSettings;
        slides[1] = controlsSettings;
        slides[2] = audioSettings;
        slides[3] = visualSettings;
    }

    void Start()
    {
        ArrangeSlides(slideIndex);

        for (int i = 0; i < slides.Length; i++)
        {
            slideIndexes[i] = slides[i].transform.GetSiblingIndex();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check if pause button is pressed
        if (playerScript.player != null)
        {
            if (Input.GetKeyDown(playerScript.player.pause))
            {
                Pause();
            }
            if (Input.GetKeyDown(playerScript.player.menuR))
            {
                SlideForward();
            }
            if (Input.GetKeyDown(playerScript.player.menuL))
            {
                SlideBackward();
            }
        }
        

    }

    public void Pause()
    {
        if (!paused)
        {
            Time.timeScale = 0;
            paused = true;
            pauseContainer.SetActive(paused);
        }
        else
        {
            Time.timeScale = 1;
            paused = false;
            pauseContainer.SetActive(paused);
        }
    }

    void SlideForward()
    {
        if (slideIndex == 0)
        {
            slideIndex = slides.Length - 1;
        }
        else
        {
            slideIndex--;
        }

        ArrangeSlides(slideIndex);
    }

    void SlideBackward()
    {

        if (slideIndex == slides.Length - 1)
        {
            slideIndex = 0;
        }
        else
        {
            slideIndex++;
        }

        ArrangeSlides(slideIndex);
    }

    void ArrangeSlides(int x)
    {
        int index = x;

        pauseContainer.transform.rotation = Quaternion.Euler(0, 0, 5*slideIndex);

        for (int count = 0; count < slides.Length; count++)
        {
            slides[index].transform.SetSiblingIndex(slideIndexes[count]);

            if (index == slides.Length - 1)
            {
                index = 0;
            }
            else
            {
                index++;
            }
        }
    }
}
