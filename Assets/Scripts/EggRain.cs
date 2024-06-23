using UnityEngine;

public class EggRain : FallingObject
{
    protected override void OnNestHit()
    {
        FindObjectOfType<EggSpawner>().isRain = true;
        base.OnNestHit();
    }
}
