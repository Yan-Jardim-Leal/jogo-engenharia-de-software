using UnityEngine;

// Lembre-se: este script requer que seus objetos "Pessoa" tenham os componentes
// Rigidbody2D e BoxCollider2D, e que eles existam no mundo 2D (não como elementos de UI em um Canvas).
[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class PessoaController : MonoBehaviour
{
    [Tooltip("Defina aqui quais camadas são consideradas obstáculos para o objeto.")]
    public LayerMask obstacleLayerMask;

    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;
    private bool isDragging = false;
    
    private string tagOriginal; 
    private Vector3 startPosition; // Variável para guardar a posição inicial

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        tagOriginal = gameObject.tag; 
    }

    void OnMouseDown()
    {
        // Guarda a posição inicial no momento do clique
        startPosition = transform.position; 
        
        isDragging = true;
        rb.bodyType = RigidbodyType2D.Kinematic; // Evita que a física afete o objeto enquanto arrastado
        //gameObject.tag = "Untagged"; // Muda a tag temporariamente se necessário
    }

    void OnMouseDrag()
    {
        if (!isDragging) return;

        // Converte a posição do mouse na tela para uma posição no mundo do jogo
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 targetPosition = mousePosition;
        Vector2 currentPosition = transform.position;
        Vector2 movement = targetPosition - currentPosition;
        float skinWidth = 0.01f; // Uma pequena margem para evitar ficar preso dentro de colisores

        // Usa BoxCast para prever a colisão antes de mover o objeto
        RaycastHit2D hit = Physics2D.BoxCast(
            currentPosition, boxCollider.size, 0f, movement.normalized, movement.magnitude, obstacleLayerMask
        );

        // Se não houver colisão no caminho, move diretamente para a posição do mouse
        if (hit.collider == null)
        {
            transform.position = targetPosition;
        }
        else
        {
            // Se houver colisão, move o objeto apenas até o ponto de colisão
            transform.position = (Vector2)transform.position + movement.normalized * (hit.distance - skinWidth);
        }
    }

    void OnMouseUp()
    {
        isDragging = false;
        gameObject.tag = tagOriginal;
        rb.bodyType = RigidbodyType2D.Dynamic;
        
        // Retorna o objeto para a posição inicial guardada
        transform.position = startPosition; 
    }
}
