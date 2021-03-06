
using System.Collections.Generic;
using UnityEngine;

public enum characterType {
    BlackDrone = 0,
    BlackWarrior = 1,
    RedDrone = 2,
    RedWarrior = 3,
    Queen = 4
}

public abstract class Characters : MonoBehaviour {

    public int team;
    protected int currentX;
    protected int currentY;
    public characterType type;
    protected int health;
    protected int AttackPower;
    protected int defense;
    public bool HasAttcked;
    public bool HasKilled;
    protected Vector2Int Destination;
    protected List<Vector2Int> moves = new List<Vector2Int>();
    public Vector3 targetPosition;
  

    public void Update() {
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 10);
    
    }

    public virtual void SetPosition(Vector3 position, bool force= false) {

        targetPosition = position;
        if (force) {
            transform.position = targetPosition;
        }

    }

  

    public abstract bool ValidMove(Characters[,] board, int x1, int y1, int x2, int y2, Characters c);
    public abstract void attack(Characters opponent, Characters player);
    public abstract void SetAttributes();
    public abstract List<Vector2Int> setMoves(int x, int y);

    public abstract int GetX();
    public abstract int GetY();
    public abstract void SetX(int x);
    public abstract void SetY(int y);
    public abstract int GetHealth();

    public abstract int GetAttack();

    public abstract void HealthLoss(int h);

    public abstract int GetDefense();

}
