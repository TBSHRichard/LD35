using UnityEngine;

public class Block : MonoBehaviour {
    private Transform _blockTransform;
    private Vector3 _defaultPosition;
    private Rigidbody2D _rigidbody;
    
	void Start ()
    {
        _blockTransform = GetComponent<Transform>();
        _defaultPosition = _blockTransform.localPosition;
	}

    /*
        Reset the Block back to its default position and scale.
    */
    public void ResetBlock()
    {
        _blockTransform.localScale = new Vector3(1f, 1f, 1f);
        _blockTransform.localPosition = _defaultPosition;
    }

    /*
        Locks the Block so the Player cannot move it.
    */
    public void LockBlock()
    {
        if (_rigidbody != null)
        {
            Destroy(_rigidbody);
            _rigidbody = null;
        }
    }

    /*
        Unlocks the Block so it may be moved.
    */
    public void UnlockBLock()
    {
        if (_rigidbody == null)
        {
            _rigidbody = gameObject.AddComponent<Rigidbody2D>();
            _rigidbody.freezeRotation = true;
            _rigidbody.drag = 25f;
            _rigidbody.mass = 25f;
            _rigidbody.gravityScale = 0f;
        }
    }
}
