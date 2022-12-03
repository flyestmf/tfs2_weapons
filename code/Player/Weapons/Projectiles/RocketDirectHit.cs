using Sandbox;

namespace TFS2;

partial class RocketDirectHit : Rocket
{
    public override float Radius => 44f;
    public override string ExplosionSoundEffect => "weapon_directhit.explosion";
    
    public override void Explode( TraceResult trace )
    {
        // Mini critical airborne.
        // TODO: Only mini critical if airborne from blast force.
        if (Enemy is TFPlayer { IsInAir: true })
        {
            DamageFlags |= TFDamageFlags.MiniCritical;
        }

        base.Explode(trace);
    }
}