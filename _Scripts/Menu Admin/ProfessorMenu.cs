using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI; 

public class AdminPanelManager : MonoBehaviour
{
    public TextAsset alunosJson;
    private AlunoList listaDeAlunos = new AlunoList(); 

    [Header("Grupos de Canvas")]
    public CanvasGroup backgroundCanvasGroup;
    [SerializeField] public CanvasGroup alunosContentCanvasGroup;
    [SerializeField] public CanvasGroup dadosContentCanvasGroup;
    [SerializeField] public CanvasGroup alunosEmptyCanvasGroup;
    [SerializeField] public CanvasGroup dadosEmptyCanvasGroup;

    [Header("Prefabs e Containers")]
    [Tooltip("O objeto 'Content' do seu ScrollView da lista de alunos")]
    [SerializeField] private Transform containerAlunoContent;
    [Tooltip("O prefab do botão que representa um aluno na lista")]
    [SerializeField] private GameObject prefabItemAluno;
    [Tooltip("O objeto 'Content' do seu ScrollView da lista de alunos")]
    [SerializeField] private Transform containerDadosContent;
    [Tooltip("O prefab do botão que representa um aluno na lista")]
    [SerializeField] private GameObject prefabDadosAluno;

    [Serializable]
    public class Fase1
    {
        public int tempo;
        public int pontuacao;
        public int taxaDeAcerto;
    }

    [Serializable]
    public class Fase2
    {
        public int tempo;
        public int acertos;
        public int erros;
        public int taxaDeAcerto;
    }

    [Serializable]
    public class Fase3
    {
        public int tempo;
        public int acertos;
        public int erros;
        public int taxaDeAcerto;
    }

    [Serializable]
    public class Aluno
    {
        public int alunoId;
        public string nome;
        public string data;
        public string hora;
        public Fase1 fase1;
        public Fase2 fase2;
        public Fase3 fase3;
    }

    [Serializable]
    public class AlunoList
    {
        public Aluno[] alunos;
    }


    void Start()
    {
        if (alunosEmptyCanvasGroup != null)
        {
            alunosEmptyCanvasGroup.alpha = 0f;
            alunosEmptyCanvasGroup.interactable = false;
            alunosEmptyCanvasGroup.blocksRaycasts = false;
        }

        CarregarDados();
        ShowAdminMenu();
    }

    private void CarregarDados()
    {
       if (alunosJson != null)
       {
            listaDeAlunos = JsonUtility.FromJson<AlunoList>(alunosJson.text);
       }
    }

    public void ShowAdminMenu()
    {
        if (listaDeAlunos != null && listaDeAlunos.alunos.Length > 0)
        {
            alunosContentCanvasGroup.alpha = 1f;
            alunosContentCanvasGroup.interactable = true;
            alunosContentCanvasGroup.blocksRaycasts = true;

            alunosEmptyCanvasGroup.alpha = 0f;
            alunosEmptyCanvasGroup.interactable = false;
            alunosEmptyCanvasGroup.blocksRaycasts = false;

            foreach (Transform child in containerAlunoContent)
            {
                Destroy(child.gameObject);
            }

            foreach (Aluno aluno in listaDeAlunos.alunos)
            {
                Debug.Log("Processando aluno: " + aluno.nome);
                InstanciarBotaoAluno(aluno);
            }
        }
        else 
        {
            alunosContentCanvasGroup.alpha = 0f;
            alunosContentCanvasGroup.interactable = false;
            alunosContentCanvasGroup.blocksRaycasts = false;

            alunosEmptyCanvasGroup.alpha = 1f;
            alunosEmptyCanvasGroup.interactable = true;
            alunosEmptyCanvasGroup.blocksRaycasts = true;
        }

        dadosContentCanvasGroup.alpha = 0f;
        dadosContentCanvasGroup.interactable = false;
        dadosContentCanvasGroup.blocksRaycasts = false;
    }

    private void InstanciarBotaoAluno(Aluno aluno)
    { 
        GameObject botaoAluno = Instantiate(prefabItemAluno, containerAlunoContent);

        TextMeshProUGUI textoNome = botaoAluno.transform.Find("Text Aluno").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI textoData = botaoAluno.transform.Find("Text Data").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI textoHora = botaoAluno.transform.Find("Text Hora").GetComponent<TextMeshProUGUI>();

        textoNome.text = aluno.nome;
        textoData.text = aluno.data;
        textoHora.text = aluno.hora;

        Button botao = botaoAluno.GetComponent<Button>();
        if (botao != null)
        {
            botao.onClick.RemoveAllListeners();
            botao.onClick.AddListener(() => ExibirDadosDoAluno(aluno));
        }
    }
    private void ExibirDadosDoAluno(Aluno aluno)
    {
        foreach (Transform child in containerDadosContent)
        {
            Destroy(child.gameObject);
        }

        dadosEmptyCanvasGroup.alpha = 0f;
        dadosEmptyCanvasGroup.interactable = true;
        dadosEmptyCanvasGroup.blocksRaycasts = true;

        dadosContentCanvasGroup.alpha = 1f;
        dadosContentCanvasGroup.interactable = true;
        dadosContentCanvasGroup.blocksRaycasts = true;

        GameObject dadosAlunoObj = Instantiate(prefabDadosAluno, containerDadosContent);

        PainelDadosUI painelUI = dadosAlunoObj.GetComponent<PainelDadosUI>();

        if (painelUI != null)
        {
            // Fase 1
            painelUI.fase1TextoTempo.text = $"Tempo: {aluno.fase1.tempo}s";
            painelUI.fase1TextoPontuacao.text = $"Pontuação: {aluno.fase1.pontuacao}";
            painelUI.fase1TaxaDeAcerto.text = $"Taxa de acerto: {aluno.fase1.taxaDeAcerto}%";

            // Fase 2
            painelUI.fase2TextoTempo.text = $"Tempo: {aluno.fase2.tempo}s";
            painelUI.fase2TextoAcertos.text = $"Acertos: {aluno.fase2.acertos}";
            painelUI.fase2TextoErros.text = $"Erros: {aluno.fase2.erros}";
            painelUI.fase2TextoTaxaDeAcerto.text = $"Taxa de acerto: {aluno.fase2.taxaDeAcerto}%";

            // Fase 3
            painelUI.fase3TextoTempo.text = $"Tempo: {aluno.fase3.tempo}s";
            painelUI.fase3TextoAcertos.text = $"Acertos: {aluno.fase3.acertos}";
            painelUI.fase3TextoErros.text = $"Erros: {aluno.fase3.erros}";
            painelUI.fase3TextoTaxaDeAcerto.text = $"Taxa de acerto: {aluno.fase3.taxaDeAcerto}%";
        }
    }
}