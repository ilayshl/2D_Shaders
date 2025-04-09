using UnityEngine;

public class Destroyer : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Target target)){
            Destroy(collision.gameObject);
        }
    }
}
