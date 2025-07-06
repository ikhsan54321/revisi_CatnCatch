using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Kucing : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Text teksPoin;
    private int poin = 0;
    public int nyawa = 3;

    private Rigidbody2D rb;
    public Animator animator;
    private SpriteRenderer spriteRenderer;

    private float moveInput;

    public GameController gameController;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Auto assign GameController kalau lupa assign di Inspector
        if (gameController == null)
        {
            gameController = FindObjectOfType<GameController>();
        }

        if (teksPoin != null)
            teksPoin.text = "Poin: " + poin;
    }

    void Update()
    {
        moveInput = 0;

        if (Keyboard.current.aKey.isPressed)
            moveInput = -1;
        else if (Keyboard.current.dKey.isPressed)
            moveInput = 1;

        animator.SetBool("Lari", moveInput != 0);
        spriteRenderer.flipX = moveInput > 0;

        // Cek nyawa dan panggil Game Over
        if (nyawa <= 0)
        {
            if (gameController != null)
            {
                gameController.GameOver();
            }
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
    }

    public void TambahPoin()
    {
        poin++;
        if (teksPoin != null)
            teksPoin.text = "Poin: " + poin;
    }

    public void KurangiNyawa()
    {
        nyawa--;
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ikan"))
        {
            TambahPoin();               // Tambah poin
            Destroy(other.gameObject);  // Hapus ikan dari scene
        }
    }
}
