using Sandbox;

namespace TFS2;

[Library( "tf_weapon_flaregun", Title = "Flare Gun" )]
public class FlareGun : RocketLauncher
{
    public override void Attack()
    { 
        tf_projectile_rocket_speed = 2000;
        
        //There is no way to override projectile so I have to do it manually.
        if ( !IsServer ) return;
        
        GetProjectileFireSetup( MuzzleOffset, out var origin, out var direction );
        var velocity = direction * tf_projectile_rocket_speed;

        FireProjectile<Flare>( origin, velocity, Data.Damage );
    }
}