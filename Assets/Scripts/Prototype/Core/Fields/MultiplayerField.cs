using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System;

[RequireComponent(typeof(PhotonView))]
public class MultiplayerField : Field
{
    private PhotonView photonView;

    protected override void Awake()
    {
        base.Awake();
        photonView = GetComponent<PhotonView>();
    }

    public override void SetSelectedUnit(Vector2 coords)
    {
        photonView.RPC(nameof(RPC_OnSetSelectedUnit), RpcTarget.AllBuffered, new object[] { coords });
    }

    [PunRPC]
    private void RPC_OnSetSelectedUnit(Vector2 coords)
    {
        Vector2Int intCoords = new Vector2Int(Mathf.RoundToInt(coords.x), Mathf.RoundToInt(coords.y));
        OnSetSelectedUnit(intCoords);
    }

    public override void SelectedUnitMoved(Vector2 coords)
    {
        photonView.RPC(nameof(RPC_OnSelectedUnitMoved), RpcTarget.AllBuffered, new object[] { coords });
    }

    [PunRPC]
    private void RPC_OnSelectedUnitMoved(Vector2 coords)
    {
        Vector2Int intCoords = new Vector2Int(Mathf.RoundToInt(coords.x), Mathf.RoundToInt(coords.y));
        OnSelectedUnitMove(intCoords);
    }

    public override void SelectedUnitAttacked(Vector2 coords)
    {
        photonView.RPC(nameof(RPC_OnSelectedUnitAttacked), RpcTarget.AllBuffered, new object[] { coords });
    }

    [PunRPC]
    private void RPC_OnSelectedUnitAttacked(Vector2 coords)
    {
        Vector2Int intCoords = new Vector2Int(Mathf.RoundToInt(coords.x), Mathf.RoundToInt(coords.y));
        OnSelectedUnitAttack(intCoords);
    }

    public override void EndTurn()
    {
        photonView.RPC(nameof(RPC_EndTurn), RpcTarget.AllBuffered, new object[] { });
    }

    [PunRPC]
    private void RPC_EndTurn()
    {
        gameController.EndTurn();
    }
}
