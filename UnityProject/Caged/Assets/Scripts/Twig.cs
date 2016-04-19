using UnityEngine;
using System.Collections;

public class Twig : MonoBehaviour {
    public AudioSource chopSound;

    public void StartBreak()
    {
        chopSound.Play();
    }

    /*
        Called once the break animation finishes.
    */
    public void FinishBreakAnimation()
    {
        Destroy(gameObject);
    }
}
