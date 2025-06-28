using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GeneratePlayers : MonoBehaviour
{
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

    void Awake()
    {
        GerarArquivoJson();
    }

    public void GerarArquivoJson()
    {
        List<Aluno> listaDeAlunos = new List<Aluno>();

        for (int i = 0; i < 5; i++)
        {
            Aluno novoAluno = new Aluno
            {
                alunoId = i + 1,
                nome = $"Aluno Exemplo {i + 1}",
                data = System.DateTime.Now.ToString("dd/MM/yyyy"),
                hora = System.DateTime.Now.ToString("HH:mm"),
                fase1 = new Fase1
                {                    
                    tempo = UnityEngine.Random.Range(90, 300),
                    pontuacao = UnityEngine.Random.Range(20, 100),
                    taxaDeAcerto = UnityEngine.Random.Range(40, 100)
                },
                fase2 = new Fase2
                {
                    tempo = UnityEngine.Random.Range(60, 240),
                    acertos = UnityEngine.Random.Range(1, 10),
                    erros = UnityEngine.Random.Range(0, 5),
                    taxaDeAcerto = UnityEngine.Random.Range(30, 100)
                },
                fase3 = new Fase3
                {
                    tempo = UnityEngine.Random.Range(50, 180),
                    acertos = UnityEngine.Random.Range(1, 10),
                    erros = UnityEngine.Random.Range(0, 3),
                    taxaDeAcerto = UnityEngine.Random.Range(50, 100)
                }
            };

            listaDeAlunos.Add(novoAluno);
        }

        AlunoList container = new AlunoList();
        container.alunos = listaDeAlunos.ToArray(); 

        string jsonData = JsonUtility.ToJson(container, true);

        string path = Path.Combine(Application.persistentDataPath, "listaAlunos.json");
        try
        {
            File.WriteAllText(path, jsonData);
            Debug.Log("Arquivo JSON de alunos gerado com sucesso em: {path}");
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Falha ao salvar o ficheiro JSON: {e.Message}");
        }
    }
}
