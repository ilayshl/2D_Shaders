using System.Collections;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private float deathTimer;
    //[SerializeField] private Sprite[] targetSprite;
    [SerializeField] private Material dissolveMaterial;
    [SerializeField] private AudioClip sound;
    [SerializeField] private ItemData correspondingItem;
    public ItemData item {get => correspondingItem;}


    private SpriteRenderer sr;
    private Rigidbody2D rb;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        //sr.sprite = targetSprite[Random.Range(0, targetSprite.Length)];
        transform.localScale*=Randomize(0.7f, 1.2f);
        rb.AddForce(SetVelocity(), ForceMode2D.Impulse);
        rb.AddTorque(Randomize(-1, 1), ForceMode2D.Impulse);
    }

    private float Randomize(float min, float max)
    {
        return Random.Range(min, max);
    }

    private Vector2 SetVelocity()
    {
        float randomY = Randomize(11, 14);
        if(transform.position.x > 0)
        {
            return new Vector2(-Randomize(3, 6), randomY);
        }else if(transform.position.x < 0)
        {
            return new Vector2(Randomize(3, 6), randomY);
        }else
        {
            return new Vector2(Randomize(-3, 6), randomY);
        }
    }

    public void OnHit()
    {
        sr.material = dissolveMaterial;
        sr.material.SetFloat("_Visibility", 1);
        GetComponent<Collider2D>().enabled = false;
        StartCoroutine(OnDeath(deathTimer));
    }

    private IEnumerator OnDeath(float timeAmount)
    {
        sr.material.SetFloat("_Noise_Scale", Random.Range(15, 20));
        float timePassed = 0;
        while(timeAmount > timePassed)
        {
            float currentTime = Mathf.Clamp01(timePassed / timeAmount);
            float visibility = Mathf.Lerp(1, 0, currentTime);
            sr.material.SetFloat("_Visibility", visibility);
            timePassed += Time.deltaTime;
            rb.drag += Time.deltaTime * 10;
            transform.localScale *= 0.999f;
            yield return null;
        }
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
