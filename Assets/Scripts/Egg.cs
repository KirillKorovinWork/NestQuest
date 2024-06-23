using UnityEngine;

public class Egg : FallingObject
{
    [SerializeField] float eggSpeedAdd = 0.1f;
    [SerializeField] int scoreAdd = 1;
    [SerializeField] int livesSub = 1;
    protected override void OnGroundHit()
    {
        if (gameObject.tag != "Rain")
        {
            FindObjectOfType<Lives>().LivesCount(livesSub);
        }
        base.OnGroundHit();
    }
    protected override void OnNestHit()
    {
        FindObjectOfType<EggSpawner>().EggSpeed(eggSpeedAdd);
        FindObjectOfType<Score>().GameScore(scoreAdd);
        base.OnNestHit();
    }
}
