using PSULib.FileClasses.General;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Drawing.Design;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.LinkLabel;

namespace PSULib.FileClasses.Missions
{
	public class QuestXNRFile : PsuFile
	{
		public List<string> temporary_flags = new List<string>();
		public List<string> numeric_flags = new List<string>();
		public List<string> boolean_flags = new List<string>();

		public class WarpPointEntry
		{
			public int quest_id = -1;
			public short zone_id = -1;
			public short map_id = -1;
			public int entrance_id = -1;
		}

		public List<Tuple<WarpPointEntry, WarpPointEntry>> WarpPairList = new List<Tuple<WarpPointEntry, WarpPointEntry>>();

		public class QuestItemEntry
		{
			public byte item_index = 0;
			public uint item_id = 0;
			public byte element = 0;
			public byte min_element_percent = 0;
			public byte quantity = 0;
			public byte reward_type = 0;
			public ushort element_type = 0;
			public byte max_element_percent = 0;
			public uint meseta = 0;

			public List<int> conditions = new List<int>();
		};
		public List<QuestItemEntry> quest_items = new List<QuestItemEntry>();

		public class ClearScoreTask
		{
			public byte type;                       //Time, Monster, Party death, etc
			public byte unk_a;
			public ushort npc;
			public int nb_points_required;
			public int maximum_penalty;
			public int nb_required;                //Number of enemies, minimum time, etc
			public int nb_points_per_penalty;       //Points per instance where the condition is not met
			public int nb_flag;
			public byte[] required_flag = new byte[ 8 ];      // 8 Entries
			public int unk_b, unk_c, unk_d, unk_e;
			public ushort[] map_required_flag = new ushort[ 8 ];  // 8 Entries
		};
		public List<ClearScoreTask> clear_score_tasks = new List<ClearScoreTask>();

		public int[] clear_rank_required_points = new int[ 4 ];      // 4 Entries : C, B, A, S
		public int[] clear_rank_mission_points = new int[ 4 ];       // 4 Entries : C, B, A, S

		public class StatModEntry
		{
			public enum EnumStatType
			{
				HP, ATP, DFP, ATA, EVP, STA, LUK, TP, MST, UNK, EXP, SPD, NUM_STAT
			}

			//public int monster_type;
			public BitArray monster_type = new BitArray( 32 );
			public ushort[] stat = new ushort[ (int)EnumStatType.NUM_STAT ];
		};

		public class ZoneEntry
		{
			public ushort zone_number;
			public ushort area_code;
			public int area_code_other;
			public ushort unk_a;
			public byte monster_level;
			public byte unk_b;
			public int unk_c;
			public int ptr_set_probability_ptr;
			public int ptr_map_list;
			public int nb_map;
			public int ptr_enemy_stat_modifier;
			public int ptr_boss_stat_modifier;

			public StatModEntry enemy_stat_modifier = new StatModEntry();
			public StatModEntry boss_stat_modifier = new StatModEntry();
			public List<int> set_probability = new List<int>();
			public List<short> map_list = new List<short>();
		};

		public Dictionary<ushort, ZoneEntry> ZoneData = new Dictionary<ushort, ZoneEntry>();

		public class CustomNPCDataEntry
		{
			public int npc_id;
			public byte[] data = new byte[ 92 ];
			//	uint[] body_part = new uint[ 6 ];   // Torso, Legs, Shoes, Ear, Face, Hair
			//	
			//	byte[] body_part_color = new byte[ 3 ]; // Torso, Legs, Shoes
			//	
			//	byte voice_type;
			//	byte voice_pitch;
			//	
			//	byte line_shield_color;
			//	byte nano_blast_badge;
			//	byte eye_brow;
			//	byte eye_lash;
			//	byte eye_group;
			//	byte eye;
			//	byte body_suit;
			//	
			//	uint eye_color_x, eye_color_y;
			//	uint lip_color_sat, lip_color_x, lip_color_y;
			//	uint body_color;
			//	uint sub_color;				//Cast Only, FFFF0200 otherwise.
			//	uint hair_color_X, hair_color_y;
			//	uint height;
			//	uint body_scale_x, body_scale_y;
			//	uint face_scale_x, face_scale_y;
		}

		List<int> npc_list = new List<int>();
		List<CustomNPCDataEntry> custom_npc_list = new List<CustomNPCDataEntry>();

		public ushort quest_version;
		private int time_stamp;
		public int quest_id;

		public WarpPointEntry entrance_warp = new WarpPointEntry();
		public WarpPointEntry exit_warp = new WarpPointEntry();
		public WarpPointEntry failed_warp = new WarpPointEntry();

		public BitArray mission_flags = new BitArray( 32 * 4 );

		private int unk_c;

		public short area_icon;
		private short unk_d;
		public byte minimum_party_size;
		public byte maximum_party_size;
		public short map_x;
		public short map_y;

		private ushort unk_g;
		private int unk_h, unk_i;


		public List<int> trial_visible_condition = new List<int>();
		public List<int> trial_select_condition = new List<int>();
		public List<int> trial_start_condition = new List<int>();
		public List<int> trial_clear_condition = new List<int>();
		public List<int> trial_failed_condition = new List<int>();
		public List<int> trial_end_condition = new List<int>();
		public List<Tuple<short, short>> counter_path_node = new List<Tuple<short, short>>();

		int baseAddr;
		int[] ptrs;
		private byte[] backupRaw;

		MemoryStream stream = null;
		BinaryReader reader = null;
		BinaryWriter writer = null;

		List<int> calculated_ptr_list = new List<int>();

		public QuestXNRFile( string inFilename, byte[] rawData, byte[] inHeader, int[] ptrs, int baseAddr )
		{
			this.header = inHeader;
			this.filename = inFilename;
			this.ptrs = ptrs;
			this.baseAddr = baseAddr;
			this.backupRaw = rawData;

			stream = new MemoryStream( rawData );
			reader = new BinaryReader( stream );

			string ident = new string( reader.ReadChars( 4 ) );
			int fileLength = reader.ReadInt32();
			int main_table_ptr = reader.ReadInt32();
			int unknown = reader.ReadInt32();

			// Read Main Table
			stream.Seek( main_table_ptr, SeekOrigin.Begin );

			quest_version = reader.ReadUInt16();
			int unknown_a = reader.ReadUInt16();

			time_stamp = reader.ReadInt32();
			quest_id = reader.ReadInt32();

			int ptr_zone_data = reader.ReadInt32();
			int nb_zone_data = reader.ReadInt32();
			int ptr_warp_data = reader.ReadInt32();
			int nb_warp_data = reader.ReadInt32();

			entrance_warp = ReadWarp();
			exit_warp = ReadWarp();

			//bit_flag = reader.ReadInt32();
			mission_flags = new BitArray( reader.ReadBytes( 16 ) );

			int ptr_select_condition = reader.ReadInt32();
			int ptr_trial_start_condition = reader.ReadInt32();
			int ptr_trial_clear_condition = reader.ReadInt32();
			int ptr_trial_fail_condition = reader.ReadInt32();
			int ptr_trial_end_condition = reader.ReadInt32();
			unk_c = reader.ReadInt32();

			area_icon = reader.ReadInt16();
			unk_d = reader.ReadInt16();

			minimum_party_size = reader.ReadByte();
			maximum_party_size = reader.ReadByte();

			map_x = reader.ReadInt16();
			map_y = reader.ReadInt16();

			reader.ReadUInt16();

			int ptr_quest_item_list = reader.ReadInt32();

			// Failed Warp
			failed_warp = ReadWarp();

			int ptr_ranking_header = reader.ReadInt32();
			int unk_f = reader.ReadInt32();

			int ptr_path_nodes = reader.ReadInt32();
			short nb_path_nodes = reader.ReadInt16();

			unk_g = reader.ReadUInt16();

			int ptr_visible_condition = reader.ReadInt32();
			int ptr_temporary_flag_ptr_list = reader.ReadInt32();
			int ptr_numeric_flag_ptr_list = reader.ReadInt32();
			int ptr_boolean_flag_ptr_list = reader.ReadInt32();

			byte nb_temporary_flag = reader.ReadByte();
			byte nb_numeric_flag = reader.ReadByte();
			byte nb_boolean_flag = reader.ReadByte();
			byte nb_npc = reader.ReadByte();

			int ptr_npc_id = reader.ReadInt32();

			unk_h = reader.ReadInt32();	// 00000100
			unk_i = reader.ReadInt32(); // 00000100	 (00000200 for Innocent Girl)

			int nb_custom_npc = reader.ReadInt32();
			int ptr_custom_npc_data = reader.ReadInt32();

			byte[] unk_j = reader.ReadBytes( 0x54 );

			ReadConditionStack( ptr_visible_condition, ref trial_visible_condition );
			ReadConditionStack( ptr_select_condition, ref trial_select_condition );
			ReadConditionStack( ptr_trial_start_condition, ref trial_start_condition );
			ReadConditionStack( ptr_trial_clear_condition, ref trial_clear_condition );
			ReadConditionStack( ptr_trial_fail_condition, ref trial_failed_condition );
			ReadConditionStack( ptr_trial_end_condition, ref trial_end_condition );

			ReadFlags( ptr_temporary_flag_ptr_list, nb_temporary_flag, ref temporary_flags );
			ReadFlags( ptr_numeric_flag_ptr_list, nb_numeric_flag, ref numeric_flags );
			ReadFlags( ptr_boolean_flag_ptr_list, nb_boolean_flag, ref boolean_flags );

			ReadItemRewardData( ptr_quest_item_list );
			ReadRankingData( ptr_ranking_header );
			ReadZoneData( ptr_zone_data, nb_zone_data );
			ReadWarpPairData( ptr_warp_data, nb_warp_data );
			ReadPathNodes( ptr_path_nodes, nb_path_nodes );

			ReadNPCData( ptr_npc_id, nb_npc );
			ReadCustomNPCData( ptr_custom_npc_data, nb_custom_npc );

			stream.Close();
			reader.Close();

			int dbg = 0;
		}



		void ReadConditionStack( int offset, ref List<int> list )
		{
			if( offset == 0 )
				return;

			stream.Seek( offset, SeekOrigin.Begin );
			int ptr_to_ops = reader.ReadInt32();
			int num_ops = reader.ReadInt32();

			stream.Seek( ptr_to_ops, SeekOrigin.Begin );
			for( int i = 0; i < num_ops; i++ )
			{
				list.Add( reader.ReadInt32() );
			}
		}

		void ReadFlags( int offset, int count, ref List<string> list )
		{
			if( offset == 0 )
				return;

			for( int i = 0; i < count; i++ )
			{
				stream.Seek( offset + ( 0x04 * i ), SeekOrigin.Begin );
				int ptr_flags = reader.ReadInt32();
				stream.Seek( ptr_flags, SeekOrigin.Begin );
				string flag = new string( reader.ReadChars( 16 ) );

				list.Add( flag );
			}
		}

		void ReadItemRewardData( int offset )
		{
			if( offset == 0 )
			{
				return;
			}

			stream.Seek( offset, SeekOrigin.Begin );

			int ptr_quest_item = reader.ReadInt32();
			int nb_quest_item = reader.ReadInt32();

			stream.Seek( ptr_quest_item, SeekOrigin.Begin );

			for( int i = 0; i < nb_quest_item; i++ )
			{
				QuestItemEntry entry = new QuestItemEntry();

				entry.item_index = reader.ReadByte();
				entry.item_id = reader.ReadUInt32();
				entry.element = reader.ReadByte();
				entry.min_element_percent = reader.ReadByte();
				entry.quantity = reader.ReadByte();
				entry.reward_type = reader.ReadByte();
				entry.element_type = reader.ReadUInt16();
				entry.max_element_percent = reader.ReadByte();
				entry.meseta = reader.ReadUInt32();

				entry.conditions = new List<int>();

				quest_items.Add( entry );
			}
		}

		void ReadRankingData( int offset )
		{
			if( offset == 0 )
			{
				return;
			}

			stream.Seek( offset, SeekOrigin.Begin );

			int ptr_clear_rank_condition = reader.ReadInt32();
			int nb_clear_rank_condition = reader.ReadInt32();

			int ptr_clear_rewards = reader.ReadInt32();
			int nb_clear_rewards = reader.ReadInt32();

			// Required Points to Qualify
			for( int i = 0; i < 4; i++ )
			{
				clear_rank_required_points[ i ] = reader.ReadInt32();
			}

			// Mission Points Rewarded
			for( int i = 0; i < 4; i++ )
			{
				clear_rank_mission_points[ i ] = reader.ReadInt32();
			}

			reader.ReadInt32();    // Unknown

			// Read Ranking Conditions
			stream.Seek( ptr_clear_rank_condition, SeekOrigin.Begin );

			for( int i = 0; i < nb_clear_rank_condition; i++ )
			{
				ClearScoreTask task = new ClearScoreTask();

				task.type = reader.ReadByte();
				task.unk_a = reader.ReadByte();
				task.npc = reader.ReadUInt16();
				task.nb_points_required = reader.ReadInt32();
				task.maximum_penalty = reader.ReadInt32();

				task.nb_required = reader.ReadInt32();
				task.nb_points_per_penalty = reader.ReadInt32();

				task.nb_flag = reader.ReadInt32();
				task.required_flag = reader.ReadBytes( 8 );

				task.unk_b = reader.ReadInt32();
				task.unk_c = reader.ReadInt32();
				task.unk_d = reader.ReadInt32();
				task.unk_e = reader.ReadInt32();

				for( int j = 0; j < 8; j++ )
				{
					task.map_required_flag[ j ] = reader.ReadUInt16();
				}

				clear_score_tasks.Add( task );
			}

			// Read Ranking Reward Conditions
			stream.Seek( ptr_clear_rewards, SeekOrigin.Begin );

			for( int i = 0; i < nb_clear_rewards; i++ )
			{
				//
				stream.Seek( ptr_clear_rewards + ( 0x08 * i ), SeekOrigin.Begin );
				byte reward_index = reader.ReadByte();
				reader.ReadBytes( 3 );
				int ptr_to_stack_ptr = reader.ReadInt32();

				//
				stream.Seek( ptr_to_stack_ptr, SeekOrigin.Begin );
				int ptr_to_ops = reader.ReadInt32();
				int nb_ops = reader.ReadInt32();

				//
				stream.Seek( ptr_to_ops, SeekOrigin.Begin );
				for( int op_idx = 0; op_idx < nb_ops; op_idx++ )
				{
					quest_items[ (byte)reward_index ].conditions.Add( reader.ReadInt32() );
				}
			}
		}

		WarpPointEntry ReadWarp()
		{
			WarpPointEntry entry = new WarpPointEntry();

			entry.quest_id = reader.ReadInt32();
			entry.zone_id = reader.ReadInt16();
			entry.map_id = reader.ReadInt16();
			entry.entrance_id = reader.ReadInt32();

			return entry;
		}

		void ReadZoneData( int offset, int count )
		{
			if( offset == 0 || count < 1 )
			{
				return;
			}

			stream.Seek( offset, SeekOrigin.Begin );

			for( int i = 0; i < count; i++ )
			{
				stream.Seek( offset + ( 64 * i ), SeekOrigin.Begin );

				ZoneEntry entry = new ZoneEntry();

				entry.zone_number = reader.ReadUInt16();
				entry.area_code = reader.ReadUInt16();
				entry.area_code_other = reader.ReadInt32();
				entry.unk_a = reader.ReadUInt16();
				entry.monster_level = reader.ReadByte();
				entry.unk_b = reader.ReadByte();

				entry.unk_c = reader.ReadInt32();
				entry.ptr_set_probability_ptr = reader.ReadInt32();
				entry.ptr_map_list = reader.ReadInt32();
				entry.nb_map = reader.ReadInt32();
				entry.ptr_enemy_stat_modifier = reader.ReadInt32();
				entry.ptr_boss_stat_modifier = reader.ReadInt32();
				
				byte[] reserved = reader.ReadBytes( 28 );

				if( entry.ptr_map_list > 0 )
				{
					stream.Seek( entry.ptr_map_list, SeekOrigin.Begin );
					for( int j = 0; j < entry.nb_map; j++ )
					{
						entry.map_list.Add( reader.ReadInt16() );
					}
				}

				if( entry.ptr_set_probability_ptr > 0 )
				{
					stream.Seek( entry.ptr_set_probability_ptr, SeekOrigin.Begin );
					int ptr_set_probability = reader.ReadInt32();
					int nb_set_probability = reader.ReadInt32();

					stream.Seek( ptr_set_probability, SeekOrigin.Begin );
					for( int j = 0; j < nb_set_probability; j++ )
					{
						entry.set_probability.Add( reader.ReadInt32() );
					}
				}

				if( entry.ptr_enemy_stat_modifier > 0 )
				{
					stream.Seek( entry.ptr_enemy_stat_modifier, SeekOrigin.Begin );

					entry.enemy_stat_modifier.monster_type = new BitArray( BitConverter.GetBytes( reader.ReadInt32() ) );

					for( int j = 0; j < 12; j++ )
					{
						entry.enemy_stat_modifier.stat[ j ] = reader.ReadUInt16();
					}
				}

				if( entry.ptr_boss_stat_modifier > 0 )
				{
					stream.Seek( entry.ptr_boss_stat_modifier, SeekOrigin.Begin );

					entry.boss_stat_modifier.monster_type = new BitArray( BitConverter.GetBytes( reader.ReadInt32() ) );
					for( int j = 0; j < 12; j++ )
					{
						entry.boss_stat_modifier.stat[ j ] = reader.ReadUInt16();
					}
				}

				ZoneData.Add( entry.zone_number, entry );
			}
		}

		void ReadWarpPairData( int offset, int count )
		{
			if( offset == 0 || count == 0 )
			{
				return;
			}

			stream.Seek( offset, SeekOrigin.Begin );

			for( int i = 0; i < count; i++ )
			{
				WarpPointEntry warp_a = ReadWarp();
				WarpPointEntry warp_b = ReadWarp();

				WarpPairList.Add( Tuple.Create( warp_a, warp_b ) );
			}
		}

		void ReadPathNodes( int offset, int count )
		{
			if( offset == 0 || count == 0 )
			{
				return;
			}

			stream.Seek( offset, SeekOrigin.Begin );

			for( int i = 0; i < count; i++ )
			{
				short node_x = reader.ReadInt16();
				short node_y = reader.ReadInt16();

				counter_path_node.Add( Tuple.Create( node_x, node_y ) );
			}
		}

		void ReadNPCData( int offset, int count )
		{
			if( offset == 0 || count == 0 )
			{
				return;
			}

			stream.Seek( offset, SeekOrigin.Begin );


		}

		void ReadCustomNPCData( int offset, int count )
		{
			if( offset == 0 || count == 0 )
			{
				return;
			}

			stream.Seek( offset, SeekOrigin.Begin );

			int ptr_npc_data = reader.ReadInt32();
			int nb_npc_data = reader.ReadInt32();

			stream.Seek( ptr_npc_data, SeekOrigin.Begin );
			for( int i = 0; i < nb_npc_data; i++ )
			{
				CustomNPCDataEntry entry = new CustomNPCDataEntry();

				int npc_id = reader.ReadInt32();
				entry.data = reader.ReadBytes( 92 );

				custom_npc_list.Add( entry );
			}
		}

		void WritePointer( int ptr )
		{
			if( ptr != 0 )
			{
				calculated_ptr_list.Add( (int)stream.Position );
				writer.Write( ptr );
			}
			else
			{
				writer.Write( (int)0 );
			}
		}

		void WriteWarpData( WarpPointEntry warp )
		{
			writer.Write( warp.quest_id );
			writer.Write( warp.zone_id );
			writer.Write( warp.map_id );
			writer.Write( warp.entrance_id );
		}

		void WriteFlags( List<string> flag_list, List<int> offsets )
		{
			byte[] bytes = new byte[ 16 ];

			foreach( var flag in flag_list )
			{
				offsets.Add( (int)stream.Position );

				Encoding.UTF8.GetBytes( flag.Substring( 0, 16 ) ).CopyTo( bytes, 0 );
				writer.Write( bytes );
			}
		}

		void WriteTrialCondition( List<int> condition_ops, ref int condition_ptr )
		{
			condition_ptr = 0;

			if( condition_ops.Count < 1 )
			{
				return;
			}

			int current_pos = (int)stream.Position;

			foreach( var op in condition_ops )
			{
				writer.Write( op );
			}

			condition_ptr = (int)stream.Position;
			WritePointer( current_pos );
			writer.Write( condition_ops.Count );
		}

		// Enter the danger zone!!!
		public override byte[] ToRaw()
		{
			stream = new MemoryStream();
			writer = new BinaryWriter( stream );

			byte[] b;

			calculated_ptr_list.Clear();


			// Header
			writer.Write( (byte)'N' );
			writer.Write( (byte)'X' );
			writer.Write( (byte)'R' );
			writer.Write( (byte)0 );

			writer.Write( (int)0 );  // Size
			writer.Write( (int)0 );  // Ptr To Lookup Table

			// BEGIN WRITING
			writer.Write( (int)0 );

			// Temporary Flag Strings
			List<int> temp_flag_offset = new List<int>();
			WriteFlags( temporary_flags, temp_flag_offset );

			// Numeric Flag Strings
			List<int> numeric_flag_offset = new List<int>();
			WriteFlags( numeric_flags, numeric_flag_offset );

			// Boolean Flag Strings
			List<int> boolean_flag_offset = new List<int>();
			WriteFlags( boolean_flags, boolean_flag_offset );


			// Mission Clear Tasks
			int ptr_clear_rank_tasks = (int)stream.Position;
			foreach( var data in clear_score_tasks )
			{
				writer.Write( data.type );
				writer.Write( data.unk_a );
				writer.Write( data.npc );
				writer.Write( data.nb_points_required );
				writer.Write( data.maximum_penalty );
				writer.Write( data.nb_required );
				writer.Write( data.nb_points_per_penalty );
				writer.Write( data.nb_flag );
				writer.Write( data.required_flag );
				writer.Write( data.unk_b );
				writer.Write( data.unk_c );
				writer.Write( data.unk_d );
				writer.Write( data.unk_e );

				for( int j = 0; j < 8; j++ )
				{
					writer.Write( data.map_required_flag[ j ] );
				}
			}

			// Mission Clear Reward Condition Stack
			List<int> clear_reward_condition_offsets = new List<int>();
			for( int i = 0; i < quest_items.Count; i++ )
			{
				var data = quest_items[ (byte)i ];

				if( data.conditions.Count < 1 )
				{
					continue;
				}

				// Stack
				int ptr_ops_offset = (int)stream.Position;

				foreach( int op in data.conditions )
				{
					writer.Write( op );
				}

				// Stack Lookup Ptr
				clear_reward_condition_offsets.Add( (int)stream.Position );

				WritePointer( ptr_ops_offset );
				writer.Write( data.conditions.Count );
			}

			// Offsets to Clear Reward Ptr Lists
			int ptr_clear_reward_conditions_lookup = (int)stream.Position;
			for( int i = 0; i < clear_reward_condition_offsets.Count; i++ )
			{
				writer.Write( (int)i );
				WritePointer( clear_reward_condition_offsets[ i ] );
			}

			// Ranking Header
			int ptr_ranking_header = 0;
			if( clear_score_tasks.Count > 0 )
			{
				ptr_ranking_header = (int)stream.Position;
				WritePointer( ptr_clear_rank_tasks );
				writer.Write( clear_score_tasks.Count );

				WritePointer( ptr_clear_reward_conditions_lookup );
				writer.Write( clear_reward_condition_offsets.Count );

				// Required Points to Qualify for C, B, A, or S
				for( int i = 0; i < 4; i++ )
				{
					writer.Write( clear_rank_required_points[ i ] );
				}

				// Mission Points Rewarded for each clear rank
				for( int i = 0; i < 4; i++ )
				{
					writer.Write( clear_rank_mission_points[ i ] );
				}

				writer.Write( (int)0 );   // Unknown
			}

			int ptr_quest_item_list = (int)stream.Position;
			for( int i = 0; i < quest_items.Count; i++ )
			{
				var data = quest_items[ (byte)i ];

				writer.Write( data.item_index); 
				writer.Write( data.item_id );
				writer.Write( data.element );
				writer.Write( data.min_element_percent );
				writer.Write( data.quantity );
				writer.Write( data.reward_type );
				writer.Write( data.element_type );
				writer.Write( data.max_element_percent );
				writer.Write( data.meseta );
			}

			int ptr_quest_item_lookup = 0;
			if( quest_items.Count > 0 )
			{
				ptr_quest_item_lookup = (int)stream.Position;
				WritePointer( ptr_quest_item_list );
				writer.Write( quest_items.Count );
			}

			// Zone Set Probability
			for( int i = 0; i < ZoneData.Count; i++ )
			{
				var zone = ZoneData.ElementAt( i ).Value;

				int ptr_set_probability = (int)stream.Position;

				foreach( var probability in zone.set_probability )
				{
					writer.Write( probability );
				}

				// Set Probability Lookup
				zone.ptr_set_probability_ptr = (int)stream.Position;
				{
					WritePointer( ptr_set_probability );
					writer.Write( zone.set_probability.Count );
				}
			}

			// Map List Data
			for( int i = 0; i < ZoneData.Count; i++ )
			{
				var zone = ZoneData.ElementAt( i ).Value;

				if( zone.map_list.Count > 0 )
				{
					zone.ptr_map_list = (int)stream.Position;

					foreach( short map_id in zone.map_list )
					{
						writer.Write( map_id );
					}

					// We need to pad to 4 bytes with FFFF(?)
					if( zone.map_list.Count % 2 > 0 )
					{
						writer.Write( (ushort)0xFFFF );
					}
				}
				else
				{
					zone.ptr_map_list = 0;
				}
			}

			// Stat Modifiers
			for( int i = 0; i < ZoneData.Count; i++ )
			{
				var zone = ZoneData.ElementAt( i ).Value;

				if( 0 == zone.enemy_stat_modifier.stat[ 0 ] )
				{
					zone.ptr_enemy_stat_modifier = 0;
				}
				else
				{
					// Enemy Stat Modifier
					zone.ptr_enemy_stat_modifier = (int)stream.Position;

					//writer.Write( zone.enemy_stat_modifier.monster_type );

					b = new byte[ 4 ];
					zone.enemy_stat_modifier.monster_type.CopyTo( b, 0 );
					writer.Write( b );

					for( int j = 0; j < 12; j++ )
					{
						writer.Write( zone.enemy_stat_modifier.stat[ j ] );
					}
				}

				if( 0 == zone.boss_stat_modifier.stat[ 0 ] )
				{
					zone.ptr_boss_stat_modifier = 0;
				}
				else
				{

					zone.ptr_boss_stat_modifier = (int)stream.Position;
					//writer.Write( zone.boss_stat_modifier.monster_type );

					b = new byte[ 4 ];
					zone.boss_stat_modifier.monster_type.CopyTo( b, 0 );
					writer.Write( b );

					for( int j = 0; j < 12; j++ )
					{
						writer.Write( zone.boss_stat_modifier.stat[ j ] );
					}
				}
			}

			// Zone Lookup Entries
			int ptr_zone_data = (int)stream.Position;
			for( int i = 0; i < ZoneData.Count; i++ )
			{
				var zone = ZoneData.ElementAt( i ).Value;

				writer.Write( zone.zone_number );
				writer.Write( zone.area_code );
				writer.Write( zone.area_code_other );
				writer.Write( zone.unk_a );   // Always 0?
				writer.Write( zone.monster_level );
				writer.Write( zone.unk_b );   // FF
				writer.Write( zone.unk_c );   // 04010000

				WritePointer( zone.ptr_set_probability_ptr );
				WritePointer( zone.ptr_map_list );
				writer.Write( zone.map_list.Count );
				WritePointer( zone.ptr_enemy_stat_modifier );
				WritePointer( zone.ptr_boss_stat_modifier );

				writer.Write( new byte[0x1C] );   // 0x1C Bytes Redundant space
			}

			// Warp Pair Data
			int ptr_warp_pair_data = (int)stream.Position;
			foreach( var warp in WarpPairList )
			{
				writer.Write( warp.Item1.quest_id );
				writer.Write( warp.Item1.zone_id );
				writer.Write( warp.Item1.map_id );
				writer.Write( warp.Item1.entrance_id );

				writer.Write( warp.Item2.quest_id );
				writer.Write( warp.Item2.zone_id );
				writer.Write( warp.Item2.map_id );
				writer.Write( warp.Item2.entrance_id );
			}

			// Trial Selectable Conditions
			int ptr_select_condition = 0;
			WriteTrialCondition( trial_select_condition, ref ptr_select_condition );

			int ptr_trial_start_condition = 0;
			WriteTrialCondition( trial_start_condition, ref ptr_trial_start_condition );

			int ptr_trial_clear_condition = 0;
			WriteTrialCondition( trial_clear_condition, ref ptr_trial_clear_condition );

			int ptr_trial_fail_condition = 0;
			WriteTrialCondition( trial_failed_condition, ref ptr_trial_fail_condition );

			int ptr_visible_condition = 0;
			WriteTrialCondition( trial_visible_condition, ref ptr_visible_condition );

			int ptr_trial_end_condition = 0;
			WriteTrialCondition( trial_end_condition, ref ptr_trial_end_condition );

			// Counter Path Nodes
			int ptr_path_nodes = 0;
			if( counter_path_node.Count > 0 )
			{
				ptr_path_nodes = (int)stream.Position;

				foreach( var node in counter_path_node )
				{
					writer.Write( node.Item1 );   // X
					writer.Write( node.Item2 );   // Y
				}
			}

			// Temporary Flags Ptr List
			int ptr_temporary_flag_ptr_list = 0;
			if( temp_flag_offset.Count > 0 )
			{
				ptr_temporary_flag_ptr_list = (int)stream.Position;

				foreach( var offset in temp_flag_offset )
				{
					WritePointer( offset );
				}
			}

			// Numeric Flags Ptr List
			int ptr_numeric_flag_ptr_list = 0;
			if( numeric_flag_offset.Count > 0 )
			{
				ptr_numeric_flag_ptr_list = (int)stream.Position;

				foreach( var offset in numeric_flag_offset )
				{
					WritePointer( offset );
				}
			}

			// Boolean Flags Ptr List
			int ptr_boolean_flag_ptr_list = 0;
			if( boolean_flag_offset.Count > 0 )
			{
				ptr_boolean_flag_ptr_list = (int)stream.Position;

				foreach( var offset in boolean_flag_offset )
				{
					WritePointer( offset );
				}
			}

			// NPC ID List
			int ptr_npc_id = 0;
			if( npc_list.Count > 0 )
			{
				ptr_npc_id = (int)stream.Position;

				foreach( var npc_id in npc_list )
				{
					writer.Write( npc_id );
				}
			}

			// Custom NPC Data
			int ptr_custom_npc_data = 0;
			if( custom_npc_list.Count > 0 )
			{
				ptr_custom_npc_data = (int)stream.Position;

				foreach( var data in custom_npc_list )
				{
					writer.Write( data.npc_id );
					writer.Write( data.data );
				}
			}

			// Quest Data
			int ptr_main_table = (int)stream.Position;
			writer.Write( quest_version );
			writer.Write( (short)0x0006 );	//0600
			writer.Write( time_stamp );
			writer.Write( quest_id );

			WritePointer( ptr_zone_data );
			writer.Write( ZoneData.Count );

			WritePointer( ptr_warp_pair_data );
			writer.Write( WarpPairList.Count );

			WriteWarpData( entrance_warp );
			WriteWarpData( exit_warp );

			// Likely mission flags are 16 bytes (4 used and 12 of reserved space)
			///writer.Write( bit_flag );
			//writer.Write( new byte[12] );

			b = new byte[ 16 ];
			mission_flags.CopyTo( b, 0 );
			writer.Write( b );

			WritePointer( ptr_select_condition );
			WritePointer( ptr_trial_start_condition );
			WritePointer( ptr_trial_clear_condition );
			WritePointer( ptr_trial_fail_condition );
			WritePointer( ptr_trial_end_condition );

			writer.Write( unk_c );  // Unknown (used in Forest of Illusion)
			writer.Write( area_icon );
			writer.Write( unk_d );

			writer.Write( minimum_party_size );
			writer.Write( maximum_party_size );

			writer.Write( map_x );
			writer.Write( map_y );

			writer.Write( (short)0 );

			WritePointer( ptr_quest_item_lookup );

			WriteWarpData( failed_warp );

			WritePointer( ptr_ranking_header );

			writer.Write( (int)0 );

			WritePointer( ptr_path_nodes );
			writer.Write( (short)counter_path_node.Count );

			writer.Write( unk_g );

			WritePointer( ptr_visible_condition );
			WritePointer( ptr_temporary_flag_ptr_list );
			WritePointer( ptr_numeric_flag_ptr_list );
			WritePointer( ptr_boolean_flag_ptr_list );

			writer.Write( (byte)temporary_flags.Count );
			writer.Write( (byte)numeric_flags.Count );
			writer.Write( (byte)boolean_flags.Count );
			writer.Write( (byte)npc_list.Count );

			WritePointer( ptr_npc_id );

			writer.Write( unk_h );	// 00000100
			writer.Write( unk_i );	// 00000100	(00000200 for Innocent Girl)

			writer.Write( custom_npc_list.Count );
			WritePointer( ptr_custom_npc_data );

			writer.Write( new byte[ 84 ] );    // Unknown, always 00

			// NPC Data
			writer.Write( new byte[ 20 ] );

			// Finalize
			int size = (int)stream.Position - 8; // - 8 for signature and size.
			stream.Seek( 0x04, SeekOrigin.Begin );
			writer.Write( size );
			writer.Write( ptr_main_table );

			calculatedPointers = calculated_ptr_list.ToArray();
			return stream.ToArray();

			//return backupRaw;
		}
	}

}

