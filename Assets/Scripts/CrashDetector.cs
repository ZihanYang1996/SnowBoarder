using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float reloadTime = 2f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;
    PlayerController playerController;
    bool playerAlive = true;

    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>(); //Approach 1
        // playerController = FindObjectOfType<PlayerController>(); //Approach 2
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground" && playerAlive)
        {
            playerAlive = false;
            playerController.DisableControls();
            crashEffect.Play();  // Doesn't matter if it's brefore or after the StartCoroutine
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            StartCoroutine(ReloadScene());
        }
    }

    IEnumerator ReloadScene()
    {
        yield return new WaitForSeconds(reloadTime);
        SceneManager.LoadScene(0);
    }
}