﻿namespace MineNET.Network.MinecraftPackets
{
    public static class MinecraftProtocol
    {
        public const string ClientVersion = "1.7.0";
        public const int ClientProtocol = 291;

        public const byte LOGIN_PACKET = 0x01;
        public const byte PLAY_STATUS_PACKET = 0x02;
        public const byte SERVER_TO_CLIENT_HANDSHAKE_PACKET = 0x03;
        public const byte CLIENT_TO_SERVER_HANDSHAKE_PACKET = 0x04;
        public const byte DISCONNECT_PACKET = 0x05;
        public const byte RESOURCE_PACKS_INFO_PACKET = 0x06;
        public const byte RESOURCE_PACK_STACK_PACKET = 0x07;
        public const byte RESOURCE_PACK_CLIENT_RESPONSE_PACKET = 0x08;
        public const byte TEXT_PACKET = 0x09;
        public const byte SET_TIME_PACKET = 0x0a;
        public const byte START_GAME_PACKET = 0x0b;
        public const byte ADD_PLAYER_PACKET = 0x0c;
        public const byte ADD_ENTITY_PACKET = 0x0d;
        public const byte REMOVE_ENTITY_PACKET = 0x0e;
        public const byte ADD_ITEM_ENTITY_PACKET = 0x0f;
        public const byte ADD_HANGING_ENTITY_PACKET = 0x10;
        public const byte TAKE_ITEM_ENTITY_PACKET = 0x11;
        public const byte MOVE_ENTITY_ABSOLUTE_PACKET = 0x12;
        public const byte MOVE_PLAYER_PACKET = 0x13;
        public const byte RIDER_JUMP_PACKET = 0x14;
        public const byte UPDATE_BLOCK_PACKET = 0x15;
        public const byte ADD_PAINTING_PACKET = 0x16;
        public const byte EXPLODE_PACKET = 0x17;
        public const byte LEVEL_SOUND_EVENT_PACKET = 0x18;
        public const byte LEVEL_EVENT_PACKET = 0x19;
        public const byte BLOCK_EVENT_PACKET = 0x1a;
        public const byte ENTITY_EVENT_PACKET = 0x1b;
        public const byte MOB_EFFECT_PACKET = 0x1c;
        public const byte UPDATE_ATTRIBUTES_PACKET = 0x1d;
        public const byte INVENTORY_TRANSACTION_PACKET = 0x1e;
        public const byte MOB_EQUIPMENT_PACKET = 0x1f;
        public const byte MOB_ARMOR_EQUIPMENT_PACKET = 0x20;
        public const byte INTERACT_PACKET = 0x21;
        public const byte BLOCK_PICK_REQUEST_PACKET = 0x22;
        public const byte ENTITY_PICK_REQUEST_PACKET = 0x23;
        public const byte PLAYER_ACTION_PACKET = 0x24;
        public const byte ENTITY_FALL_PACKET = 0x25;
        public const byte HURT_ARMOR_PACKET = 0x26;
        public const byte SET_ENTITY_DATA_PACKET = 0x27;
        public const byte SET_ENTITY_MOTION_PACKET = 0x28;
        public const byte SET_ENTITY_LINK_PACKET = 0x29;
        public const byte SET_HEALTH_PACKET = 0x2a;
        public const byte SET_SPAWN_POSITION_PACKET = 0x2b;
        public const byte ANIMATE_PACKET = 0x2c;
        public const byte RESPAWN_PACKET = 0x2d;
        public const byte CONTAINER_OPEN_PACKET = 0x2e;
        public const byte CONTAINER_CLOSE_PACKET = 0x2f;
        public const byte PLAYER_HOTBAR_PACKET = 0x30;
        public const byte INVENTORY_CONTENT_PACKET = 0x31;
        public const byte INVENTORY_SLOT_PACKET = 0x32;
        public const byte CONTAINER_SET_DATA_PACKET = 0x33;
        public const byte CRAFTING_DATA_PACKET = 0x34;
        public const byte CRAFTING_EVENT_PACKET = 0x35;
        public const byte GUI_DATA_PICK_ITEM_PACKET = 0x36;
        public const byte ADVENTURE_SETTINGS_PACKET = 0x37;
        public const byte BLOCK_ENTITY_DATA_PACKET = 0x38;
        public const byte PLAYER_INPUT_PACKET = 0x39;
        public const byte FULL_CHUNK_DATA_PACKET = 0x3a;
        public const byte SET_COMMANDS_ENABLED_PACKET = 0x3b;
        public const byte SET_DIFFICULTY_PACKET = 0x3c;
        public const byte CHANGE_DIMENSION_PACKET = 0x3d;
        public const byte SET_PLAYER_GAME_TYPE_PACKET = 0x3e;
        public const byte PLAYER_LIST_PACKET = 0x3f;
        public const byte SIMPLE_EVENT_PACKET = 0x40;
        public const byte EVENT_PACKET = 0x41;
        public const byte SPAWN_EXPERIENCE_ORB_PACKET = 0x42;
        public const byte CLIENTBOUND_MAP_ITEM_DATA_PACKET = 0x43;
        public const byte MAP_INFO_REQUEST_PACKET = 0x44;
        public const byte REQUEST_CHUNK_RADIUS_PACKET = 0x45;
        public const byte CHUNK_RADIUS_UPDATED_PACKET = 0x46;
        public const byte ITEM_FRAME_DROP_ITEM_PACKET = 0x47;
        public const byte GAME_RULES_CHANGED_PACKET = 0x48;
        public const byte CAMERA_PACKET = 0x49;
        public const byte BOSS_EVENT_PACKET = 0x4a;
        public const byte SHOW_CREDITS_PACKET = 0x4b;
        public const byte AVAILABLE_COMMANDS_PACKET = 0x4c;
        public const byte COMMAND_REQUEST_PACKET = 0x4d;
        public const byte COMMAND_BLOCK_UPDATE_PACKET = 0x4e;
        public const byte COMMAND_OUTPUT_PACKET = 0x4f;
        public const byte UPDATE_TRADE_PACKET = 0x50;
        public const byte UPDATE_EQUIPMENT_PACKET = 0x51;
        public const byte RESOURCE_PACK_DATA_INFO_PACKET = 0x52;
        public const byte RESOURCE_PACK_CHUNK_DATA_PACKET = 0x53;
        public const byte RESOURCE_PACK_CHUNK_REQUEST_PACKET = 0x54;
        public const byte TRANSFER_PACKET = 0x55;
        public const byte PLAY_SOUND_PACKET = 0x56;
        public const byte STOP_SOUND_PACKET = 0x57;
        public const byte SET_TITLE_PACKET = 0x58;
        public const byte ADD_BEHAVIOR_TREE_PACKET = 0x59;
        public const byte STRUCTURE_BLOCK_UPDATE_PACKET = 0x5a;
        public const byte SHOW_STORE_OFFER_PACKET = 0x5b;
        public const byte PURCHASE_RECEIPT_PACKET = 0x5c;
        public const byte PLAYER_SKIN_PACKET = 0x5d;
        public const byte SUB_CLIENT_LOGIN_PACKET = 0x5e;
        public const byte W_S_CONNECT_PACKET = 0x5f;
        public const byte SET_LAST_HURT_BY_PACKET = 0x60;
        public const byte BOOK_EDIT_PACKET = 0x61;
        public const byte NPC_REQUEST_PACKET = 0x62;
        public const byte PHOTO_TRANSFER_PACKET = 0x63;
        public const byte MODAL_FORM_REQUEST_PACKET = 0x64;
        public const byte MODAL_FORM_RESPONSE_PACKET = 0x65;
        public const byte SERVER_SETTINGS_REQUEST_PACKET = 0x66;
        public const byte SERVER_SETTINGS_RESPONSE_PACKET = 0x67;
        public const byte SHOW_PROFILE_PACKET = 0x68;
        public const byte SET_DEFAULT_GAME_TYPE_PACKET = 0x69;
        public const byte REMOVE_OBJECTIVE_PACKET = 0x6a;
        public const byte SET_DISPLAY_OBJECTIVE_PACKET = 0x6b;
        public const byte SET_SCORE_PACKET = 0x6c;
        public const byte LAB_TABLE_PACKET = 0x6d;
        public const byte UPDATE_BLOCK_SYNCED_PACKET = 0x6e;
        public const byte MOVE_ENTITY_DELTA_PACKET = 0x6f;
        public const byte SET_SCOREBOARD_IDENTITY_PACKET = 0x70;
        public const byte SET_LOCAL_PLAYER_AS_INITIALIZED_PACKET = 0x71;
        public const byte UPDATE_SOFT_ENUM_PACKET = 0x72;
        public const byte NETWORK_STACK_LATENCY_PACKET = 0x73;
    }
}
