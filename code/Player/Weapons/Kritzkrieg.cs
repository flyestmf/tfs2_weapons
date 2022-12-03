using Sandbox;

namespace TFS2;

[Library( "tf_weapon_kritzkrieg", Title = "Kritzkrieg" )]
public class Kritzkrieg : Medigun
{ 
    public override TFCondition GetChargeType() => TFCondition.CritBoosted;
}