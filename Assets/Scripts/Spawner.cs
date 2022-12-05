using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Bot _bot;

    private void Awake()
    {
        int botsCount = Random.Range(0, 100);

        for (int i = 0; i < botsCount; i++)
        {
            Bot bot = Instantiate(_bot, transform);

            bot.gameObject.SetActive(true);
        }
    }
}
