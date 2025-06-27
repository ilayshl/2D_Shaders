using UnityEngine;

namespace Leaderboard
{
public class LeaderboardTester : MonoBehaviour
{
    [SerializeField] LeaderboardEntry newEntry;
    private Leaderboard _leaderboard;

        void Start()
        {
            _leaderboard = new Leaderboard();
            _leaderboard.AddEntry(newEntry);

            Debug.Log(Application.persistentDataPath);
        }
    }
}
