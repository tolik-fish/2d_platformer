using System.Collections.Generic;
using UnityEngine;

public class SnakeAI : MonoBehaviour 
{
    [SerializeField] private List<Transform> _patrolPoints;

    private Vector2 _target;
}