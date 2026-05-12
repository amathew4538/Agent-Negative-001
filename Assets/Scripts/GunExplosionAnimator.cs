using UnityEngine;
using System.Collections;

public class GunExplosionAnimator : MonoBehaviour
{
    public Sprite[] frames;
    public float framesPerSecond = 12f;
    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        StartCoroutine(PlayAnimation());
    }

    IEnumerator PlayAnimation()
    {
        float waitTime = 1f / framesPerSecond;

        for (int i = 0; i < frames.Length; i++)
        {
            sr.sprite = frames[i];
            yield return new WaitForSeconds(waitTime);
        }

        Destroy(gameObject);
    }
}
