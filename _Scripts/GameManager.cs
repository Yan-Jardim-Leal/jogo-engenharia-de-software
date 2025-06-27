using UnityEngine;
using UnityEngine.UI; // Essencial para manipular imagens da UI

public class GameManager : MonoBehaviour
{
    // --- Variáveis para Conectar no Inspector ---

    [Header("Componentes da UI")]
    // Crie um array para arrastar todas as suas imagens de estrela aqui
    public Image[] estrelasUI;
    public Image[] estrelasUIFase;
    // Arraste o painel/menu que aparece quando o jogador ganha
    public GameObject menuDeGanho;

    [Header("Sprites das Estrelas")]
    // Arraste aqui o sprite da estrela vazia
    public Sprite spriteEstrelaVazia;
    // Arraste aqui o sprite da estrela preenchida
    public Sprite spriteEstrelaCheia;


    // --- Controle Interno ---

    // Singleton: uma forma de garantir que existe apenas um GameManager
    // e que ele seja facilmente acessível de outros scripts.
    public static GameManager instance;

    private int pontosAtuais = 0;
    private int pontosParaVencer;

    private void Awake()
    {
        // Configuração do Singleton
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            // Se já existir um, destrói este para não haver duplicatas.
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Define que a quantidade de pontos para vencer é igual à quantidade de estrelas na UI
        pontosParaVencer = 3;

        // Garante que o menu de ganho comece desativado
        if (menuDeGanho != null)
        {
            menuDeGanho.SetActive(false);
        }

        // Inicia todas as estrelas como vazias
        ResetarEstrelas();
    }

    public void ResetarEstrelas()
    {
        for (int i = 0; i < estrelasUI.Length; i++)
        {
            estrelasUI[i].sprite = spriteEstrelaVazia;
        }
    }

    // Função para finalizar a fase
    public void finalizar()
    {
            Debug.Log("VOCÊ VENCEU!");
            // Ativa o menu de vitória
            if (menuDeGanho != null)
            {
                menuDeGanho.SetActive(true);
            }
    }

    // Esta função será chamada pelo script VerificadorDeLixo
    public void AdicionarPonto()
    {
        // Verifica se o jogo já não acabou
        if (pontosAtuais > pontosParaVencer)
        {
            return;
        }

        // Atualiza a imagem da estrela correspondente
        // Se pontosAtuais é 0, atualiza a estrela no índice 0
        if (estrelasUI[pontosAtuais] != null)
        {
            estrelasUI[pontosAtuais].sprite = spriteEstrelaCheia;
        }

        if (estrelasUIFase[pontosAtuais] != null)
        {
            estrelasUIFase[pontosAtuais].sprite = spriteEstrelaCheia;
        }
        
        // Incrementa a pontuação
        pontosAtuais++;

        // Verifica se o jogador venceu
        if (pontosAtuais > pontosParaVencer)
        {
            finalizar();
        }
    }
}