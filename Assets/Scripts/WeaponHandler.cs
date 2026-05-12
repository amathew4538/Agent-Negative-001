using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponHandler : MonoBehaviour
{
    [Header("Input Actions")]
    public InputAction ShootAction;
    [Header("References")]
    public Sprite weapon;
    public SpriteRenderer spriteRenderer;
    public PlayerHandController handController;
    public PlayerController playerController;
    public GameObject gunExplosionPrefab;

    [Header("Info")]
     public string weaponSpriteName;
    public string weaponName;
    public Vector2 handleLocation;
    public Vector2 barrelLocation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (weapon != null)
        {
            spriteRenderer.sprite = weapon;

            weaponSpriteName = weapon.name;
            weaponName = weaponSpriteName.Substring(0, weaponSpriteName.LastIndexOf("_"));

            WeaponInfo info = Resources.Load<WeaponInfo>(weaponName);

            if (info != null)
            {
                handleLocation = info.handlePos;
                barrelLocation = info.barrelPos;
            }
            else
            {
                Debug.LogWarning($"Weapon {weaponName} not found in Resources!");
                handleLocation = Vector2.zero;
                barrelLocation = Vector2.zero;
            }

            transform.localPosition = handleLocation;
        }
    }

    // Update is called once per frame
    public void Update()
    {
        bool handRightOfPlayer = handController.transform.position.x > playerController.transform.position.x;

        float side = handRightOfPlayer ? 1f : -1f;
        transform.localScale = new Vector3(side, side, 1);

        transform.localPosition = side * handleLocation;

        if (ShootAction.WasPressedThisFrame())
        {
            if (gunExplosionPrefab != null)
            {
                GameObject explosion = Instantiate(gunExplosionPrefab, transform.position, transform.rotation);

                explosion.transform.SetParent(this.transform);

                explosion.transform.localPosition = new Vector3(barrelLocation.x + 0.08f, barrelLocation.y, 0);
        
                explosion.transform.localScale = Vector3.one;
            }
        }
    }

    /// <summary>
    /// Changes the weapon the player is holding
    /// </summary>
    /// <param name="newWeapon">The weapon to switch to</param>
    public void ChangeWeapon(Sprite newWeapon)
    {
        weapon = newWeapon;
        spriteRenderer.sprite = weapon;
    }

    public void OnEnable()
    {
        ShootAction.Enable();
    }

    public void OnDisable()
    {
        ShootAction.Disable();
    }
}
