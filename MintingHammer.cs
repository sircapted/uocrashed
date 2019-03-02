using System;

using Server;
using Server.Items;
using Server.Engines.Craft;

namespace Server.Items
{
    [FlipableAttribute(0x13E3, 0x13E4)]
    public class MintingHammer : BaseTool
    {
        public override CraftSystem CraftSystem { get { return DefMinting.CraftSystem; } }

        [Constructable]
        public MintingHammer() : base(0x13E3)
        {
            Name = "Minting Hammer";
            Hue = 1237;
            Weight = 8.0;
            Layer = Layer.OneHanded;
        }

        [Constructable]
        public MintingHammer(int uses) : base(uses, 0x13E3)
        {
            Weight = 8.0;
            Layer = Layer.OneHanded;
        }

        public MintingHammer(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}