using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance = null;

    [Header("Configuração de Áudio")]
    [Tooltip("O clipe de áudio para tocar.")]
    public AudioClip backgroundMusic;

    // NOVO: Variável pública para controlar o volume
    [Range(0f, 1f)] // Restringe o valor entre 0 (mudo) e 1 (volume máximo)
    [Tooltip("Volume da música de fundo (0.0 = mudo, 1.0 = máximo).")]
    public float musicVolume = 0.5f; // Valor padrão de 50%

    private AudioSource audioSource;

    void Awake()
    {
        // === IMPLEMENTAÇÃO DO SINGLETON (Para garantir a persistência) ===
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        // === CONFIGURAÇÃO E INÍCIO DA MÚSICA ===

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // CONFIGURAÇÃO DO VOLUME AQUI!
        audioSource.volume = musicVolume;

        // Configurações restantes
        audioSource.clip = backgroundMusic;
        audioSource.loop = true;
        audioSource.playOnAwake = false;

        // Começa a tocar a música
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    // NOVO: Método para alterar o volume em tempo de execução
    public void SetVolume(float newVolume)
    {
        musicVolume = newVolume;
        if (audioSource != null)
        {
            audioSource.volume = musicVolume;
        }
    }

    // ... (Opcional: Adicione a função Update para aplicar mudanças do Inspector em tempo real no Editor)
    private void Update()
    {
        if (audioSource != null && audioSource.volume != musicVolume)
        {
            audioSource.volume = musicVolume;
        }
    }
}