using UnityEngine;

public class BossRend : MonoBehaviour
{
    private SpriteRenderer rend;

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    public void setFlipX(bool value)
    {
        rend.flipX = value;
    }
}
