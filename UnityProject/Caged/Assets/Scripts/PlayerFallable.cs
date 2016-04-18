using UnityEngine;
using System.Collections;

public class PlayerFallable : Fallable {
    private Vector3 _lastWalkablePosition;
    private Player _player;
    private Room _lastRoom;

    protected override void Start()
    {
        base.Start();

        _lastWalkablePosition = objectTransform.position;
        _player = GetComponent<Player>();
    }

    protected override void Update()
    {
        base.Update();

        if (!IsFalling())
        {
            Vector2 testPosition = new Vector2(Mathf.Round(objectTransform.position.x), Mathf.Round(objectTransform.position.y));
            RaycastHit2D hit = Physics2D.Raycast(testPosition + new Vector2(0.5f, -0.9f), Vector2.up, 0.4f);

            if (hit.collider == null)
            {
                _lastWalkablePosition = new Vector3(testPosition.x, testPosition.y);
                _lastRoom = _player.currentRoom;
            }
        }
    }

    public override void StartFall(int floor, Pit pit)
    {
        if (_player.form != AnimalForm.Crow)
        {
            base.StartFall(floor, pit);

            _player.RemoveRightClickAction();
            _player.HideHelper();
        }
    }

    public override void EndFall(int floor, Pit pit)
    {
        objectTransform.localScale = new Vector3(1f, 1f, 1f);
        objectCollider.enabled = true;

        if (floor > 1)
        {
            _player.Teleport(pit.GetFallLocation(), pit.GetTargetRoom());
        }
        else
        {
            _player.Teleport(_lastWalkablePosition, _lastRoom);
            _player.TakeDamage(1);
        }
    }
}
