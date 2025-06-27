using System;

[System.Serializable]
public class DadosFase1
{
    public int tempo;
    public int pontuacao;
}

[System.Serializable]
public class DadosFase2
{
    public int tempo;
    public int acertos;
    public int erros;
    public float taxaDeAcerto;
}

[System.Serializable]
public class DadosFase3
{
    public int tempo;
    public int acertos;
    public int erros;
    public float taxaDeAcerto;
}

[System.Serializable]
public class DadosAluno
{
    public int alunoId;
    public string nome;
    public string data;
    public string hora;
    public DadosFase1 fase1;
    public DadosFase2 fase2;
    public DadosFase3 fase3;

    public DadosAluno(int id, string nomeAluno)
    {
        alunoId = id;
        nome = nomeAluno;
        data = DateTime.Now.ToString("dd/MM/yyyy");
        hora = DateTime.Now.ToString("HH:mm");
        
        fase1 = new DadosFase1();
        fase2 = new DadosFase2();
        fase3 = new DadosFase3();
    }
}