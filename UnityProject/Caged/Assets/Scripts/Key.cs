using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour
{
    public GameObject poof;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Player>().GiveKey();
            Instantiate(poof, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }
}
