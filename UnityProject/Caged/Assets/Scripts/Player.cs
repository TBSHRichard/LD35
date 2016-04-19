using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
    public Animator characterAnimator;
    public GameObject mouseHelper;
    public SpriteRenderer characterSprite;
    public Transform characterTransform;
    public RuntimeAnimatorController humanFormController,
        lionFormController,
        snakeFormController,
        crowFormControler;
    public Room currentRoom;
    public GameObject poof;
    public Text healthText,
        keysText;
    public RectTransform healthBarTransform;
    public AudioSource walkSound;
    public AudioClip humanSteps,
        lionSteps,
        snakeSteps,
        crowSteps;

    private Transform _playerTransform;
    private Rigidbody2D _rigidbody;
    private RightClickAction _rightClickAction;
    private AnimalForm _form;
    private int _health,
        _numberOfKeys;
    private float _maxHealthBarWidth;

    void Start()
    {
        _playerTransform = GetComponent<Transform>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _form = AnimalForm.Human;
        currentRoom.EnterRoom(this);
        _health = 10;
        _numberOfKeys = 0;
        _maxHealthBarWidth = healthBarTransform.rect.width;
    }

    /*
        Transform into the new form.
    */
    public void Shapeshift(AnimalForm newForm)
    {
        if (newForm != AnimalForm.Any && newForm != _form)
        {
            _form = newForm;
            characterSprite.flipX = false;
            characterTransform.localPosition = Vector3.zero;
            Instantiate(poof, transform.position, Quaternion.identity);

            if (_rightClickAction != null)
            {
                _rightClickAction.UpdateHelper(this);
            }

            if (_form == AnimalForm.Human)
            {
                characterAnimator.runtimeAnimatorController = humanFormController;
                walkSound.clip = humanSteps;
                currentRoom.UnlockBlocks();
            }
            else if (_form == AnimalForm.Lion)
            {
                characterAnimator.runtimeAnimatorController = lionFormController;
                walkSound.clip = lionSteps;
                currentRoom.LockBlocks();
            }
            else if (_form == AnimalForm.Snake)
            {
                characterAnimator.runtimeAnimatorController = snakeFormController;
                walkSound.clip = snakeSteps;
                currentRoom.LockBlocks();
            }
            else
            {
                characterAnimator.runtimeAnimatorController = crowFormControler;
                walkSound.clip = crowSteps;
                currentRoom.LockBlocks();
            }
        }
    }

    /*
        The current form the Player is in.
    */
    public AnimalForm form
    {
        get { return _form; }
    }

    /*
        Set the health display in the HUD to let the Player know how much health
        he/she has left.
    */
    private void UpdateHealthDisplay()
    {
        healthText.text = _health.ToString();

        healthBarTransform.sizeDelta = new Vector2((_health / 10f) * _maxHealthBarWidth, healthBarTransform.sizeDelta.y);
    }

    /*
        Damage the Player by a certain amount. If health hits 0, the game is over!
    */
    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            _health = 0;
        }

        UpdateHealthDisplay();

        if (_health == 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    /*
        Set the key display in the HUD to let the Player know how many keys
        he/she has.
    */
    private void UpdateKeyDisplay()
    {
        keysText.text = _numberOfKeys.ToString();
    }

    /*
        Give a key to the Player.
    */
    public void GiveKey()
    {
        _numberOfKeys += 1;
        UpdateKeyDisplay();
    }

    public void UseKey()
    {
        if (_numberOfKeys > 0)
        {
            _numberOfKeys -= 1;
            UpdateKeyDisplay();
        }
    }

    /*
        The number of keys the Player has.
    */
    public int numberOfKeys
    {
        get { return _numberOfKeys; }
    }

    /*
        Teleport the Player to a new Room.
    */
    public void Teleport(Vector3 location, Room room)
    {
        _playerTransform.position = location;

        if (!currentRoom.Equals(room))
        {
            currentRoom.ExitRoom();
            currentRoom = room;
            currentRoom.EnterRoom(this);
        }
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
        float speed = velocity.sqrMagnitude;

        if (speed > 0)
        {
            if (!walkSound.isPlaying)
            {
                walkSound.Play();
            }
        }
        else
        {
            walkSound.Stop();
        }

        _rigidbody.velocity = velocity;
        characterAnimator.SetFloat("MoveSpeed", speed);
    }

	void Update () {
        HandleMovement();
	}
}
