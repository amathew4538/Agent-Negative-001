using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    [Header("References")]
    public Sprite weapon;
    public SpriteRenderer spriteRenderer;
    public PlayerHandController handController;
    public PlayerController playerController;

    [Header("Info")]
    public Vector2 handleLocation;
    public string weaponSpriteName;
    public string weaponName;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (weapon != null)
        {
            spriteRenderer.sprite = weapon;

            weaponSpriteName = weapon.name;
            weaponName = weaponSpriteName.Substring(0, weaponSpriteName.LastIndexOf("_"));

            if (References.Weapons.HandleOffset.TryGetValue(weaponName, out Vector2 foundPos))
            {
                handleLocation = foundPos;
            }
            else
            {
                Debug.LogWarning($"Weapon {weaponName} not found in References!");
                handleLocation = Vector2.zero;
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
}
