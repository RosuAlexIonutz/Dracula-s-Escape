using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce = 10f; 
    [SerializeField] private float maxJumpHeight = 5f; 
    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;

    
    [SerializeField] private GameObject objectToRevealWin;  
    [SerializeField] private GameObject objectToRevealDeath; 
    [SerializeField] private Button exitButton;

    private void Awake(){
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!anim.GetBool("dead")) 
        {
            float horizontalInput = Input.GetAxis("Horizontal");
        
            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

            if (horizontalInput > 0.01f)
            {
                transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            }
            else if (horizontalInput < -0.01f)
            {
                transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
            }

            if (Input.GetKey(KeyCode.Space) && grounded)
            {
                Jump();
            }

            anim.SetBool("run", horizontalInput != 0);
            anim.SetBool("grounded", grounded);
        }
    }

    private void Jump()
    {
        if (body.velocity.y < maxJumpHeight)
        {
            body.velocity = new Vector2(body.velocity.x, jumpForce);
            anim.SetTrigger("jump");
            grounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
        if (collision.gameObject.tag == "Lantern")
        {
            RevealObjectWin();
        }
    }

    
    public void RevealObjectWin()
    {
        if (objectToRevealWin != null)
        {
            objectToRevealWin.SetActive(true);  
        }

        if (exitButton != null)
        {
            exitButton.gameObject.SetActive(true);  
            exitButton.onClick.AddListener(LoadNextScene); 
        }
    }

   
    public void RevealObjectDeath()
    {
        if (objectToRevealDeath != null)
        {
            objectToRevealDeath.SetActive(true); 
        }

        if (exitButton != null)
        {
            exitButton.gameObject.SetActive(true);  
            exitButton.onClick.AddListener(LoadNextScene);
        }
    }

  
    public void LoadNextScene()
    {
        //SceneManager.LoadScene("NumeleSceneiTale"); 
    }
}
