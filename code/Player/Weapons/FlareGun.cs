using Sandbox;

namespace TFS2;

[Library( "tf_weapon_flaregun", Title = "Flare Gun" )]
public class FlareGun : RocketLauncher
{
    public override void Attack()
    {
        //There is no way to override projectile so I have to do it manually.
        if ( !IsServer ) return;
        
        GetProjectileFireSetup( MuzzleOffset, out var origin, out var direction );
        var velocity = direction * 2000;

        FireProjectile<Flare>( origin, velocity, Data.Damage );
    }
}