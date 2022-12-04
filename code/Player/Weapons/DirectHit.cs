using Sandbox;

namespace TFS2;

[Library( "tf_weapon_directhit", Title = "Direct Hit" )]
public class DirectHit : RocketLauncher
{
    public override void Attack()
    {
        //There is no way to override projectile so I have to do it manually.
        if ( !IsServer ) return;
        
        GetProjectileFireSetup( MuzzleOffset, out var origin, out var direction );
        var velocity = direction * 1980;
        
        FireProjectile<RocketDirectHit>( origin, velocity, Data.Damage );
    }
}