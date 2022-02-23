using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicInit : MonoBehaviour
{

    AudioSource audioSource;

    [SerializeField] Canvas optionsCanvas;
    [SerializeField] Button backButton;
   

    [SerializeField] Canvas menuCanvas;
    [SerializeField] Button startGame;

    [SerializeField] Canvas hsCanvas;
    [SerializeField] Button backHSButton;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();

        optionsCanvas.enabled = false;
        menuCanvas.enabled = true;
        hsCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowOptions()
    {
        optionsCanvas.enabled = true;
        menuCanvas.enabled = false;
        hsCanvas.enabled = false;
        backButton.Select();
    }
    public void ShowMenu()
    {
        menuCanvas.enabled = true;
        optionsCanvas.enabled = false;
        hsCanvas.enabled = false;
        startGame.Select();
    }

    public void ShowHS()
    {
        menuCanvas.enabled = false;
        optionsCanvas.enabled = false;
        hsCanvas.enabled = true;
        backHSButton.Select();
    }
}
