using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class WinZone : MonoBehaviour
{
    private AudioSource audioSource;
    public GameObject targetCanvas;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetCanvas.gameObject.SetActive(false);
        audioSource = GetComponent <AudioSource>();

    }

    // Update is called once per frame
    void OnTriggerEnter2D (Collider2D col){
       
        targetCanvas.gameObject.SetActive(true);
        audioSource.Play();
    }
}
