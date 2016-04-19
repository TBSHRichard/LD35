using UnityEngine;

public class Fallable : MonoBehaviour {
    public Collider2D objectCollider;
    public AudioSource fallSound;

    private Transform _objectTransform,
        _pitTransform;
    private const int MAX_TIME = 60;
    private int _floor,
        _fallTimer;
    private Vector3 _startPosition;
    private Pit _pit;

    protected virtual void Start()
    {
        _objectTransform = transform;
        _fallTimer = -1;
    }

    protected Transform objectTransform
    {
        get { return _objectTransform; }
    }

    public virtual void StartFall(int floor, Pit pit)
    {
        fallSound.Play();

        objectCollider.enabled = false;
        _fallTimer = MAX_TIME;
        _startPosition = _objectTransform.position;
        _floor = floor;
        _pit = pit;
        _pitTransform = pit.transform;
    }

    public virtual void EndFall(int floor, Pit pit)
    {
        Destroy(gameObject);
    }

    protected bool IsFalling()
    {
        return _fallTimer > 0;
    }

    protected virtual void Update()
    {
        if (IsFalling())
        {
            float percent = ((float)MAX_TIME - _fallTimer + 1) / MAX_TIME;
            float scale = 1f - percent;

            _objectTransform.position = Vector3.Lerp(_startPosition, _pitTransform.position + new Vector3(0.5f, -0.5f), percent);
            _objectTransform.localScale = new Vector3(scale, scale, 1f);

            _fallTimer--;
        }
        else if (_fallTimer == 0)
        {
            EndFall(_floor, _pit);

            _fallTimer = -1;
        }
    }
}
