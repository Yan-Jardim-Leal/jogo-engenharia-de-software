using TMPro;
using UnityEngine;

// Este script serve apenas para guardar as referências dos campos de texto
// do seu prefab de detalhes.
public class PainelDadosUI : MonoBehaviour
{
    [Header("Referências dos Textos da Fase 1")]
    public TextMeshProUGUI fase1TextoTempo;
    public TextMeshProUGUI fase1TextoPontuacao;
    public TextMeshProUGUI fase1TaxaDeAcerto;

    [Header("Referências dos Textos da Fase 2")]
    public TextMeshProUGUI fase2TextoTempo;
    public TextMeshProUGUI fase2TextoAcertos;
    public TextMeshProUGUI fase2TextoErros;
    public TextMeshProUGUI fase2TextoTaxaDeAcerto;

    [Header("Referências dos Textos da Fase 3")]
    public TextMeshProUGUI fase3TextoTempo;
    public TextMeshProUGUI fase3TextoAcertos;
    public TextMeshProUGUI fase3TextoErros;
    public TextMeshProUGUI fase3TextoTaxaDeAcerto;
}
