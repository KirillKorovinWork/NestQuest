using UnityEngine;

public class Feather : FallingObject
{
    protected override void OnNestHit()
    {
        FindObjectOfType<NestControl>().FeatherSwitch(true);
        base.OnNestHit();
    }
}
