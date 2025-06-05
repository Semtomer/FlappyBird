using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 direction;

    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float strength = 5f;
    [SerializeField] private GameManager gameManager;

    private void OnEnable()
    {
        transform.position = Vector3.zero;
        direction = Vector3.zero;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            direction = Vector3.up * strength;
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                direction = Vector3.up * strength;   
            }
        }

        direction.y += gravity * Time.deltaTime;

        transform.position += direction * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            gameManager.GameOver();
        }
        else if (collision.gameObject.tag == "Scoring")
        {
            gameManager.IncreaseScore();
        }
    }
}
