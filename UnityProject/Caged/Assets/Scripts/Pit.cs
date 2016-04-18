using UnityEngine;

public class Pit : MonoBehaviour {
    public int floor = 1;
    public LeverObject trapDoor;
    public Room targetRoom;

    private Transform _pitTransform;

    protected virtual void Start()
    {
        _pitTransform = transform;
    }

    protected Transform pitTransform
    {
        get { return _pitTransform; }
    }

    public virtual Vector3 GetFallLocation()
    {
        return _pitTransform.position;
    }

    public virtual Room GetTargetRoom()
    {
        return targetRoom;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (trapDoor == null || trapDoor.isOpen)
        {
            if (other.tag == "Block" || other.tag == "Player")
            {
                Bounds blockZone = new Bounds(_pitTransform.position, new Vector3(1f, 1f, 1f));

                if (blockZone.Contains(other.transform.position))
                {
                    other.GetComponent<Fallable>().StartFall(floor, this);
                }
            }
        }
    }
}
