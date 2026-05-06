using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] private AudioSource mouseClick;
    [SerializeField] private AudioSource enemyExplosionClip;
    [SerializeField] private AudioSource meteorExplosionClip;
    [SerializeField] private AudioSource playerExplosionClip;
    private void Awake()
    {
        Instance = this;
    }

    public void PlayMouseClick()
    {
        mouseClick.Play();
    }

    public void PlayEnemyExplosion()
    {
        enemyExplosionClip.Play();
    }

    public void PlayMeteorExplosion()
    {
        meteorExplosionClip.Play();
    }

    public void PlayPlayerExplosion()
    {
        playerExplosionClip.Play();
    }
}
