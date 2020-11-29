using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishedScript : MonoBehaviour
{
    [SerializeField]
    private string m_NextLevelName;
    private float m_NextLevelTimer = 2f;

    private bool m_LevelFinished;
    private PlatformSoundFX m_SoundFX;
    void Awake()
    {
        m_SoundFX = GetComponent<PlatformSoundFX>();

    }


    void LoadNewLevel()
    {
        SceneManager.LoadScene(m_NextLevelName);
    }

    void OnTriggerEnter(Collider target)
    {
        if (target.CompareTag(TagManager.PLAYER) && !m_LevelFinished)
        {
            m_LevelFinished = true;
            m_SoundFX.PlayAudio(true);

            if (!m_NextLevelName.Equals(""))
            {
                Invoke("LoadNewLevel", m_NextLevelTimer);
            }
        }
    }

}
