using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour {
    public Animator characterAnimator;
    public GameObject mouseHelper;

    private Rigidbody2D _rigidbody;
    private RightClickAction _rightClickAction;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    /*
        Shows the MouseHelper when in an area where the Player can right click
        to interact with something.
    */
    public void ShowHelper()
    {
        mouseHelper.SetActive(true);
    }

    /*
        Hides the MouseHelper.
    */
    public void HideHelper()
    {
        mouseHelper.SetActive(false);
    }

    /*
        The RightClickAction that is used in the current area.
    */
    public void SetRightClickAction(RightClickAction action)
    {
        _rightClickAction = action;
    }

    /*
        Remove the RightClickAction so nothing happens upon a right click.
    */
    public void RemoveRightClickAction()
    {
        SetRightClickAction(null);
    }

    /*
        The Player has performed a right click; execute the current
        RightClickAction;
    */
    public void Act()
    {
        if (_rightClickAction != null)
        {
            _rightClickAction.Action(this);
        }
    }

    /*
        Event is called whenever the player clicks the window.
    */
    public void PointerClick(BaseEventData e)
    {
        PointerEventData pointerEvent = e as PointerEventData;

        if (pointerEvent.button == PointerEventData.InputButton.Right)
        {
            Act();
        }
    }

    /*
        Handles the Player's movement. Called once per frame in Update.
    */
    private void HandleMovement()
    {
        float xVel = 0,
            yVel = 0;

        if (Input.GetAxis("Horizontal") < 0)
        {
            xVel = -5f;
            characterAnimator.SetInteger("Facing", 4);
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            xVel = 5f;
            characterAnimator.SetInteger("Facing", 2);
        }

        if (Input.GetAxis("Vertical") < 0)
        {
            yVel = -5f;
            characterAnimator.SetInteger("Facing", 3);
        }
        else if (Input.GetAxis("Vertical") > 0)
        {
            yVel = 5f;
            characterAnimator.SetInteger("Facing", 1);
        }

        if (xVel != 0 && yVel != 0)
        {
            xVel /= Mathf.Sqrt(2f);
            yVel /= Mathf.Sqrt(2f);
        }

        Vector2 velocity = new Vector2(xVel, yVel);

        _rigidbody.velocity = velocity;
        characterAnimator.SetFloat("MoveSpeed", _rigidbody.velocity.sqrMagnitude);
    }

	void Update () {
        HandleMovement();
	}
}
