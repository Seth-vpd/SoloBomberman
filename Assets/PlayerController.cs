using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;
    private Animator animator;
    [SerializeField] private GameObject bomb;
    private bool run = false;
    private bool isDead = false;

    public bool IsDead { get { return isDead; } set { isDead = value; } }
    Vector3 axis;
    [SerializeField] private float speed = 6f;
    public Vector3 resetPos;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        PlayerInput();
        animate();
        rotate();
        animator.SetBool("State", run);
        if (isDead) {
            gameObject.SetActive(false);
            Invoke("resetPlayer", 3f);
            isDead = false;
        }
    }

    private void animate()
    {
        if (axis.x == 1f || axis.z == 1f || axis.x == -1f || axis.z == -1f) {
            run = true;
        } else {
            run = false;
        }
    }
    private void PlayerInput() {
        if (gameObject.name == "Player 1") {
            if (Input.GetKey(KeyCode.UpArrow)) {
                axis = new Vector3(0, 0, 1f);
            }
            else if (Input.GetKey(KeyCode.DownArrow)) {
                axis = new Vector3(0, 0, -1f);
            }
            else if (Input.GetKey(KeyCode.LeftArrow)) {
                axis = new Vector3(-1f, 0, 0);
            }
            else if (Input.GetKey(KeyCode.RightArrow)) {
                axis = new Vector3(1f, 0, 0);
            } else
                axis = new Vector3(0, 0, 0);
            
            if (Input.GetKeyDown(KeyCode.Space)) {
                Instantiate(bomb, new Vector3 (transform.position.x, transform.position.y + 0.5f, transform.position.z + 0.3f) , Quaternion.identity);
            }
        } if (gameObject.name == "Player 2") {
            if (Input.GetKey(KeyCode.W)) {
                axis = new Vector3(0, 0, 1f);
            }
            else if (Input.GetKey(KeyCode.S)) {
                axis = new Vector3(0, 0, -1f);
            }
            else if (Input.GetKey(KeyCode.A)) {
                axis = new Vector3(-1f, 0, 0);
            }
            else if (Input.GetKey(KeyCode.D)) {
                axis = new Vector3(1f, 0, 0);
            } else 
                axis = new Vector3(0, 0, 0);

            if (Input.GetKeyDown(KeyCode.X)) {
                Instantiate(bomb, new Vector3 (transform.position.x, transform.position.y + 0.5f, transform.position.z + 0.3f) , Quaternion.identity);
            }
        }
    }
    private void rotate() {
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, axis, 10f, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);
    }
    private void FixedUpdate()
    {
        rb.velocity = axis * speed;
    }

    public void resetPlayer()
    {
        gameObject.transform.position = resetPos;
        gameObject.SetActive(true);
    }
}

 