using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Player : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int Index = 0;
    private Vector3 arah;
    public float gravitasi = -9.81f;
    public float berat = 5f;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        arah = Vector3.zero;
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            arah = Vector3.up * berat;
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                arah = Vector3.up * berat;
            }
        }
        arah.y += gravitasi * Time.deltaTime;
        transform.position += arah * Time.deltaTime;
    }

    private void AnimateSprite()
    {
        Index++;
        if (Index >= sprites.Length)
        {
            Index = 0;
        }
        spriteRenderer.sprite = sprites[Index];
    }

    private void OnTriggerEnter2D(Collider2D objek)
    {
        if (objek.CompareTag("rintangan") || objek.CompareTag("tanah"))
        {
            FindAnyObjectByType<GameManager>().GameOver();
        }
        else if (objek.CompareTag("Poin"))
        {
            FindAnyObjectByType<GameManager>().IncreaseScore();
        }
    }
}
