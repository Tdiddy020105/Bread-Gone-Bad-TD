using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    public WeaponData currentWeapon;
    public Transform attackAreaParent;
    public Transform attackDirectionIndicator;

    private GameObject currentAttackArea;
    private bool attacking = false;
    private float timeToAttack;
    private float timer = 0f;
    private Vector2 lastDirection = Vector2.zero;

    private InputSystem inputSystem;
    private Transform playerTransform; // Reference to the player's transform
    private PermanentPlayerUpgrades permanentUpgrades = null;

    public InputActionReference attackAction;

    void Start()
    {
        this.permanentUpgrades = this.GetComponent<PermanentPlayerUpgrades>();
        Initialize();
    }

    void Update()
    {
        UpdateAttackDirection();
        RotateAttackArea(); // Call RotateAttackArea() continuously
        CheckAttack();
        UpdateAttackTimer();
    }
/*
    void Initialize()
    {
        inputSystem = GetComponent<InputSystem>();
        InstantiateAttackArea(currentWeapon.attackAreaPrefab);
        timeToAttack = 1f / currentWeapon.attackRate;
    }
*/

    void Initialize()
    {
        inputSystem = GetComponent<InputSystem>();
        playerTransform = transform; // Set playerTransform to the player's transform
        InstantiateAttackArea(currentWeapon.attackAreaPrefab);
        timeToAttack = 1f / currentWeapon.attackRate;
    }

    void UpdateAttackDirection()
    {
        Vector2 moveDirection = inputSystem.move.action.ReadValue<Vector2>();
        if (moveDirection != Vector2.zero)
        {
            lastDirection = moveDirection.normalized;
        }
        attackDirectionIndicator.localPosition = lastDirection;
    }

    void CheckAttack()
    {
        if (attackAction.action.triggered)
        {
            Attack();
        }
    }

    void UpdateAttackTimer()
    {
        if (attacking)
        {
            timer += Time.deltaTime;
            if (timer >= timeToAttack)
            {
                timer = 0;
                attacking = false;
                currentAttackArea.SetActive(false);
            }
        }
    }

    void Attack()
    {
        attacking = true;
        currentAttackArea.SetActive(true);
        RotateAttackArea();
    }
/*
    void RotateAttackArea()
    {
        float angle = Mathf.Atan2(lastDirection.y, lastDirection.x) * Mathf.Rad2Deg;
        currentAttackArea.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        currentAttackArea.transform.position = attackDirectionIndicator.position;
    }
*/

void RotateAttackArea()
{
    float angle = Mathf.Atan2(lastDirection.y, lastDirection.x) * Mathf.Rad2Deg;
    currentAttackArea.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    // Convert the player's position to Vector2 and calculate the attack offset
    Vector2 playerPosition = playerTransform.position;
    Vector2 attackOffset = playerPosition + (lastDirection.normalized * currentWeapon.range);
    
    // Set the position of the attack area
    currentAttackArea.transform.position = attackOffset;
}




    void InstantiateAttackArea(GameObject attackAreaPrefab)
    {
        if (attackAreaPrefab != null)
        {
            if (currentAttackArea != null)
            {
                Destroy(currentAttackArea);
            }

            currentAttackArea = Instantiate(attackAreaPrefab, attackAreaParent);
            currentAttackArea.SetActive(false);
            currentAttackArea.transform.rotation = Quaternion.identity;
        }
        else
        {
            Debug.LogWarning("Attack area prefab is null.");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (attacking && other.CompareTag("MeleeEnemy"))
        {
            int damage = currentWeapon.damage + (this.permanentUpgrades?.GetExtraAttackDamage() ?? 0);
            other.GetComponent<EnemyAI>().TakeDamage(damage);
        }
    }
}

