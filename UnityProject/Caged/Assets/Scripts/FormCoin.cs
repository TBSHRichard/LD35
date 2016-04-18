using UnityEngine;
using UnityEngine.UI;

public class FormCoin : MonoBehaviour {
    public TransformButton buttonToUnlock;
    public GameObject poof;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            buttonToUnlock.Unlock();
            Instantiate(poof, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }
}
