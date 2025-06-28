using UnityEngine;
using UnityEngine.SceneManagement; // É obrigatório incluir esta linha para gerenciar cenas!

public class ControladorDeCena : MonoBehaviour
{
    /// <summary>
    /// Esta função recarrega a cena que está atualmente ativa.
    /// Ela deve ser chamada pelo evento OnClick() de um botão na UI.
    /// </summary>
    public void ReiniciarCena()
    {
        Debug.Log("Clicou em reiniciar!");
        // Pega o índice da cena atual que está carregada
        int indiceDaCenaAtual = SceneManager.GetActiveScene().buildIndex;

        // Manda o SceneManager carregar a cena usando o índice que pegamos
        SceneManager.LoadScene(indiceDaCenaAtual);

        Debug.Log("A cena foi reiniciada!");
    }

    public void IrParaFase1()
    {
        // IMPORTANTE: O nome "Fase1" deve ser EXATAMENTE igual ao nome do seu arquivo de cena.
        SceneManager.LoadScene("_Scenes/Fase 1");
    }

    public void IrParaFase2()
    {
        // Exemplo: seu arquivo de cena pode se chamar "Level_2" ou "Fase 2"
        SceneManager.LoadScene("_Scenes/Fase 2");
    }

    public void IrParaFase3()
    {
        SceneManager.LoadScene("_Scenes/Fase 3");
    }

    public void IrParaMenu()
    {
        SceneManager.LoadScene("_Scenes/Menu Inicial");
    }

    public void IrParaMenuProfessor()
    {
        SceneManager.LoadScene("_Scenes/Menu Professor");
    }
}