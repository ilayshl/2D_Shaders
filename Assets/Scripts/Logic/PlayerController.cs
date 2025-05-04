using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Inventory inventoryManager;
    [SerializeField] LayerMask targetLayer;
    Vector2 mousePosition;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        MoveTowards();
        CheckIfFiring();
        
    }

    private void MoveTowards()
    {
        transform.position = mousePosition;
    }

    private void CheckIfFiring()
    {
        if(Input.GetMouseButtonDown(0))
        {
            CheckIfHit();
        }
    }

    private void CheckIfHit()
    {
        Collider2D hitObject = Physics2D.OverlapPoint(mousePosition, targetLayer);
        if(hitObject != null)
        {
            if(hitObject.TryGetComponent(out Target target))
            {
                target.OnHit();
                inventoryManager.AddItem(target.item);
            }
        }
    }
}
