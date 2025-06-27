using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Leaderboard
{
public class Leaderboard
{
    public List<LeaderboardEntry> scoreboard {get; private set;} = new();

        void Start()
        {
            
        }

        public void AddEntry(LeaderboardEntry entry)
        {
            if(ExistsInLeaderboard(entry)) { return; }
            scoreboard.Add(entry);

            PlayerPrefs.SetString("Last_User_Added", entry.Name);
            LogLeaderboard();
        }

        public void LogLeaderboard()
        {
            Debug.Log("Sorted leaderboard: ");
            foreach (var entry in SortByScore())
            {
                int i = 1;
                Debug.Log($"{i}. {entry.Name}: {entry.Score}");
                i++;
            }
        }

        private bool ExistsInLeaderboard(LeaderboardEntry entry)
        {
            foreach(var item in scoreboard)
            {
                if(item.Name == entry.Name)
                {
                    return true;
                }
            }
                return false;
        }

        private List<LeaderboardEntry> SortByScore()
        {
            return scoreboard.OrderByDescending(item => item.Score).ToList();
        }

    }
}