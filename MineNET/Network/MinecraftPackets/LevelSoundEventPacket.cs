﻿using MineNET.Values;

namespace MineNET.Network.MinecraftPackets
{
    public class LevelSoundEventPacket : MinecraftPacket
    {
        public const int SOUND_ITEM_USE_ON = 0;
        public const int SOUND_HIT = 1;
        public const int SOUND_STEP = 2;
        public const int SOUND_FLY = 3;
        public const int SOUND_JUMP = 4;
        public const int SOUND_BREAK = 5;
        public const int SOUND_PLACE = 6;
        public const int SOUND_HEAVY_STEP = 7;
        public const int SOUND_GALLOP = 8;
        public const int SOUND_FALL = 9;
        public const int SOUND_AMBIENT = 10;
        public const int SOUND_AMBIENT_BABY = 11;
        public const int SOUND_AMBIENT_IN_WATER = 12;
        public const int SOUND_BREATHE = 13;
        public const int SOUND_DEATH = 14;
        public const int SOUND_DEATH_IN_WATER = 15;
        public const int SOUND_DEATH_TO_ZOMBIE = 16;
        public const int SOUND_HURT = 17;
        public const int SOUND_HURT_IN_WATER = 18;
        public const int SOUND_MAD = 19;
        public const int SOUND_BOOST = 20;
        public const int SOUND_BOW = 21;
        public const int SOUND_SQUISH_BIG = 22;
        public const int SOUND_SQUISH_SMALL = 23;
        public const int SOUND_FALL_BIG = 24;
        public const int SOUND_FALL_SMALL = 25;
        public const int SOUND_SPLASH = 26;
        public const int SOUND_FIZZ = 27;
        public const int SOUND_FLAP = 28;
        public const int SOUND_SWIM = 29;
        public const int SOUND_DRINK = 30;
        public const int SOUND_EAT = 31;
        public const int SOUND_TAKEOFF = 32;
        public const int SOUND_SHAKE = 33;
        public const int SOUND_PLOP = 34;
        public const int SOUND_LAND = 35;
        public const int SOUND_SADDLE = 36;
        public const int SOUND_ARMOR = 37;
        public const int SOUND_MOB_ARMOR_STAND_PLACE = 38;
        public const int SOUND_ADD_CHEST = 39;
        public const int SOUND_THROW = 40;
        public const int SOUND_ATTACK = 41;
        public const int SOUND_ATTACK_NODAMAGE = 42;
        public const int SOUND_ATTACK_STRONG = 43;
        public const int SOUND_WARN = 44;
        public const int SOUND_SHEAR = 45;
        public const int SOUND_MILK = 46;
        public const int SOUND_THUNDER = 47;
        public const int SOUND_EXPLODE = 48;
        public const int SOUND_FIRE = 49;
        public const int SOUND_IGNITE = 50;
        public const int SOUND_FUSE = 51;
        public const int SOUND_STARE = 52;
        public const int SOUND_SPAWN = 53;
        public const int SOUND_SHOOT = 54;
        public const int SOUND_BREAK_BLOCK = 55;
        public const int SOUND_LAUNCH = 56;
        public const int SOUND_BLAST = 57;
        public const int SOUND_LARGE_BLAST = 58;
        public const int SOUND_TWINKLE = 59;
        public const int SOUND_REMEDY = 60;
        public const int SOUND_UNFECT = 61;
        public const int SOUND_LEVELUP = 62;
        public const int SOUND_BOW_HIT = 63;
        public const int SOUND_BULLET_HIT = 64;
        public const int SOUND_EXTINGUISH_FIRE = 65;
        public const int SOUND_ITEM_FIZZ = 66;
        public const int SOUND_CHEST_OPEN = 67;
        public const int SOUND_CHEST_CLOSED = 68;
        public const int SOUND_SHULKERBOX_OPEN = 69;
        public const int SOUND_SHULKERBOX_CLOSED = 70;
        public const int SOUND_ENDERCHEST_OPEN = 71;
        public const int SOUND_ENDERCHEST_CLOSED = 72;
        public const int SOUND_POWER_ON = 73;
        public const int SOUND_POWER_OFF = 74;
        public const int SOUND_ATTACH = 75;
        public const int SOUND_DETACH = 76;
        public const int SOUND_DENY = 77;
        public const int SOUND_TRIPOD = 78;
        public const int SOUND_POP = 79;
        public const int SOUND_DROP_SLOT = 80;
        public const int SOUND_NOTE = 81;
        public const int SOUND_THORNS = 82;
        public const int SOUND_PISTON_IN = 83;
        public const int SOUND_PISTON_OUT = 84;
        public const int SOUND_PORTAL = 85;
        public const int SOUND_WATER = 86;
        public const int SOUND_LAVA_POP = 87;
        public const int SOUND_LAVA = 88;
        public const int SOUND_BURP = 89;
        public const int SOUND_BUCKET_FILL_WATER = 90;
        public const int SOUND_BUCKET_FILL_LAVA = 91;
        public const int SOUND_BUCKET_EMPTY_WATER = 92;
        public const int SOUND_BUCKET_EMPTY_LAVA = 93;
        public const int SOUND_ARMOR_EQUIP_CHAIN = 94;
        public const int SOUND_ARMOR_EQUIP_DIAMOND = 95;
        public const int SOUND_ARMOR_EQUIP_GENERIC = 96;
        public const int SOUND_ARMOR_EQUIP_GOLD = 97;
        public const int SOUND_ARMOR_EQUIP_IRON = 98;
        public const int SOUND_ARMOR_EQUIP_LEATHER = 99;
        public const int SOUND_ARMOR_EQUIP_ELYTRA = 100;
        public const int SOUND_RECORD_13 = 101;
        public const int SOUND_RECORD_CAT = 102;
        public const int SOUND_RECORD_BLOCKS = 103;
        public const int SOUND_RECORD_CHIRP = 104;
        public const int SOUND_RECORD_FAR = 105;
        public const int SOUND_RECORD_MALL = 106;
        public const int SOUND_RECORD_MELLOHI = 107;
        public const int SOUND_RECORD_STAL = 108;
        public const int SOUND_RECORD_STRAD = 109;
        public const int SOUND_RECORD_WARD = 110;
        public const int SOUND_RECORD_11 = 111;
        public const int SOUND_RECORD_WAIT = 112;
        public const int SOUND_STOP_RECORD = 113; //Not really a sound
        public const int SOUND_FLOP = 114;
        public const int SOUND_ELDERGUARDIAN_CURSE = 115;
        public const int SOUND_MOB_WARNING = 116;
        public const int SOUND_MOB_WARNING_BABY = 117;
        public const int SOUND_TELEPORT = 118;
        public const int SOUND_SHULKER_OPEN = 119;
        public const int SOUND_SHULKER_CLOSE = 120;
        public const int SOUND_HAGGLE = 121;
        public const int SOUND_HAGGLE_YES = 122;
        public const int SOUND_HAGGLE_NO = 123;
        public const int SOUND_HAGGLE_IDLE = 124;
        public const int SOUND_CHORUSGROW = 125;
        public const int SOUND_CHORUSDEATH = 126;
        public const int SOUND_GLASS = 127;
        public const int SOUND_POTION_BREWED = 128;
        public const int SOUND_CAST_SPELL = 129;
        public const int SOUND_PREPARE_ATTACK = 130;
        public const int SOUND_PREPARE_SUMMON = 131;
        public const int SOUND_PREPARE_WOLOLO = 132;
        public const int SOUND_FANG = 133;
        public const int SOUND_CHARGE = 134;
        public const int SOUND_CAMERA_TAKE_PICTURE = 135;
        public const int SOUND_LEASHKNOT_PLACE = 136;
        public const int SOUND_LEASHKNOT_BREAK = 137;
        public const int SOUND_GROWL = 138;
        public const int SOUND_WHINE = 139;
        public const int SOUND_PANT = 140;
        public const int SOUND_PURR = 141;
        public const int SOUND_PURREOW = 142;
        public const int SOUND_DEATH_MIN_VOLUME = 143;
        public const int SOUND_DEATH_MID_VOLUME = 144;
        public const int SOUND_IMITATE_BLAZE = 145;
        public const int SOUND_IMITATE_CAVE_SPIDER = 146;
        public const int SOUND_IMITATE_CREEPER = 147;
        public const int SOUND_IMITATE_ELDER_GUARDIAN = 148;
        public const int SOUND_IMITATE_ENDER_DRAGON = 149;
        public const int SOUND_IMITATE_ENDERMAN = 150;
        public const int SOUND_IMITATE_ENDERMITE = 151;
        public const int SOUND_IMITATE_EVOCATION_ILLAGER = 152;
        public const int SOUND_IMITATE_GHAST = 153;
        public const int SOUND_IMITATE_HUSK = 154;
        public const int SOUND_IMITATE_ILLUSION_ILLAGER = 155;
        public const int SOUND_IMITATE_MAGMA_CUBE = 156;
        public const int SOUND_IMITATE_POLAR_BEAR = 157;
        public const int SOUND_IMITATE_SHULKER = 158;
        public const int SOUND_IMITATE_SILVERFISH = 159;
        public const int SOUND_IMITATE_SKELETON = 160;
        public const int SOUND_IMITATE_SLIME = 161;
        public const int SOUND_IMITATE_SPIDER = 162;
        public const int SOUND_IMITATE_STRAY = 163;
        public const int SOUND_IMITATE_VEX = 164;
        public const int SOUND_IMITATE_VINDICATION_ILLAGER = 165;
        public const int SOUND_IMITATE_WITCH = 166;
        public const int SOUND_IMITATE_WITHER = 167;
        public const int SOUND_IMITATE_WITHER_SKELETON = 168;
        public const int SOUND_IMITATE_WOLF = 169;
        public const int SOUND_IMITATE_ZOMBIE = 170;
        public const int SOUND_IMITATE_ZOMBIE_PIGMAN = 171;
        public const int SOUND_IMITATE_ZOMBIE_VILLAGER = 172;
        public const int SOUND_BLOCK_END_PORTAL_FRAME_FILL = 173;
        public const int SOUND_BLOCK_END_PORTAL_SPAWN = 174;
        public const int SOUND_RANDOM_ANVIL_USE = 175;
        public const int SOUND_BOTTLE_DRAGONBREATH = 176;
        public const int SOUND_PORTAL_TRAVEL = 177;
        public const int SOUND_ITEM_TRIDENT_HIT = 178;
        public const int SOUND_ITEM_TRIDENT_RETURN = 179;
        public const int SOUND_ITEM_TRIDENT_RIPTIDE_1 = 180;
        public const int SOUND_ITEM_TRIDENT_RIPTIDE_2 = 181;
        public const int SOUND_ITEM_TRIDENT_RIPTIDE_3 = 182;
        public const int SOUND_ITEM_TRIDENT_THROW = 183;
        public const int SOUND_ITEM_TRIDENT_THUNDER = 184;
        public const int SOUND_ITEM_TRIDENT_HIT_GROUND = 185;

        public const int SOUND_ELEMCONSTRUCT_OPEN = 188;
        public const int SOUND_ICEBOMB_HIT = 189;
        public const int SOUND_BALLOONPOP = 190;
        public const int SOUND_LT_REACTION_ICEBOMB = 191;
        public const int SOUND_LT_REACTION_BLEACH = 192;
        public const int SOUND_LT_REACTION_EPASTE = 193;
        public const int SOUND_LT_REACTION_EPASTE2 = 194;
        public const int SOUND_LT_REACTION_GLOWSTICK = 195;
        public const int SOUND_LT_REACTION_GLOWSTICK2 = 196;
        public const int SOUND_LT_REACTION_LUMINOL = 197;
        public const int SOUND_LT_REACTION_SALT = 198;
        public const int SOUND_LT_REACTION_FERTILIZER = 199;
        public const int SOUND_LT_REACTION_FIREBALL = 200;
        public const int SOUND_LT_REACTION_MGSALT = 201;
        public const int SOUND_LT_REACTION_MISCFIRE = 202;
        public const int SOUND_LT_REACTION_FIRE = 203;
        public const int SOUND_LT_REACTION_MISCEXPLOSION = 204;
        public const int SOUND_LT_REACTION_MISCMYSTICAL = 205;
        public const int SOUND_LT_REACTION_MISCMYSTICAL2 = 206;
        public const int SOUND_LT_REACTION_PRODUCT = 207;
        public const int SOUND_SPARKLER_USE = 208;
        public const int SOUND_GLOWSTICK_USE = 209;
        public const int SOUND_SPARKLER_ACTIVE = 210;
        public const int SOUND_CONVERT_TO_DROWNED = 211;
        public const int SOUND_BUCKET_FILL_FISH = 212;
        public const int SOUND_BUCKET_EMPTY_FISH = 213;
        public const int SOUND_BUBBLE_COLUMN_UPWARDS = 214;
        public const int SOUND_BUBBLE_COLUMN_DOWNWARDS = 215;
        public const int SOUND_BUBBLE_POP = 216;
        public const int SOUND_BUBBLE_UP_INSIDE = 217;
        public const int SOUND_BUBBLE_DOWN_INSIDE = 218;
        public const int SOUND_HURT_BABY = 219;
        public const int SOUND_DEATH_BABY = 220;
        public const int SOUND_STEP_BABY = 221;
        public const int SOUND_SPAWN_BABY = 222;
        public const int SOUND_BORN = 223;
        public const int SOUND_TURTLE_EGG_BREAK = 224;
        public const int SOUND_TURTLE_EGG_CRACK = 225;
        public const int SOUND_TURTLE_EGG_HATCHED = 226;
        public const int SOUND_LAY_EGG = 227;
        public const int SOUND_TURTLE_EGG_ATTACKED = 228;
        public const int SOUND_BEACON_ACTIVATE = 229;
        public const int SOUND_BEACON_AMBIENT = 230;
        public const int SOUND_BEACON_DEACTIVATE = 231;
        public const int SOUND_BEACON_POWER = 232;
        public const int SOUND_COUDUIT_ACTIVATE = 233;
        public const int SOUND_COUDUIT_AMBIENT = 234;
        public const int SOUND_COUDUIT_ATTACK = 235;
        public const int SOUND_COUDUIT_DEACTIVATE = 236;
        public const int SOUND_COUDUIT_SHORT = 237;
        public const int SOUND_DEFAULT = 238;
        public const int SOUND_UNDEFINED = 239;

        public override byte PacketID { get; } = MinecraftProtocol.LEVEL_SOUND_EVENT_PACKET;

        public byte Sound { get; set; }
        public Vector3 Position { get; set; }
        public int ExtraData { get; set; } = -1;
        public int Pitch { get; set; } = 1;
        public bool IsBabyMob { get; set; } = false;
        public bool IsGlobal { get; set; } = false;

        public override void Encode()
        {
            base.Encode();

            this.WriteByte(this.Sound);
            this.WriteVector3(this.Position);
            this.WriteSVarInt(this.ExtraData);
            this.WriteSVarInt(this.Pitch);
            this.WriteBool(this.IsBabyMob);
            this.WriteBool(this.IsGlobal);
        }

        public override void Decode()
        {
            base.Decode();

            this.Sound = this.ReadByte();
            this.Position = this.ReadVector3();
            this.ExtraData = this.ReadSVarInt();
            this.Pitch = this.ReadSVarInt();
            this.IsBabyMob = this.ReadBool();
            this.IsGlobal = this.ReadBool();
        }
    }
}
