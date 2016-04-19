using UnityEngine;

public class ItemGet : MonoBehaviour {
    private AudioSource _sound;

    void Start()
    {
        _sound = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!_sound.isPlaying)
        {
            Destroy(gameObject);
        }
    }
}
