﻿using MineNET.Commands;
using MineNET.Data;
using MineNET.Entities.Attributes;
using MineNET.Network;
using MineNET.Network.MinecraftPackets;
using MineNET.Network.RakNetPackets;
using MineNET.Values;
using MineNET.Worlds;
using MineNET.Worlds.Rule;
using System;
using System.Collections.Concurrent;
using System.Net;

namespace MineNET.Entities.Players
{
    public class Player : EntityLiving, CommandSender
    {
        #region Property & Field
        public override bool IsPlayer
        {
            get
            {
                return true;
            }
        }

        public override string Name { get; protected set; }
        public new string DisplayName { get; private set; }

        public IPEndPoint EndPoint { get; internal set; }

        public bool IsPreLogined { get; private set; }
        public bool IsLogined { get; private set; }
        public LoginData LoginData { get; private set; }
        public ClientData ClientData { get; private set; }
        public Skin Skin { get; private set; }
        public UUID Uuid { get; private set; }

        public PlayerListEntry PlayerListEntry { get; private set; }
        public AdventureSettingsEntry AdventureSettingsEntry { get; private set; }

        public GameMode GameMode { get; private set; } = GameMode.Survival;

        public bool PackSyncCompleted { get; private set; }
        public bool HaveAllPacks { get; private set; }

        public bool HasSpawned { get; private set; }
        public bool AnySendChunk { get; private set; }
        public int RequestChunkRadius { get; private set; } = 8;

        public override float Width { get; } = 0.60f;
        public override float Height { get; } = 1.80f;

        public ConcurrentDictionary<Tuple<int, int>, double> LoadedChunks { get; private set; } = new ConcurrentDictionary<Tuple<int, int>, double>();
        #endregion

        #region Ctor
        public Player() : base(null, null)
        {

        }
        #endregion

        #region Init Method
        protected override void EntityInit()
        {
            base.EntityInit();

            this.Attributes.AddAttribute(EntityAttribute.HUNGER);
            this.Attributes.AddAttribute(EntityAttribute.SATURATION);
            this.Attributes.AddAttribute(EntityAttribute.EXHAUSTION);
            this.Attributes.AddAttribute(EntityAttribute.EXPERIENCE);
            this.Attributes.AddAttribute(EntityAttribute.EXPERIENCE_LEVEL);

            this.SetFlag(Entity.DATA_FLAGS, Entity.DATA_FLAG_BREATHING);
            this.SetFlag(Entity.DATA_FLAGS, Entity.DATA_FLAG_CAN_CLIMB);
        }
        #endregion

        #region Send Message Method
        public void SendMessage(TranslationMessage message)
        {
            throw new NotImplementedException();
        }

        public void SendMessage(string message)
        {
            throw new NotImplementedException();
        }

        public void SendMessage(string message, params object[] args)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Send Status Method
        public void SendPlayStatus(int status, int flag = RakNetProtocol.FlagNormal)
        {
            PlayStatusPacket pk = new PlayStatusPacket();
            pk.Status = status;

            this.SendPacket(pk, flag: flag);
        }
        #endregion

        #region Send ChunkRadius Method
        public void SendChunkRadiusUpdated(int radius)
        {
            ChunkRadiusUpdatedPacket pk = new ChunkRadiusUpdatedPacket();
            pk.Radius = radius;

            this.SendPacket(pk);

            this.RequestChunkRadius = radius;
        }
        #endregion

        #region Send Chunk Method
        public void SendChunk()
        {
            //Task.Run(() =>
            //{
            //    Thread.CurrentThread.Name = "ChunkSendThread";
            foreach (Chunk c in this.World.LoadChunks(this, this.RequestChunkRadius))
            {
                c.SendChunk(this);
            }
            //});
        }
        #endregion

        #region Send Packet Method
        public void SendPacket(MinecraftPacket packet, int reliability = RakNetPacketReliability.RELIABLE, int flag = RakNetProtocol.FlagNormal)
        {
            NetworkSession session = Server.Instance.Network.GetSession(this.EndPoint);
            if (session == null)
            {
                return;
            }

            session.AddPacketBatchQueue(packet, reliability, flag);
        }
        #endregion

        #region Update Method
        internal override bool UpdateTick(long tick)
        {
            if (tick % 20 == 0 && this.AnySendChunk)
            {
                this.SendChunk();
            }
            return true;
        }
        #endregion

        #region Packet Handle Method
        public void OnPacketHandle(MinecraftPacket packet)
        {
            if (packet is LoginPacket)//0x01
            {
                this.HandleLoginPacket((LoginPacket) packet);
            }
            else if (packet is ResourcePackClientResponsePacket)//0x08
            {
                this.HandleResourcePackClientResponsePacket((ResourcePackClientResponsePacket) packet);
            }
            else if (packet is MovePlayerPacket)//0x13
            {
                this.HandleMovePlayerPacket((MovePlayerPacket) packet);
            }
            else if (packet is RequestChunkRadiusPacket)//0x45
            {
                this.HandleRequestChunkRadiusPacket((RequestChunkRadiusPacket) packet);
            }
            else if (packet is SetLocalPlayerAsInitializedPacket)//0x70
            {
                this.HandleSetLocalPlayerAsInitializedPacket((SetLocalPlayerAsInitializedPacket) packet);
            }
        }

        //0x01
        public void HandleLoginPacket(LoginPacket pk)
        {
            if (this.IsPreLogined)
            {
                return;
            }

            if (pk.Protocol < MinecraftProtocol.ClientProtocol)
            {
                this.SendPlayStatus(PlayStatusPacket.LOGIN_FAILED_CLIENT, RakNetProtocol.FlagImmediate);
                //this.Close("disconnectionScreen.outdatedClient");
                return;
            }
            else if (pk.Protocol > MinecraftProtocol.ClientProtocol)
            {
                this.SendPlayStatus(PlayStatusPacket.LOGIN_FAILED_SERVER, RakNetProtocol.FlagImmediate);
                //this.Close("disconnectionScreen.outdatedServer");
                return;
            }

            Player[] players = Server.Instance.GetPlayers();
            for (int i = 0; i < players.Length; ++i)
            {
                if (players[i].GetHashCode() != this.GetHashCode())
                {
                    if (players[i].Name == this.Name)
                    {
                        this.Close("disconnectionScreen.loggedinOtherLocation");
                        return;
                    }
                }
            }

            int maxplayers = Server.Instance.ServerProperty.MaxPlayers;
            if (players.Length > maxplayers)
            {
                this.SendPlayStatus(PlayStatusPacket.LOGIN_FAILED_SERVER_FULL, RakNetProtocol.FlagImmediate);
                //this.Close("disconnectionScreen.outdatedServer");
            }

            //TODO: Auth MS Server

            this.LoginData = pk.LoginData;
            this.Name = pk.LoginData.DisplayName;
            this.DisplayName = this.Name;
            this.Uuid = this.LoginData.ClientUUID;

            this.ClientData = pk.ClientData;
            this.Skin = this.ClientData.Skin;

            //TODO: Event

            this.IsPreLogined = true;

            this.SendPlayStatus(PlayStatusPacket.LOGIN_SUCCESS);

            ResourcePacksInfoPacket info = new ResourcePacksInfoPacket();
            this.SendPacket(info);
        }

        //0x08
        public void HandleResourcePackClientResponsePacket(ResourcePackClientResponsePacket pk)
        {
            if (this.PackSyncCompleted)
            {
                return;
            }

            if (pk.ResponseStatus == ResourcePackClientResponsePacket.STATUS_REFUSED)
            {
                this.Close("disconnectionScreen.resourcePack");
            }
            else if (pk.ResponseStatus == ResourcePackClientResponsePacket.STATUS_SEND_PACKS)
            {
                //TODO: ResourcePackDataInfoPacket
            }
            else if (pk.ResponseStatus == ResourcePackClientResponsePacket.STATUS_HAVE_ALL_PACKS)
            {
                ResourcePackStackPacket resourcePackStackPacket = new ResourcePackStackPacket();
                this.SendPacket(resourcePackStackPacket);

                this.HaveAllPacks = true;
            }
            else if (pk.ResponseStatus == ResourcePackClientResponsePacket.STATUS_COMPLETED && this.HaveAllPacks)
            {
                if (this.IsLogined)
                {
                    return;
                }

                //TODO: Event

                this.IsLogined = true;

                //TODO: Load NBT

                this.World = World.GetMainWorld();
                this.X = 128;
                this.Y = 6;
                this.Z = 128;

                StartGamePacket startGamePacket = new StartGamePacket();
                startGamePacket.EntityUniqueId = this.EntityID;
                startGamePacket.EntityRuntimeId = this.EntityID;
                startGamePacket.PlayerGamemode = this.GameMode;
                startGamePacket.PlayerPosition = new Vector3(this.X, this.Y, this.Z);
                startGamePacket.Direction = new Vector2(this.Yaw, this.Pitch);

                startGamePacket.WorldGamemode = this.World.Gamemode;
                startGamePacket.Difficulty = this.World.Difficulty;
                startGamePacket.SpawnX = this.World.SpawnX;
                startGamePacket.SpawnY = 5;//TODO: Safe Spawn
                startGamePacket.SpawnZ = this.World.SpawnZ;
                startGamePacket.WorldName = this.World.Name;

                startGamePacket.GameRules = new GameRules();
                startGamePacket.GameRules.Add(new GameRule<bool>("ShowCoordinates", true));
                this.SendPacket(startGamePacket);

                this.SendPlayStatus(PlayStatusPacket.PLAYER_SPAWN);
                this.HasSpawned = true;

                this.PlayerListEntry = new PlayerListEntry(this.LoginData.ClientUUID)
                {
                    EntityUniqueId = this.EntityID,
                    Name = this.DisplayName,
                    PlatForm = this.ClientData.DeviceOS,
                    Skin = this.Skin,
                    UUID = this.Uuid,
                    XboxUserId = this.LoginData.XUID
                };
                this.PlayerListEntry.UpdateAll();

                AdventureSettingsEntry adventureSettingsEntry = new AdventureSettingsEntry();
                adventureSettingsEntry.SetFlag(AdventureSettingsPacket.WORLD_IMMUTABLE, false);
                adventureSettingsEntry.SetFlag(AdventureSettingsPacket.NO_PVP, false);
                adventureSettingsEntry.SetFlag(AdventureSettingsPacket.AUTO_JUMP, false);
                adventureSettingsEntry.SetFlag(AdventureSettingsPacket.ALLOW_FLIGHT, true);
                adventureSettingsEntry.SetFlag(AdventureSettingsPacket.NO_CLIP, false);
                adventureSettingsEntry.SetFlag(AdventureSettingsPacket.FLYING, false);
                adventureSettingsEntry.CommandPermission = PlayerPermissions.MEMBER;//this.Op ? PlayerPermissions.OPERATOR : PlayerPermissions.MEMBER;
                adventureSettingsEntry.PlayerPermission = PlayerPermissions.MEMBER;//this.Op ? PlayerPermissions.OPERATOR : PlayerPermissions.MEMBER;
                adventureSettingsEntry.EntityUniqueId = this.EntityID;
                this.AdventureSettingsEntry = adventureSettingsEntry;
                this.AdventureSettingsEntry.Update(this);

                this.Attributes.Update(this);
                this.SendDataProperties();
            }
        }

        //0x13
        public void HandleMovePlayerPacket(MovePlayerPacket pk)
        {
            Vector3 pos = pk.Position;
            Vector3 direction = pk.Direction;
            //if ((Vector3) this.X != pos || this.Direction != direction)
            //{
            //this.SendPacketViewers(pk.Clone());
            //}
            this.X = pos.X;
            this.Y = pos.Y;
            this.Z = pos.Z;
            this.Pitch = direction.X;
            this.Yaw = direction.Y;
        }

        //0x45
        public void HandleRequestChunkRadiusPacket(RequestChunkRadiusPacket pk)
        {
            int request = pk.Radius;
            int max = Server.Instance.ServerProperty.MaxViewDistance;

            OutLog.Log("%server.player.requestChunkRadius", this.DisplayName, request);
            if (request > max)
            {
                OutLog.Log("%server.player.updateChunkRadius", this.DisplayName, request, max);
                this.SendChunkRadiusUpdated(max);
            }
            else
            {
                this.SendChunkRadiusUpdated(request);
            }
            this.AnySendChunk = true;
        }

        //0x70
        public void HandleSetLocalPlayerAsInitializedPacket(SetLocalPlayerAsInitializedPacket pk)
        {

        }
        #endregion

        #region Close Player Method
        public void Close(string reason)
        {
            if (!string.IsNullOrEmpty(reason))
            {
                DisconnectPacket pk = new DisconnectPacket();
                pk.Message = reason;

                this.SendPacket(pk, flag: RakNetProtocol.FlagImmediate);
            }

            Server.Instance.Network.GetSession(this.EndPoint)?.Disconnect(reason);
        }
        #endregion
    }
}
