using UnityEngine;

public class Ground : MyMonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponentInParent<HeroController>() == null) return;
        collision.GetComponentInParent<HeroController>().heroHitBox.isTrigger = false;
    }
}
