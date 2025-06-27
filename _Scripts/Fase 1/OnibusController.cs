using UnityEngine;

public class OnibusController : MonoBehaviour
{
    public SpriteRenderer[] pessoaOnibus;
    public GameManager gameManager;

    private int passageiro;

    private int pontosEstrela;
    private int pontosAtuais;

    void Awake()
    {   
        pontosEstrela = 0;
        pontosAtuais = 0;
        passageiro = 0;
        Debug.Log("OnibusControllerIniciado");
    }

    public void mostrarPassageiro()
    {
        if (passageiro < pessoaOnibus.Length)
        {
            pessoaOnibus[passageiro].enabled = true;
            passageiro++;
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {   
        Debug.Log("Tag do objeto:");
        Debug.Log(other.gameObject.tag);
        Debug.Log("Tag minha:");
        Debug.Log(this.gameObject.tag);


        if (other.CompareTag(this.gameObject.tag))
        {   
            Destroy(other.gameObject);
            mostrarPassageiro();

            pontosEstrela++;
            pontosAtuais++;

            if (pontosEstrela > 1)
            {
                pontosEstrela = 0;
                gameManager.AdicionarPonto();
            }

            if (pontosAtuais > 5)
            {
                gameManager.finalizar();
            }
        }
    }
}
