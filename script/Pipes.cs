using UnityEngine;

public class Pipes : MonoBehaviour
{
    public float gerak = 5f;
    private float batasKiri;

    private void Start()
    {
        batasKiri = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 4f;
    }
    private void Update()
    {
        transform.position += Vector3.left * gerak * Time.deltaTime;

        if (transform.position.x < batasKiri)
        {
            Destroy(gameObject);
        }
    }
}
