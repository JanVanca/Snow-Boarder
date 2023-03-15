using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    CircleCollider2D playerHead;
    [SerializeField] float loadDelay = 0.5f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;
    bool hasCrashed = false;

    private void Start() {
        playerHead = GetComponent<CircleCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        
        if(other.gameObject.tag == "Ground" && playerHead.IsTouching(other.collider) && hasCrashed == false) {
            hasCrashed = true;
            FindObjectOfType<PlayerController>().DisableControls();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadScene", loadDelay);
        }
    }

    private void ReloadScene() {
        SceneManager.LoadScene(0);
    }
}
