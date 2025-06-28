using UnityEngine;
using System.IO;

public class GerenciadorDeDados : MonoBehaviour
{

    public static GerenciadorDeDados Instance { get; private set; }
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);
    }

    public DadosAluno alunoAtual;

    public void IniciarNovaSessao(int id, string nome)
    {
        alunoAtual = new DadosAluno(id, nome);

        Debug.Log($"Sessão iniciada para o aluno: {alunoAtual.nome} (ID: {alunoAtual.alunoId})");
    }

    public void SalvarDadosEmJSON()
    {
        if (alunoAtual == null)
        {
            Debug.LogError("Não há dados de aluno para salvar!");
            return;
        }

        Debug.Log("Função SalvarDadosEmJSON foi chamada. Implemente a lógica de salvamento aqui.");
        
    }
}