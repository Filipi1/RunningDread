using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerControl : MonoBehaviour
{
    Rigidbody2D rb2d;
    Animator PlayerAnim;
    CapsuleCollider2D PCollider2D;

    public GameObject SpecialTrail;
    public GameObject SpecialText;
    public TextMeshProUGUI TimerSpecial;

    public float PlayerSpeed, newTimer;
    bool FacingRight, isDown, isDead;
    public bool isGrounded, SecuryJump = true, isSpecial;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        PlayerAnim = GetComponent<Animator>();
        PCollider2D = GetComponent<CapsuleCollider2D>();
    }

    void Update() {
        Move();

        if (isGrounded && SecuryJump)
            Jump();

        if (isDead) {
            GameManager.NewInstance.PlayerDeaths++;
            SceneManager.LoadScene(0);
        }

        if(isSpecial)
            StartSpecialTimer();
    }

    private void Move() {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        rb2d.velocity = new Vector2(moveX * PlayerSpeed, rb2d.velocity.y);

        if (moveX != 0) {
            if (moveX > 0 && FacingRight)
                Flip();
            else if (moveX < 0 && !FacingRight)
                Flip();

            PlayerAnim.SetBool("isRunning", true);
        }
        else {
            PlayerAnim.SetBool("isRunning", false);
        }

        if ((Input.GetAxis("Vertical") < 0) && isGrounded) {
            PlayerAnim.SetBool("isDown", true);
            PCollider2D.size = new Vector2(PCollider2D.size.x, 0.2f);
            PCollider2D.offset = new Vector2(PCollider2D.offset.x, -0.24f);
        }

        if ((Input.GetAxis("Vertical") >= 0) && !isDown) {
            PlayerAnim.SetBool("isDown", false);
            PCollider2D.size = new Vector2(PCollider2D.size.x, 0.437f);
            PCollider2D.offset = new Vector2(PCollider2D.offset.x, -0.11f);
        }

        if ((Input.GetAxis("Jump")) != 0) {
            if (!isSpecial)
                StartCoroutine(SpecialActive());
        }
    }

    IEnumerator JumperSystem()
    {
        isGrounded = false;
        rb2d.AddForce(Vector2.up * 150);
        yield return new WaitForSeconds(0.6f);
        SecuryJump = true;
    }

    IEnumerator SpecialActive() {
        isSpecial = true;
        SpecialTrail.SetActive(true);
        SpecialText.SetActive(true);
        yield return new WaitForSeconds(2);
        SpecialTrail.SetActive(false);
        SpecialText.SetActive(false);
        isSpecial = false;
        newTimer = 0;
    }

    private void Jump() {
        if ((Input.GetAxis("Jump2") != 0))  {
            SecuryJump = false;
            StartCoroutine(JumperSystem());
        }
    }

    private void Flip() {
        FacingRight = !FacingRight;

        Vector3 pScale = transform.localScale;
        pScale.x *= -1;
        transform.localScale = pScale;
    }

    private void StartSpecialTimer() {
        newTimer += Time.deltaTime;
        TimerSpecial.text = newTimer.ToString("f1");
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (rb2d.IsTouching(collision) && SecuryJump) { 
            isGrounded = true;
        }

        if (collision.CompareTag("Trampolim")) { 
            rb2d.AddForce(Vector2.up * 300);
        }

        if (collision.CompareTag("Dowing")) {
            isDown = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.CompareTag("Danger") && !isSpecial) {
            isDead = true;
        }

        isGrounded = true;
    }

    private void OnTriggerExit2D(Collider2D collision) {
        isDown = false;
    }
}
