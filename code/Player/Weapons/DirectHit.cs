using Sandbox;

namespace TFS2;

[Library( "tf_weapon_directhit", Title = "Direct Hit" )]
public class DirectHit : RocketLauncher
{
    public override void Attack()
    {
        tf_projectile_rocket_speed = 1980;
        
        // This is where I would do base.Attack(), except there is no way to override projectile.
        if ( !IsServer ) return;
        
        GetProjectileFireSetup( MuzzleOffset, out var origin, out var direction );
        var velocity = direction * tf_projectile_rocket_speed;

        FireProjectile<RocketDirectHit>( origin, velocity, Data.Damage );
    }
}