using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class DragAndDrop : MonoBehaviour
{
    [Tooltip("Defina aqui quais camadas são consideradas obstáculos para o objeto.")]
    public LayerMask obstacleLayerMask;

    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;
    private bool isDragging = false;
    
    private string tagOriginal; 

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        
        tagOriginal = gameObject.tag; 
    }

    void OnMouseDown()
    {
        isDragging = true;
        rb.bodyType = RigidbodyType2D.Kinematic;

        gameObject.tag = "Untagged"; 
    }

    void OnMouseDrag()
    {
        if (!isDragging) return;

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 targetPosition = mousePosition;
        Vector2 currentPosition = transform.position;
        Vector2 movement = targetPosition - currentPosition;
        float skinWidth = 0.01f;

        RaycastHit2D hit = Physics2D.BoxCast(
            currentPosition, boxCollider.size, 0f, movement.normalized, movement.magnitude, obstacleLayerMask
        );

        if (hit.collider == null)
        {
            transform.position = targetPosition;
        }
        else
        {
            transform.position = (Vector2)transform.position + movement.normalized * (hit.distance - skinWidth);
        }
    }

    void OnMouseUp()
    {
        isDragging = false;
        gameObject.tag = tagOriginal;
        rb.bodyType = RigidbodyType2D.Dynamic;
    }
}