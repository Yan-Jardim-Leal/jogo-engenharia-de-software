using UnityEngine;

public class VerificadorDeLixo : MonoBehaviour
{   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(this.gameObject.tag))
        {
            Destroy(other.gameObject);
            GameManager.instance.AdicionarPonto();
        }
        else
        {
            if (!other.CompareTag("Untagged"))
            {
                Debug.Log("Lixo no lugar errado!");
            }
        }
    }
}
