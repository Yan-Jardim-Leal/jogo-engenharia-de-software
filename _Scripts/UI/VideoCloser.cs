using UnityEngine;
using UnityEngine.Video; // Essencial para acessar o VideoPlayer

// Garante que este script só pode ser anexado a um objeto que já tenha um VideoPlayer.
[RequireComponent(typeof(VideoPlayer))]
public class AutoDestruirVideo : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    // Awake é chamado antes de Start. Ideal para pegar referências.
    void Awake()
    {
        // Pega a referência do componente VideoPlayer que está no mesmo GameObject.
        videoPlayer = GetComponent<VideoPlayer>();
    }

    // OnEnable é chamado quando o objeto se torna ativo.
    // É o lugar ideal para "assinar" eventos.
    void OnEnable()
    {
        // Assina o evento: "Quando o loopPointReached acontecer, chame a função OnVideoFinished".
        videoPlayer.loopPointReached += OnVideoFinished;
    }

    // OnDisable é chamado quando o objeto é desativado.
    // É CRUCIAL "desassinar" o evento para evitar erros e vazamentos de memória.
    void OnDisable()
    {
        // Desassina o evento.
        videoPlayer.loopPointReached -= OnVideoFinished;
    }

    // Esta função será chamada automaticamente pelo evento.
    // O parâmetro "vp" é o próprio VideoPlayer que disparou o evento.
    void OnVideoFinished(VideoPlayer vp)
    {
        // O comando para destruir o GameObject em que este script está.
        Destroy(gameObject);
        Debug.Log("Vídeo terminou e o objeto foi DESTRUÍDO.");
    }
}
