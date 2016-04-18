using UnityEngine;
using System.Collections;

public class Twig : MonoBehaviour {
    /*
        Called once the break animation finishes.
    */
    public void FinishBreakAnimation()
    {
        Destroy(gameObject);
    }
}
