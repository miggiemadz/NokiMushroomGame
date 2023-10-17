using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyMoveable
{
    Rigidbody2D rb { get; set; }
    bool isFacingRight { get; set; }
    Vector3 direction { get; set; }
    Vector3 previousPosition { get; set; }
    void MoveEnemy(Vector2 velocity);
    void CheckForLeftOrRightFacing(Vector2 velocity);
}
