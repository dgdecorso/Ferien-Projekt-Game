
using UnityEngine;
using System.Reflection;

public class GameAssets : MonoBehaviour {
    
    private static GameAssets _i;

    public static GameAssets i {
        get {
            if (_i == null) _i = Instantiate(Resources.Load<GameAssets>("GameAssets"));
            return _i;
        }
    }

    private void Awake() {
        _i = this;
    }




    public Sprite s_ShootFlash;
    
    public Transform pfSwordSlash;
    public Transform pfEnemy;
    public Transform pfEnemyFlyingBody;
    public Transform pfImpactEffect;
    public Transform pfDamagePopup;
    public Transform pfDashEffect;
    public Transform pfProjectileArrow;
    public Transform pfBolt;
    public Transform pfSmoke;
    public Transform pfChatBubble;

    public Material m_WeaponTracer;
    public Material m_MarineSpriteSheet;

    public Material m_DoorRed;
    public Material m_DoorGreen;
    public Material m_DoorBlue;

    public Material m_DoorKeyHoleRed;
    public Material m_DoorKeyHoleGreen;
    public Material m_DoorKeyHoleBlue;



    public static class UnitAnimTypeEnum {

    



    }
    
    }