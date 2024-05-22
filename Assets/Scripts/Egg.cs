using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    private Score score;
    private Lives lives;
    private Bank bank;
    private EggSpawner eggSpawner;
    private NestControl nestControl;
    [SerializeField] int scoreAdd = 1;
    [SerializeField] int livesSub = 1;
    [SerializeField] float eggSpeedAdd = 0.1f;
    [SerializeField] int coinsAdd = 1;
    //[SerializeField] float eggSpeed;
    [SerializeField] bool eggSwitch;
    [SerializeField] bool goldenEggSwitch;
    [SerializeField] bool featherSwitch;
    [SerializeField] bool eggRainSwitch;

    private void Start()
    {
        score = GameObject.Find("SceneManager").GetComponent<Score>();
        lives = GameObject.Find("SceneManager").GetComponent<Lives>();
        bank = GameObject.Find("SceneManager").GetComponent<Bank>();
        eggSpawner = GameObject.Find("Egg Spawner").GetComponent<EggSpawner>();
        nestControl = GameObject.Find("Nest").GetComponent<NestControl>();
        if (eggSpawner.addRainTag == true)
        {
            gameObject.tag = "Rain";
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            if (eggSwitch && gameObject.tag != "Rain")
            {
                lives.LivesCount(livesSub);
                //eggSpawner.EggSpeed(-1f);
            }
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Nest")
        {
            if (eggSwitch)
            {
                eggSpawner.EggSpeed(eggSpeedAdd);
                score.EggScore(scoreAdd);
            }
            else if (goldenEggSwitch)
            {
                bank.CoinsScore(coinsAdd);
            }
            else if (featherSwitch)
            {
                nestControl.FeatherSwitch(true);
                Debug.Log("Удар пера");
            }
            else if (eggRainSwitch)
            {
                eggSpawner.isRain = true;
            }
            //Debug.Log("Egg was triggered");
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * eggSpawner.eggSpeed);
    }
}
