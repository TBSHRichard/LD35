﻿using UnityEngine;
using UnityEngine.UI;

public class FormCoin : MonoBehaviour {
    public TransformButton buttonToUnlock;
    public GameObject poof,
        collectSound;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            buttonToUnlock.Unlock();
            Instantiate(poof, transform.position, Quaternion.identity);
            Instantiate(collectSound, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }
}
