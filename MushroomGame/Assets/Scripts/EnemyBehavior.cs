using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class NewBehaviourScript : MonoBehaviour
{
    [Header("Damage")]
    public int enemyDamageCount;
    public float damageTimer;
    private bool hasAttacked = false;
    [SerializeField] private SpriteBlink damageFlash;
    [SerializeField] private GameObject Noki;
    [SerializeField] private GameUI UI;

    [Header("Pathfinding")]
    [SerializeField] public Transform target;
    public float activateDistance;
    public float pathUpdateSeconds;

    [Header("Physics")]
    [SerializeField] public Transform feetPosition;
    public float groundCheckRadius;
    [SerializeField] public LayerMask groundLayer;
    public float speed;
    public float nextWaypointDistance;
    public float jumpNodeHeightRequirement;
    public float jumpModifier;

    [Header("Custom Behavior")]
    public bool followEnabled;
    public bool jumpEnabled;
    public bool directionLookEnabled;

    private bool isFacingRight;
    [SerializeField] private Path path;
    private int currentWaypoint = 0;

    [SerializeField] Seeker seeker;
    [SerializeField] Rigidbody2D rb;

    public void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, pathUpdateSeconds);
    }

    private IEnumerator DamageTaken()
    {
        yield return new WaitForSeconds(2);
        hasAttacked = false;
    }

    private void FixedUpdate()
    {
        if (TargetInDistance() && followEnabled)
        {
            PathFollow();
        }
    }

    private void UpdatePath()
    {
        if (followEnabled && TargetInDistance() && seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
    }

    private void PathFollow()
    {
        if (path == null)
        {
            return;
        }

        //reached end of path
        if (currentWaypoint >= path.vectorPath.Count)
        {
            return;
        }

        // Direction Calculation
        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        // Jump 
        if (jumpEnabled && isGrounded())
        {
            if (direction.y > jumpNodeHeightRequirement)
            {
                rb.AddForce(Vector2.up * speed * jumpModifier);
            }
        }

        // Movement
        rb.AddForce(force);

        //Next Waypoint
        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

        // Direction Graphics Handling
        if (directionLookEnabled)
        {
            if (isFacingRight && rb.velocity.x > 0.05f)
            {
                Vector3 rotator = new Vector3(transform.rotation.x, 0f, transform.rotation.z);
                transform.rotation = Quaternion.Euler(rotator);
                isFacingRight = !isFacingRight;
            }
            else if (!isFacingRight && rb.velocity.x < -0.05f)
            {
                Vector3 rotator = new Vector3(transform.rotation.x, 180f, transform.rotation.z);
                transform.rotation = Quaternion.Euler(rotator);
                isFacingRight = !isFacingRight;
            }
        }
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(feetPosition.position, groundCheckRadius, groundLayer);
    }

    private bool TargetInDistance()
    {
        return Vector2.Distance(transform.position, target.transform.position) < activateDistance;
    }

    private void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0; ;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !hasAttacked)
        {
            hasAttacked = true;
            damageFlash.Flash();
            UI.ManageHealth(-1);
            StartCoroutine(DamageTaken());
        }
    }
}
