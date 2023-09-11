using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityMaster : MonoBehaviour
{
    //These are set on creation
    public GameObject PlayerCharacter;
    public AbilityStats Stat;
    [HideInInspector] public HUDManager HUDManager;
    [HideInInspector] public int AbilitySlotIndex;

    [HideInInspector] public bool CanActivate;

    private float CooldownTimer = 0.0f;
    public bool OnCooldown = false;
    

    public Sprite AbilityIcon;
    public bool UsesCooldown;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Activate()
    {
        Debug.Log("Ability Activated");
    }

    public virtual IEnumerator StartCooldown(int Cooldown)
    {
        CooldownTimer = 0.0f;
        OnCooldown = true;
        UpdateIconHUD();

        while (CooldownTimer < Cooldown)
        {
            CooldownTimer += Time.deltaTime;
            float t = Mathf.Clamp01(CooldownTimer / Cooldown);
            yield return null;
        }

        OnCooldown = false;
        UpdateIconHUD();
    }

    public virtual bool CheckCanActivate()
    {
        CanActivate = true;
        return CanActivate; //This is placeholder and should be overwritten in the ability script
    }

    public virtual void UpdateIconHUD()
    {
        HUDManager.UpdateAbilityIcon(this);
    }
}
