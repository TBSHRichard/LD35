using UnityEngine;
using System.Collections;

public class LeverObject : MonoBehaviour {
    public Animator objectAnimator;
    public bool isOpen;

    void Start()
    {
        objectAnimator.SetBool("IsOpen", isOpen);
    }

    /*
        Toggle the open state of the object.
    */
    public void Toggle()
    {
        isOpen = !isOpen;
        objectAnimator.SetBool("IsOpen", isOpen);
    }
}
