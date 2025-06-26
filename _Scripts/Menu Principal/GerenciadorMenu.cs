using TMPro;
using UnityEngine;

[RequireComponent(typeof(ControladorDeCena))]
public class GerenciadorMenu : MonoBehaviour
{
    [Header("Referências da UI")]
    public TMP_InputField campoNomeJogador;
    public TextMeshProUGUI textoDeAviso;

    private ControladorDeCena controladorDeCena;

    private void Awake()
    {
        controladorDeCena = GetComponent<ControladorDeCena>();
    }

    public void VerificarNomeEIniciar()
    {
        /*
        string nome = campoNomeJogador.text;

        if (!string.IsNullOrWhiteSpace(nome))
        {
            Debug.Log($"Nome do jogador '{nome}' é válido. Iniciando o jogo...");
            PlayerPrefs.SetString("NomeDoJogador", nome);
            PlayerPrefs.Save();

            controladorDeCena.IrParaFase1();
        }
        else
        {   
            Debug.Log("O nome do jogador não pode estar vazio! O jogo não vai iniciar.");

            textoDeAviso.gameObject.SetActive(true);
            yield return new WaitForSeconds(3);
            textoDeAviso.gameObject.SetActive(false);

        }

        */
    }
}