using Amper.FPS;
using Sandbox;

namespace TFS2;

public partial class Flare : Rocket
{
	
	public override float Radius => 0f;
	public override string ExplosionSoundEffect => "weapon_flaregun.explosion";
	public override string ExplosionParticleName => "particles/flamethrower/flaregun_destroyed.vpcf";
	public override void Spawn()
	{
		base.Spawn();
		SetModel( "models/weapons/w_models/w_flaregun_shell.vmdl" );
		DamageFlags |= TFDamageFlags.Ignite;
		DamageFlags |= TFDamageFlags.DoNotGib;
	}
	public override void OnTraceTouch( Entity other, TraceResult trace )
	{
		if ( other == null )
			return;

		if (Owner.IsValid())
		{
			if (other is TFPlayer enemy && enemy.InCondition(TFCondition.Burning))
			{
				DamageFlags |= TFDamageFlags.Critical;
			}
			var info = CreateDamageInfo().UsingTraceResult(trace);
			other.TakeDamage( info );
		}
		Explode( other, trace );
	}

	public override string TrailParticleName => $"particles/rockettrail/flaregun_trail_{Team.GetName()}.vpcf";
	public override string CriticalTrailParticleName => $"particles/rockettrail/flaregun_trail_crit_{Team.GetName()}.vpcf";
}
