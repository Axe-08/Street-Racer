using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontrol : MonoBehaviour
{
    public float leftConstraint = -2f;
    public float rightConstraint = 2f;
    public float moveSpeed = 4f;
    public Sprite boom;
    public logicControl logicControl;
    SpriteRenderer spriteRenderer;
    [SerializeField] GameObject gameOver;
    [SerializeField] audiomanager audiomanager;

    private bool useGyroscope = false;
    private float touchAreaHeight = Screen.height * 0.8f;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = logicControl.currentCar;
        logicControl.isPlayerAlive = true;
        useGyroscope = PlayerPrefs.GetInt("ControlMethod", 0) == 1;
    }

    

    // Update is called once per frame
    void Update()
    {
        checkCar();
        HandleMovement();
    }

    void HandleMovement()
    {
        if (useGyroscope)
        {
            HandleGyroscopeMovement();
        }
        else
        {
            HandleTouchMovement();
        }
    }

    void HandleGyroscopeMovement()
    {
        float tilt = Input.acceleration.x;
        Vector3 newPosition = transform.position + new Vector3(tilt * moveSpeed * Time.deltaTime, 0f, 0f);
        newPosition.x = Mathf.Clamp(newPosition.x, leftConstraint, rightConstraint);
        transform.position = newPosition;
    }

    void HandleTouchMovement()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.position.y < touchAreaHeight) // Only process touches below the threshold
            {
                float horizontalInput = touch.position.x > Screen.width / 2 ? 1 : -1;
                Vector3 newPosition = transform.position + new Vector3(horizontalInput * moveSpeed * Time.deltaTime, 0f, 0f);
                newPosition.x = Mathf.Clamp(newPosition.x, leftConstraint, rightConstraint);
                transform.position = newPosition;
            }
        }
    }
    void checkCar()
    {
        if(spriteRenderer.sprite != boom && spriteRenderer.sprite != logicControl.currentCar)
        {
            spriteRenderer.sprite = logicControl.currentCar;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy")){
            BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
            boxCollider.enabled = false;
            audiomanager.playSFX(audiomanager.carCrash);
            spriteRenderer.sprite = boom;
            logicControl.isPlayerAlive = false;
            logicControl.updateHighScore();
            audiomanager.pauseBgm();
            Invoke("ds", 1);
        }
    }
    void ds()
    {
        gameOver.SetActive(true);
        audiomanager.PlayMenuBgm();
        audiomanager.filter.enabled = true;
        Destroy(gameObject);
    }
}
