using UnityEngine;

public class GoldenEgg : FallingObject 
{
    [SerializeField] int coinScoreAdd = 1;
    protected override void OnNestHit()
    {
        FindObjectOfType<Bank>().CoinsScore(coinScoreAdd);
        base.OnNestHit();
    }
}
