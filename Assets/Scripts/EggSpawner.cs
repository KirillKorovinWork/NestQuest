using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EggSpawner : MonoBehaviour
{
    public NestControl nestControl;
    public GameObject[] egg;
    public Lives lives;
    public float eggSpeed = 0.1f;
    public float changeRainTimer = 2;
    float currentTime;
    public bool isRain;
    public bool addRainTag = false;
    [SerializeField] float eggSpawnRate = 5f;

    private void Start()
    {
        StartCoroutine(SpawnTarget());
        currentTime = changeRainTimer;
    }
    public void Update()
    {
        SpawnRateUpdate();
    }
    public void SpawnRateUpdate() 
    {
        if (isRain == true)
        {
            addRainTag = true;
            eggSpawnRate = 0.5f;
            currentTime -= Time.deltaTime;
            Debug.Log(currentTime);
            if (currentTime <= 0)
            {
                currentTime = changeRainTimer;
                eggSpawnRate = 5f;
                isRain = false;
                addRainTag = false;
            }
        }
    }
    public IEnumerator SpawnTarget() 
    {
        
        while (!lives.gameOver) 
        {
            
            int bonusRandom = Random.Range(4, 10);
            for (int i = 1; i <= bonusRandom; i++)
            {
                var position = new Vector3(Random.Range(nestControl.nestLeftBound, nestControl.nestRightBound), 1.3f, -0.159f);
                yield return new WaitForSeconds(eggSpawnRate);
                Instantiate(egg[0], position, Quaternion.identity);
                //Debug.Log(i);
            }
            int differentRandom = Random.Range(2, 4);
            var pos = new Vector3(Random.Range(nestControl.nestLeftBound, nestControl.nestRightBound), 1.3f, -0.159f);
            yield return new WaitForSeconds(eggSpawnRate);
            Instantiate(egg[differentRandom], pos, Quaternion.identity);
        }
    }
    public void EggSpeed(float speed) 
    {
        eggSpeed = eggSpeed + speed;
        //if(speed == -1) 
        //{
        //    eggSpeed = 0.1f;
        //}
        //else 
        //{
        //    eggSpeed = eggSpeed + speed;
        //}
    }
    
}
