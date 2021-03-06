using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleplayerGameController : GameController
{
    protected override void SetGameState(GameState state)
    {
        this.state = state;
    }

    public override void TryToStartCurrentGame()
    {
        SetGameState(GameState.Play);
        SetCameraActive(true);
        UpdateCameraOnTeamChange(activePlayer);
    }

    public override bool CanPerformAction()
    {
        if (!IsGameInProgess())
            return false;
        return true;
    }

    protected override void ChangeActiveTeam()
    {
        base.ChangeActiveTeam();
        //DelayGameOnTeamChange();
        UpdateCameraOnTeamChange(activePlayer);
    }
}
