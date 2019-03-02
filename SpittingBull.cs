using System;

using Server;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Engines.Quests;
using Server.Engines.Quests.Collector;
using Server.Network;

using Server.Targeting;

using System.Collections.Generic;

namespace Server.Mobiles
{
	[CorpseName("a burning bull corpse")]
	public class SpittingBull : BaseCreature
	{


		[Constructable]
		public SpittingBull()
			: this("a burning bull")
		{
		}

		private static Type[] m_AnimateDeadTypes = new Type[]
		{
			typeof( SkeletalMount )
		};

		[Constructable]
		public SpittingBull(string name)
			: base(AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4)
		{
			Name = "a spitting bull";
			Body = Utility.RandomList(0xE8, 0xE9);
			BaseSoundID = 0x64;
                	Hue = Utility.RandomList(0x901,0x5AC,0x5A3,0x59A,0x591,0x588,0x57F);


			SetStr(126, 155);
			SetDex(166, 185);
			SetInt(101, 125);

			SetSkill(SkillName.Wrestling, 100, 135);
			SetSkill(SkillName.Magery, 70, 85);
			

            		SetHits(201, 220);

            		SetDamage(20, 24);

			Fame = 10000;
			Karma = 10000;

			VirtualArmor = 60;

			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 80;

			
			//possible random rares
			if (0.5 > Utility.RandomDouble())
                		AddItem(new MonsterStatuette());
			if (Utility.RandomDouble() < .50)
                		PackItem(Engines.Plants.Seed.RandomBonsaiSeed());
			if (Utility.RandomDouble() < .50)
				PackItem(new StoneStatueDeed());
	    		else if (0.3 > Utility.RandomDouble())
                		AddItem(new BraceletOfHealth());
		}

		public void PackMagicItems(int minLevel, int maxLevel, double armorChance, double weaponChance)
        	{
            		if (!PackArmor(minLevel, maxLevel, armorChance))
                		PackWeapon(minLevel, maxLevel, weaponChance);
        	}
		
        	public void PackMagicItems(int minLevel, int maxLevel)
        	{
            		PackMagicItems(minLevel, maxLevel, 0.30, 0.15);
        	}



		//possible loot
		public override double TreasureMapChance { get { return TreasureMap.LootChance; } }
		public override int TreasureMapLevel { get { return 3; } }
		public override bool GivesMLMinorArtifact { get { return true; } }
		public override void GenerateLoot()
        	{
            		AddLoot(LootPack.Rich);
            		AddLoot(LootPack.Gems);
        	}
			
                


		//if cut by sharp objesct
		public override int Meat { get { return 8; } }
		public override int Hides { get { return 12; } }
		
		




		//bulls nature
		public override PackInstinct PackInstinct { get { return PackInstinct.Bull; } }
		public override FoodType FavoriteFood { get { return FoodType.FruitsAndVegies | FoodType.GrainsAndHay; } }




        public override void DoHarmful(Mobile target, bool indirect)
        {
            base.DoHarmful(target, indirect);

            if (target == this )
                return;

            List<AggressorInfo> list = this.Aggressors;

            for (int i = 0; i < list.Count; ++i)
            {
                AggressorInfo ai = list[i];

                if (ai.Attacker == target)
                    return;
            }

            list = this.Aggressed;

            for (int i = 0; i < list.Count; ++i)
            {
                AggressorInfo ai = list[i];

                if (ai.Defender == target)
                {
                    return;
                }
            }
        }	







		//optional defense
		//aura
		public virtual bool HasAura { get { return false; } }
		//if has item on aggressor
		public virtual TimeSpan AuraInterval { get { return TimeSpan.FromSeconds(5); } }
        public virtual int AuraRange { get { return 4; } }
		public virtual int AuraBaseDamage { get { return 5; } }
        	


		//breathe animation
		[CommandProperty(AccessLevel.GameMaster)]
		public override bool HasBreath { get { return false; } } // fire breath enabled
		//if has item on aggressor
		
		


		
			
		
		
		public virtual int BreathEffectSound { get { return 0x227; } }
		public virtual int BreathAngerSound { get { return GetAngerSound(); } }

		public virtual double BreathEffectDelay { get { return 1.3; } }
		
		public virtual int BreathComputeDamage()
        	{
            		int damage = (int)(Hits * BreathDamageScalar);

            		if (IsParagon)
                		damage = (int)(damage / Paragon.HitsBuff);

            		if (damage > 200)
                		damage = 200;

            		return damage;
		}







		// serialization name 
		public SpittingBull(Serial serial)
            		: base(serial)
		{
		}

        	public override void Serialize(GenericWriter writer)
		{	
			base.Serialize(writer);
			writer.Write((int)0);
			
			
            		
			

				
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
			
		}
	}
}