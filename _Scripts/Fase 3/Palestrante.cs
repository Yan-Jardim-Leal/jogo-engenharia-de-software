using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI; // Mantido para outros possíveis usos, mas não mais para o palestrante

public class Palestrante : MonoBehaviour
{
    [System.Serializable]
    public struct Palavra
    {
        public string texto;
        public bool ehPositiva;
    }

    public GameManager gameManager;

    [Header("Configurações das Frases")]
    public Palavra[] palavrasDeAcao = new Palavra[]
    {
        // Ações que se aplicam a conceitos positivos
        new Palavra { texto = "Aumentar", ehPositiva = true },
        new Palavra { texto = "Incentivar", ehPositiva = true },
        new Palavra { texto = "Promover", ehPositiva = true },

        // Ações que se aplicam a conceitos negativos
        new Palavra { texto = "Reduzir", ehPositiva = false },
        new Palavra { texto = "Diminuir", ehPositiva = false },
        new Palavra { texto = "Combater", ehPositiva = false }
    };

    public Palavra[] palavrasDeContexto = new Palavra[]
    {
        // Conceitos positivos (que devem ser combinados com ações positivas)
        new Palavra { texto = "a Reciclagem de Materiais", ehPositiva = true },
        new Palavra { texto = "o Descarte Correto do Lixo", ehPositiva = true },
        new Palavra { texto = "o Uso de Transporte Público", ehPositiva = true },

        // Conceitos negativos (que devem ser combinados com ações negativas)
        new Palavra { texto = "a Poluição do Ar", ehPositiva = false },
        new Palavra { texto = "o Congestionamento Urbano", ehPositiva = false },
        new Palavra { texto = "o Uso de Carros Individuais", ehPositiva = false }
    };

    [Header("Referências da UI")]
    public TextMeshProUGUI textoDaFrase;

    // --- MUDANÇA PRINCIPAL AQUI ---
    [Header("Sprite do Palestrante")]
    // A variável agora é do tipo SpriteRenderer
    public SpriteRenderer palestranteRenderer; 
    public Sprite[] spritesPositivos;
    public Sprite[] spritesNegativos;

    [Header("Controle de Jogo e Tempo")]
    public int numeroTotalDeFrases = 6;
    public float tempoParaResponder = 15f;
    public float intervaloEntreFrases = 3f;

    private bool contextoAtual;
    private string frase;
    private bool respostaRecebida;
    private bool votoFoiCorreto;

    void Start()
    {
        Debug.Log("Palestrante iniciado");
        IniciarPalestra();
    }

    public void Votar(bool votoDoJogador)
    {
        if (respostaRecebida) return;
        
        respostaRecebida = true;

        if (votoDoJogador == contextoAtual)
        {
            votoFoiCorreto = true;
            if (gameManager != null) gameManager.AdicionarPonto();
        }
        else
        {
            votoFoiCorreto = false;
        }
    }

    private void AtualizarTexto(string novoTexto)
    {
        if (textoDaFrase != null)
        {
            textoDaFrase.text = novoTexto;
        }
    }
    
    private void GerarFrase()
    {
        Palavra acaoEscolhida = palavrasDeAcao[Random.Range(0, palavrasDeAcao.Length)];
        Palavra contextoEscolhido = palavrasDeContexto[Random.Range(0, palavrasDeContexto.Length)];

        frase = acaoEscolhida.texto + " " + contextoEscolhido.texto;
        contextoAtual = (acaoEscolhida.ehPositiva == contextoEscolhido.ehPositiva);

        Debug.Log("Frase Gerada: '" + frase + "' | Contexto esperado: " + (contextoAtual ? "Positivo" : "Negativo"));

        AtualizarImagemPalestrante();
    }

    private void AtualizarImagemPalestrante()
    {
        // A lógica agora usa a variável 'palestranteRenderer'
        if (palestranteRenderer == null) return;

        if (contextoAtual)
        {
            if (spritesPositivos != null && spritesPositivos.Length > 0)
            {
                int indiceSorteado = Random.Range(0, spritesPositivos.Length);
                palestranteRenderer.sprite = spritesPositivos[indiceSorteado];
            }
        }
        else
        {
            if (spritesNegativos != null && spritesNegativos.Length > 0)
            {
                int indiceSorteado = Random.Range(0, spritesNegativos.Length);
                palestranteRenderer.sprite = spritesNegativos[indiceSorteado];
            }
        }
    }

    private void IniciarPalestra()
    {
        StartCoroutine(CicloDaPalestra());
    }

    private IEnumerator CicloDaPalestra()
    {
        int frasesRespondidas = 0;
        
        while (frasesRespondidas < numeroTotalDeFrases)
        { 
            frasesRespondidas++;
            respostaRecebida = false;
            
            GerarFrase();
            AtualizarTexto(frase);

            float timer = 0f;
            while (timer < tempoParaResponder && !respostaRecebida)
            {
                timer += Time.deltaTime;
                yield return null; 
            }

            if (respostaRecebida)
            {
                AtualizarTexto(votoFoiCorreto ? "Isso aí!" : "Hmm, não é bem isso...");
                yield return new WaitForSeconds(3f); 
            }
            else
            {
                AtualizarTexto("Tempo esgotado! Próxima pergunta...");
                yield return new WaitForSeconds(intervaloEntreFrases);
            }
        }

        Debug.Log("Fim da palestra! Verificando resultado...");
        gameManager.finalizar();
    }
}