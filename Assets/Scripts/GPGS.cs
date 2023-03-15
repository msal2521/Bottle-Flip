using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.UI;

public class GPGS : MonoBehaviour
{
    /*FOR ERRORS "GPGSIds.leaderboard_leader" REPLACE WITH YOUR LEADERBOARD OR ACHIEVEMENT*/

    [SerializeField] private bool autoSignIn;

    public static GPGS instance;
    public int localScore;

    void Awake()
    {
        instance = new GPGS();
        //If we don't currently have a GameManager...
        if (instance == null)
            //...set this one to be it...
            instance = this;
        //...otherwise...
        else if (instance != this)
            //...destroy this one because it is a duplicate.
            Destroy(gameObject);

    }
    private void Start()
    {
        InitializePlayGames();

        if (Application.internetReachability != NetworkReachability.NotReachable && autoSignIn)
        {
            SignIn();
        }
    }


    private void InitializePlayGames()
    {
        var configuration = new PlayGamesClientConfiguration.Builder().RequestServerAuthCode(false).Build(); // remove ".EnableSavedGames()" if not required.
        PlayGamesPlatform.InitializeInstance(configuration);

        PlayGamesPlatform.Activate();
    }


    #region SIGNIN
    public void SignIn()
    {

        PlayGamesPlatform.Instance.Authenticate(SignInInteractivity.CanPromptOnce, (result) => {

            if (result == SignInStatus.Success)
            {
                Debug.Log("LOGGED IN");
            }
            else
            {
                Debug.Log("UNABLE TO LOG IN");
            }

        });

        //PlayGamesPlatform.Instance.LoadScores(GPGSIds.leaderboard_highest_level, LeaderboardStart.PlayerCentered, 1, LeaderboardCollection.Public, LeaderboardTimeSpan.AllTime, data =>
        //{

        //    localScore = int.Parse(data.PlayerScore.formattedValue);
        //});
    }


    public void SignOut()
    {

        ((PlayGamesPlatform)Social.Active).SignOut();
    }
    #endregion SIGNOUT


    #region LEEADERBOARD START
    public void ShowLeaderboard()
    {

        ((PlayGamesPlatform)Social.Active).ShowLeaderboardUI(GPGSIds.leaderboard_highest_level);
    }

    public void AddScoreToLeaderboard()
    {

        Social.ReportScore(localScore, GPGSIds.leaderboard_highest_level, success => { });
    }
    #endregion LEADERBOARD END



    #region ACHIEVEMENT START
    /*public void ShowAchievements() {

        Social.ShowAchievementsUI();
    }

    public void IncrementAchievements() {

        ((PlayGamesPlatform)Social.Active).IncrementAchievement(GPGSIds.achievement_score_5_point, incrementData, succss =>{});
    }
    public void UnlockAchievement() {

        ((PlayGamesPlatform)Social.Active).UnlockAchievement(GPGSIds.achievement_score_20);
    }*/
    #endregion ACHIVEMENT END
}
