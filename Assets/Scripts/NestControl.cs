using UnityEngine;

public class NestControl : MonoBehaviour
{
    public ParticleSystem featherParticle;
    public Lives lives;
    public float nestLeftBound = -0.6f;
    public float nestRightBound = 0.4f;
    public float nestSpeed = 0.5f;
    public float featherTimer = 16;
    private float currentTime;
    public bool startTimer;

    void Update()
    {
        NestInBound();
        UpdateTimer();
    }
    //Here is nest control methods
    void NestInBound() 
    {
        if (transform.position.x > nestRightBound) 
        {
            transform.position = new Vector3(nestRightBound, transform.position.y, transform.position.z);
        }
        else if(transform.position.x < nestLeftBound) 
        {
            transform.position = new Vector3(nestLeftBound, transform.position.y, transform.position.z);
        }
    }
    public void MoveLeft()
    {
        if (!lives.gameOver)
        {
            Vector3 xPos = Vector3.left;
            transform.position += xPos * nestSpeed * Time.deltaTime;
        }
    }

    public void MoveRight()
    {
        if (!lives.gameOver)
        {
            Vector3 xPos = Vector3.right;
            transform.position += xPos * nestSpeed * Time.deltaTime;
        }
    }

    //Here is methods which change nest speed
    //This change go from Egg
    public void UpdateTimer() 
    {
        if (startTimer == true)
        {
            if (currentTime > 0)
            {
                currentTime -= Time.deltaTime;
            }
            else
            {
                featherParticle.Stop();
                startTimer = false;
                nestSpeed = 0.8f;
            }
        }
    }
    public void FeatherSwitch(bool isFeather)
    {
        if (isFeather == true)
        {
            featherParticle.Play();
            startTimer = true;
            currentTime = featherTimer;
            nestSpeed = 2;
        }
    }
}







































































































