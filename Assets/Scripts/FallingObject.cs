using UnityEngine;

public abstract class FallingObject : MonoBehaviour
{
    protected EggSpawner eggSpawner;

    protected virtual void Start()
    {
        // Убедись, что eggSpawner назначен в инспекторе или через код
        if (eggSpawner == null)
        {
            eggSpawner = FindObjectOfType<EggSpawner>();
        }
        if (eggSpawner.addRainTag == true)
        {
            gameObject.tag = "Rain";
        }
    }

    private void Update()
    {
        MoveDown();
    }

    protected void MoveDown()
    {
        transform.Translate(Vector3.down * Time.deltaTime * eggSpawner.eggSpeed);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            OnGroundHit();
        }
        else if (collision.gameObject.tag == "Nest")
        {
            OnNestHit();
        }
    }

    protected virtual void OnGroundHit()
    {
        Destroy(gameObject);
    }

    protected virtual void OnNestHit()
    {
        Destroy(gameObject);
    }
}
