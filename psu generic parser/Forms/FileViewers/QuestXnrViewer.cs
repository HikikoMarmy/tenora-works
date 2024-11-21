using PSULib.FileClasses.Missions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using System.Windows.Interop;
using static PSULib.FileClasses.Maps.ObjectParamFile;
using System.Runtime.InteropServices;
using static psu_generic_parser.Forms.FileViewers.QuestXnrViewer;

namespace psu_generic_parser.Forms.FileViewers
{
	public partial class QuestXnrViewer : UserControl
	{
		List<string> _quest_item_type = new List<string>()
		{
			"00: V1",
			"01: Exchange Trade",
			"02: -",
			"03: -",
			"04: -",
			"05: Meseta",
			"06: -",
			"07: -",
			"08: Event Item(1)",
			"09: Event Item(2)",
			"0A: -",
			"0B: -",
			"0C: -",
			"0D: -",
			"0E: -",
			"0F: -",
			"10: Quest Item (Component)",
			"11: -",
			"12: -",
			"13: -",
			"14: Quest Item (Standard)"
		};

		List<string> _element_type = new List<string>()
		{
			"00: Neutral",
			"01: Fire",
			"02: Ice",
			"03: Electric",
			"04: Ground",
			"05: Light",
			"06: Dark"
		};

		List<string> _stat_type = new List<string>()
		{
			"HP",
			"ATP",
			"DFP",
			"ATA",
			"EVP",
			"STA",
			"LUK",
			"TP",
			"MST",
			"UNK",
			"EXP",
			"SPD"
		};

		// Really should move this trial condition stuff into a new file.
		public class ConditionOp
		{
			public int OpCode = 0;
			public string OpName = "";
			public int ArgCount = 0;
			public int[] Arg = new int[4];
		}

		readonly static Dictionary<int, ConditionOp> _condition_op_lookup = new Dictionary<int, ConditionOp>()
		{
			{ 0x00, new ConditionOp{ OpCode = 0x00, OpName = "AND" } },
			{ 0x01, new ConditionOp{ OpCode = 0x01, OpName = "OR" } },
			{ 0x02, new ConditionOp{ OpCode = 0x02, OpName = "Test Equal" } },
			{ 0x03, new ConditionOp{ OpCode = 0x03, OpName = "Test Less Than" } },
			{ 0x04, new ConditionOp{ OpCode = 0x04, OpName = "Test Less or Equal" } },
			{ 0x05, new ConditionOp{ OpCode = 0x05, OpName = "Test Greater" } },
			{ 0x06, new ConditionOp{ OpCode = 0x06, OpName = "Test Greater or Equal" } },
	 
			{ 0x64, new ConditionOp{ OpCode = 0x64, OpName = "Push Integer", ArgCount = 1 }},
			{ 0x65, new ConditionOp{ OpCode = 0x65, OpName = "Account Flag Status", ArgCount = 1 }},
			{ 0x66, new ConditionOp{ OpCode = 0x66, OpName = "Account Flag Exist", ArgCount = 1 }},
			{ 0x67, new ConditionOp{ OpCode = 0x67, OpName = "Unknown_67", ArgCount = 1 }},
			{ 0x68, new ConditionOp{ OpCode = 0x68, OpName = "Unknown_68", ArgCount = 1 }},
			{ 0x69, new ConditionOp{ OpCode = 0x69, OpName = "Numeric Value", ArgCount = 1 }},
			{ 0x6A, new ConditionOp{ OpCode = 0x6A, OpName = "Numeric Value_6A(???)", ArgCount = 1 }},
			{ 0x6B, new ConditionOp{ OpCode = 0x6B, OpName = "Numeric Value_6B(???)", ArgCount = 1 }},
			{ 0x6C, new ConditionOp{ OpCode = 0x6C, OpName = "Unknown_6C", ArgCount = 1 } },
			{ 0x6D, new ConditionOp{ OpCode = 0x6D, OpName = "Unknown_6D", ArgCount = 1 } },	
			{ 0x6E, new ConditionOp{ OpCode = 0x6E, OpName = "Boolean Flag (Ptr)", ArgCount = 1 } },		
			{ 0x6F, new ConditionOp{ OpCode = 0x6F, OpName = "Unknown_6F", ArgCount = 1 } },		
			{ 0x70, new ConditionOp{ OpCode = 0x70, OpName = "Unknown_70", ArgCount = 1 } },		
			{ 0x71, new ConditionOp{ OpCode = 0x71, OpName = "Unknown_71", ArgCount = 1 } },		
			{ 0x72, new ConditionOp{ OpCode = 0x72, OpName = "NOP", ArgCount = 0 } },		
			{ 0x73, new ConditionOp{ OpCode = 0x73, OpName = "NOP", ArgCount = 0 } },		
			{ 0x74, new ConditionOp{ OpCode = 0x74, OpName = "NOP", ArgCount = 0 } },		
			{ 0x75, new ConditionOp{ OpCode = 0x75, OpName = "NOP", ArgCount = 0 } },		
			{ 0x76, new ConditionOp{ OpCode = 0x76, OpName = "Character Flag ", ArgCount = 1 } },		
			{ 0x77, new ConditionOp{ OpCode = 0x77, OpName = "Party Flag", ArgCount = 1 } },		
			{ 0x78, new ConditionOp{ OpCode = 0x78, OpName = "Map Flag", ArgCount = 3 } },		
			{ 0x79, new ConditionOp{ OpCode = 0x79, OpName = "Party Leader Level", ArgCount = 0 } },		
			{ 0x7A, new ConditionOp{ OpCode = 0x7A, OpName = "Party Min Level", ArgCount = 0 } },		
			{ 0x7B, new ConditionOp{ OpCode = 0x7B, OpName = "Party Max Level", ArgCount = 0 } },		
			{ 0x7C, new ConditionOp{ OpCode = 0x7C, OpName = "Unknown_7C", ArgCount = 2 } },		
			{ 0x7D, new ConditionOp{ OpCode = 0x7D, OpName = "Unknown_7D", ArgCount = 2 } },		
			{ 0x7E, new ConditionOp{ OpCode = 0x7E, OpName = "Unknown_7E", ArgCount = 2 } },		
			{ 0x7F, new ConditionOp{ OpCode = 0x7F, OpName = "Unknown_7F", ArgCount = 1 } },		
			{ 0x80, new ConditionOp{ OpCode = 0x80, OpName = "Unknown_80", ArgCount = 1 } },		
			{ 0x81, new ConditionOp{ OpCode = 0x81, OpName = "Unknown_81", ArgCount = 1 } },		
			{ 0x82, new ConditionOp{ OpCode = 0x82, OpName = "Unknown_82", ArgCount = 1 } },		
			{ 0x83, new ConditionOp{ OpCode = 0x83, OpName = "Unknown_83", ArgCount = 1 } },		
			{ 0x84, new ConditionOp{ OpCode = 0x84, OpName = "APC Count", ArgCount = 0 } },		
			{ 0x85, new ConditionOp{ OpCode = 0x85, OpName = "APC Present", ArgCount = 1 } },		
			{ 0x86, new ConditionOp{ OpCode = 0x86, OpName = "Is Map Visited", ArgCount = 3 } },		
			{ 0x87, new ConditionOp{ OpCode = 0x87, OpName = "Is Target Area", ArgCount = 3 } },		
			{ 0x88, new ConditionOp{ OpCode = 0x88, OpName = "All Character Sum(???)", ArgCount = 0 } },		
			{ 0x89, new ConditionOp{ OpCode = 0x89, OpName = "Unknown_89", ArgCount = 1 } },		
			{ 0x8A, new ConditionOp{ OpCode = 0x8A, OpName = "Monster Kill Count", ArgCount = 0 } },		
			{ 0x8B, new ConditionOp{ OpCode = 0x8B, OpName = "Current Map Number", ArgCount = 0 } },		
			{ 0x8C, new ConditionOp{ OpCode = 0x8C, OpName = "Unknown_8C", ArgCount = 0 } },		
			{ 0x8D, new ConditionOp{ OpCode = 0x8D, OpName = "Trial Start Status", ArgCount = 0 } },		
			{ 0x8E, new ConditionOp{ OpCode = 0x8E, OpName = "Trial End Status", ArgCount = 0 } },		
			{ 0x8F, new ConditionOp{ OpCode = 0x8F, OpName = "Unknown_8F", ArgCount = 0 } },		
			{ 0x90, new ConditionOp{ OpCode = 0x90, OpName = "Character Flag", ArgCount = 0 } },		
			{ 0x91, new ConditionOp{ OpCode = 0x91, OpName = "Unknown_91", ArgCount = 0 } },		
			{ 0x92, new ConditionOp{ OpCode = 0x92, OpName = "Character Death Status", ArgCount = 0 } },		
			{ 0x93, new ConditionOp{ OpCode = 0x93, OpName = "Clear Rank", ArgCount = 0 } },		
			{ 0x94, new ConditionOp{ OpCode = 0x94, OpName = "Clear Flag", ArgCount = 0 } },		
			{ 0x95, new ConditionOp{ OpCode = 0x95, OpName = "Clear Rank (Reverse)", ArgCount = 0 } },		
			{ 0x96, new ConditionOp{ OpCode = 0x96, OpName = "Clear Rank (???)", ArgCount = 0 } },		
			{ 0x97, new ConditionOp{ OpCode = 0x97, OpName = "Random Number (Max+1)", ArgCount = 1 } },		
			{ 0x98, new ConditionOp{ OpCode = 0x98, OpName = "Unknown_98", ArgCount = 0 } },		
			{ 0x99, new ConditionOp{ OpCode = 0x99, OpName = "Unknown_99", ArgCount = 0 } },		
			{ 0x9A, new ConditionOp{ OpCode = 0x9A, OpName = "Unknown_9A", ArgCount = 0 } },
			{ 0x9B, new ConditionOp{ OpCode = 0x9B, OpName = "Unknown_9B", ArgCount = 0 } }
		};

		ConditionOp GetConditionOpByName( string name )
		{
			foreach( var op in _condition_op_lookup )
			{
				if( op.Value.OpName != name )
					continue;

				return _condition_op_lookup[ op.Key ];
			}

			return null;
		}

		bool CompileTrialCondition( ref List<int> compiledList )
		{
			if( dataGridViewTrialCondition.Rows.Count == 0 )
			{
				return false;
			}

			try
			{
				foreach( DataGridViewRow row in dataGridViewTrialCondition.Rows )
				{
					// Operator ID
					if( row.Cells[ 0 ].Value == null )
					{
						continue;
					}

					var CurrentOp = GetConditionOpByName( row.Cells[ 0 ].Value.ToString() );

					if( null == CurrentOp )
					{
						return false;
					}

					compiledList.Add( CurrentOp.OpCode );

					for( int i = 0; i < CurrentOp.ArgCount; i++ )
					{
						if( row.Cells[ 1 + i ].Value == null )
						{
							return false;
						}

						compiledList.Add( Int32.Parse( row.Cells[ 1 + i ].Value.ToString() ) );
					}
				}
			}
			catch( Exception ex )
			{
				return false;
			}

			return true;
		}


		
		QuestXNRFile xnr;
		QuestXNRFile.ZoneEntry currentZone = null;
		bool updating = false;

		public QuestXnrViewer( QuestXNRFile file )
		{
			InitializeComponent();

			foreach( var op in _condition_op_lookup )
			{
				TrialOpCodeColumn.Items.Add( op.Value.OpName );
			}

			updating = true;
			xnr = file;

			numQuestID.Value = ( xnr.quest_id / 100 );
			numQuestDifficulty.Value = ( xnr.quest_id % 10 );
			numQuestVariant.Value = ( ( xnr.quest_id % 100) - numQuestDifficulty.Value) / 10;

			numAreaIcon.Value = xnr.area_icon;

			numMapX.Value = xnr.map_x;
			numMapY.Value = xnr.map_y;

			numPartyMin.Value = xnr.minimum_party_size;
			numPartyMax.Value = xnr.maximum_party_size;

			int calculatedFlagOffset = 0;
			// Flags
			foreach( var flag in xnr.temporary_flags )
			{
				dataGridViewTemporaryFlags.Rows.Add( calculatedFlagOffset, flag );
				calculatedFlagOffset += 16;
			}

			foreach( var flag in xnr.numeric_flags )
			{
				dataGridViewNumericFlags.Rows.Add( calculatedFlagOffset, flag );
				calculatedFlagOffset += 16;
			}

			foreach( var flag in xnr.boolean_flags )
			{
				dataGridViewBooleanFlags.Rows.Add( calculatedFlagOffset, flag );
				calculatedFlagOffset += 16;
			}

			// Quest Items
			foreach( var item in xnr.quest_items )
			{
				dataGridViewQuestItem.Rows.Add(
					item.item_index,
					ToItemID( item.item_id ),
					_quest_item_type.ElementAt( item.reward_type ),
					_element_type.ElementAt( item.element ),
					item.element_type,
					item.min_element_percent,
					item.max_element_percent,
					item.quantity,
					item.meseta );
			}

			// Warp Data
			foreach( var warp in xnr.WarpPairList )
			{
				dataGridViewWarpData.Rows.Add(
					warp.Item1.quest_id, warp.Item1.zone_id, warp.Item1.map_id, warp.Item1.entrance_id,
					warp.Item2.quest_id, warp.Item2.zone_id, warp.Item2.map_id, warp.Item2.entrance_id );
			}

			// Zone
			int zone_idx = 0;
			foreach( var zone in xnr.ZoneData )
			{
				zone_idx++;
				listBoxZones.Items.Add( "[" + zone_idx.ToString( "D2" ) + "]: Zone " + zone.Value.zone_number.ToString( "D2" ) );
			}

			updating = false;

			if( listBoxZones.Items.Count > 0 )
			{
				listBoxZones.SelectedIndex = 0;
			}

			//Default Warps
			this.numWarpEntryQuestID.Value = xnr.entrance_warp.quest_id;
			this.numWarpEntryZoneID.Value = xnr.entrance_warp.zone_id;
			this.numWarpEntryMapID.Value = xnr.entrance_warp.map_id;
			this.numWarpEntryEntranceID.Value = xnr.entrance_warp.entrance_id;

			this.numWarpExitQuestID.Value = xnr.exit_warp.quest_id;
			this.numWarpExitZoneID.Value = xnr.exit_warp.zone_id;
			this.numWarpExitMapID.Value = xnr.exit_warp.map_id;
			this.numWarpExitEntranceID.Value = xnr.exit_warp.entrance_id;

			this.numWarpFailQuestID.Value = xnr.failed_warp.quest_id;
			this.numWarpFailZoneID.Value = xnr.failed_warp.zone_id;
			this.numWarpFailMapID.Value = xnr.failed_warp.map_id;
			this.numWarpFailEntranceID.Value = xnr.failed_warp.entrance_id;

		}

		string ToItemID( uint id )
		{
			uint item_id = ( id & 0x000000FFU ) << 24 | ( id & 0x0000FF00U ) << 8 |
					( id & 0x00FF0000U ) >> 8 | ( id & 0xFF000000U ) >> 24;

			return item_id.ToString( "X8" );
		}

		uint ToItemID( string id )
		{
			uint item_id = UInt32.Parse( id, System.Globalization.NumberStyles.HexNumber );
			return ( item_id & 0x000000FFU ) << 24 | ( item_id & 0x0000FF00U ) << 8 |
					( item_id & 0x00FF0000U ) >> 8 | ( item_id & 0xFF000000U ) >> 24;
		}

		void MakeQuestID()
		{
			if(updating)
			{
				return;
			}

			int questID = (int)numQuestID.Value;
			int questVar = (int)numQuestVariant.Value;
			int questDiff = (int)numQuestDifficulty.Value;

			xnr.quest_id = (questID * 100 ) + ( questVar * 10 ) + questDiff; 
		}

		void SetToZone( int zone_id )
		{
			if( zone_id < 0 || zone_id >= xnr.ZoneData.Count )
			{
				return;
			}

			currentZone = xnr.ZoneData.ElementAt( zone_id ).Value;

			numZoneId.Value = currentZone.zone_number;
			comboZoneArea.SelectedIndex = currentZone.area_code;

			numMonsterLevel.Value = currentZone.monster_level;

			dataGridViewEnemyStatModifier.Rows.Clear();
			dataGridViewBossStatModifier.Rows.Clear();

			for( int i = 0; i < 11; i++ )
			{
				dataGridViewEnemyStatModifier.Rows.Add( _stat_type[ i ], ( currentZone.enemy_stat_modifier.stat[ i ] * 100 ) / 512 );
				dataGridViewBossStatModifier.Rows.Add( _stat_type[ i ], ( currentZone.boss_stat_modifier.stat[ i ] * 100 ) / 512 );
			}

			dataGridViewEnemyStatModifier.Rows.Add( _stat_type[ 11 ], currentZone.enemy_stat_modifier.stat[ 11 ] );
			dataGridViewBossStatModifier.Rows.Add( _stat_type[ 11 ], currentZone.boss_stat_modifier.stat[ 11 ] );

			chk_enemy_stat_default.Checked = currentZone.enemy_stat_modifier.monster_type.Get( 0 );
			chk_enemy_stat_fire.Checked = currentZone.enemy_stat_modifier.monster_type.Get( 1 );
			chk_enemy_stat_ice.Checked = currentZone.enemy_stat_modifier.monster_type.Get( 2 );
			chk_enemy_stat_electric.Checked = currentZone.enemy_stat_modifier.monster_type.Get( 3 );
			chk_enemy_stat_ground.Checked = currentZone.enemy_stat_modifier.monster_type.Get( 4 );
			chk_enemy_stat_light.Checked = currentZone.enemy_stat_modifier.monster_type.Get( 5 );
			chk_enemy_stat_dark.Checked = currentZone.enemy_stat_modifier.monster_type.Get( 6 );
			chk_enemy_stat_spd.Checked = currentZone.enemy_stat_modifier.monster_type.Get( 31 );

			chk_boss_stat_default.Checked = currentZone.boss_stat_modifier.monster_type.Get( 0 );
			chk_boss_stat_spd.Checked = currentZone.boss_stat_modifier.monster_type.Get( 31 );

			dataGridViewSetProbability.Rows.Clear();
			foreach( var pro in currentZone.set_probability )
			{
				dataGridViewSetProbability.Rows.Add( pro.ToString() );
			}

			dataGridViewMapList.Rows.Clear();
			foreach( var map_id in currentZone.map_list )
			{
				dataGridViewMapList.Rows.Add( map_id.ToString() );
			}
		}

		// QUEST
		private void numQuestID_ValueChanged(object sender, EventArgs e)
		{
			MakeQuestID();
		}

		private void numQuestVariant_ValueChanged(object sender, EventArgs e)
		{
			MakeQuestID();
		}

		private void numQuestDifficulty_ValueChanged(object sender, EventArgs e)
		{
			MakeQuestID();
		}

		private void numAreaIcon_ValueChanged(object sender, EventArgs e)
		{
			xnr.area_icon = (short)numAreaIcon.Value;
		}

		private void numMapX_ValueChanged(object sender, EventArgs e)
		{
			xnr.map_x = (short)numMapX.Value;
		}

		private void numMapY_ValueChanged(object sender, EventArgs e)
		{
			xnr.map_y = (short)numMapY.Value;
		}

		private void numPartyMin_ValueChanged(object sender, EventArgs e)
		{
			xnr.minimum_party_size = (byte)numPartyMin.Value;
		}

		private void numPartyMax_ValueChanged(object sender, EventArgs e)
		{
			xnr.maximum_party_size = (byte)numPartyMax.Value;
		}


		// ZONE
		private void numZoneId_ValueChanged( object sender, EventArgs e )
		{
			if( updating || null == currentZone )
			{
				return;
			}

			int curIndex = listBoxZones.SelectedIndex;
			var zone_data = xnr.ZoneData.ElementAt( curIndex ).Value;
			zone_data.zone_number = (ushort)numZoneId.Value;
			listBoxZones.Items[ curIndex ] = "[" + curIndex.ToString( "D2" ) + "]: Zone " + zone_data.zone_number.ToString( "D2" );
		}

		private void comboZoneArea_SelectedIndexChanged( object sender, EventArgs e )
		{
			if( updating || null == currentZone )
			{
				return;
			}

			currentZone.area_code = (ushort)comboZoneArea.SelectedIndex;
			currentZone.area_code_other = currentZone.area_code;
		}

		private void newZoneToolStripMenuItem_Click(object sender, EventArgs e)
		{
			List<ushort> zoneIds = new List<ushort>();
			ushort zone_index = 0;
			ushort new_zone_id = 0;
			int curIndex = listBoxZones.SelectedIndex;

			foreach( var zone in xnr.ZoneData )
			{
				zoneIds.Add( zone.Key );
			}

			zoneIds.Sort();

			for( int i = 0; i < zoneIds.Count; i++, new_zone_id++ )
			{
				if( new_zone_id != zoneIds[ i ] )
					break;
			}

			QuestXNRFile.ZoneEntry new_zone = new QuestXNRFile.ZoneEntry();
			new_zone.zone_number = new_zone_id;
			new_zone.area_code = 0;
			new_zone.area_code_other = 0;
			new_zone.monster_level = 1;
			new_zone.unk_b = 0xFF;
			new_zone.unk_c = 0x00000104;
			new_zone.nb_map = 0;
			new_zone.set_probability.Add( 100 );
			


			xnr.ZoneData.Add( new_zone_id, new_zone );

			listBoxZones.Items.Clear();
			
			foreach( var zone in xnr.ZoneData )
			{
				zone_index++;
				listBoxZones.Items.Add( zone_index.ToString( "D2" ) + ": Zone [" + zone.Value.zone_number.ToString( "D2" ) + "]" );
			}

			listBoxZones.SelectedIndex = curIndex;
		}

		private void deleteZoneToolStripMenuItem_Click(object sender, EventArgs e)
		{
			int curIndex = listBoxZones.SelectedIndex;

			if( curIndex == -1 )
			{
				return;
			}

			ushort zone_index = 0;

			var key = xnr.ZoneData.ElementAt( curIndex ).Key;
			xnr.ZoneData.Remove( key );

			listBoxZones.Items.Clear();

			foreach( var zone in xnr.ZoneData )
			{
				zone_index++;
				listBoxZones.Items.Add( zone_index.ToString( "D2" ) + ": Zone [" + zone.Value.zone_number.ToString( "D2" ) + "]" );
			}

			if( curIndex >= listBoxZones.Items.Count )
			{
				listBoxZones.SelectedIndex = listBoxZones.Items.Count - 1;
			}
			else
			{
				listBoxZones.SelectedIndex = curIndex;
			}
		}

		private void listBoxZones_SelectedIndexChanged(object sender, EventArgs e)
		{
			updating = true;
			{
				var selectIndex = listBoxZones.SelectedIndex;

				SetToZone( selectIndex );
			}
			updating = false;
		}

		private void listBoxZones_MouseDown(object sender, MouseEventArgs e)
		{
			listBoxZones.SelectedIndex = listBoxZones.IndexFromPoint( e.Location );
		}

		private void DataGridViewEnemyModifier_CellEndEdit( object sender, DataGridViewCellEventArgs e )
		{
			if( updating )
				return;

			var value = dataGridViewEnemyStatModifier.Rows[ e.RowIndex ].Cells[ 1 ].Value;

			if( value == null )
			{
				return;
			}

			if( false == UInt16.TryParse( value.ToString(), out  ushort stat ) )
			{
				return;
			}

			if( e.RowIndex == (int)QuestXNRFile.StatModEntry.EnumStatType.SPD )
			{
				currentZone.enemy_stat_modifier.stat[ e.RowIndex ] = stat;
			}
			else
			{
				currentZone.enemy_stat_modifier.stat[ e.RowIndex ] = (ushort)( 512 * ( stat * 0.01 ) );
			}
		}

		private void DataGridViewBossModifier_CellEndEdit( object sender, DataGridViewCellEventArgs e )
		{
			if( updating )
				return;

			var value = dataGridViewBossStatModifier.Rows[ e.RowIndex ].Cells[ 1 ].Value;

			if( value == null )
			{
				return;
			}

			if( false == UInt16.TryParse( value.ToString(), out ushort stat ) )
			{
				return;
			}

			if( e.RowIndex == (int)QuestXNRFile.StatModEntry.EnumStatType.SPD )
			{
				currentZone.boss_stat_modifier.stat[ e.RowIndex ] = stat;
			}
			else
			{
				currentZone.boss_stat_modifier.stat[ e.RowIndex ] = (ushort)( 512 * ( stat * 0.01 ) );
			}
		}

		private void DataGridViewMapList_CellEndEdit( object sender, DataGridViewCellEventArgs e )
		{
			if( updating )
				return;

			int currentIndex = e.RowIndex;
			var inValue = dataGridViewMapList.Rows[ e.RowIndex ].Cells[ e.ColumnIndex ].Value;

			if( inValue == null )
			{
				return;
			}

			if( e.RowIndex >= currentZone.map_list.Count )
			{
				currentZone.map_list.Add( 0 );
				currentIndex = currentZone.map_list.Count - 1;
			}

			if( false == Int16.TryParse( inValue.ToString(), out short map_id ) )
			{
				return;
			}

			currentZone.map_list[ currentIndex ] = map_id;
			dataGridViewMapList.Rows[ e.RowIndex ].Cells[ e.ColumnIndex ].Value = map_id.ToString();
		}

		private void DataGridViewMapList_UserDeletingRow( object sender, DataGridViewRowCancelEventArgs e )
		{
			if( updating )
				return;

			int currentIndex = e.Row.Index;
			if( currentIndex < 0 || currentIndex > currentZone.map_list.Count )
			{
				e.Cancel = true;
				return; 
			}

			currentZone.map_list.RemoveAt( currentIndex );
		}



		// WARP DATA
		private void DataGridViewWarpList_CellEndEdit( object sender, DataGridViewCellEventArgs e )
		{
			if( updating )
				return;

			int currentIndex = e.RowIndex;
			var currentRow = dataGridViewWarpData.Rows[ e.RowIndex ];

			if( currentRow == null )
			{
				return;
			}

			// New Entry, make a blank
			if( e.RowIndex >= xnr.WarpPairList.Count )
			{
				xnr.WarpPairList.Add( Tuple.Create( new QuestXNRFile.WarpPointEntry(), new QuestXNRFile.WarpPointEntry() ) );
				currentIndex = xnr.WarpPairList.Count - 1;
			}

			QuestXNRFile.WarpPointEntry warp_a = xnr.WarpPairList[ currentIndex ].Item1;
			QuestXNRFile.WarpPointEntry warp_b = xnr.WarpPairList[ currentIndex ].Item2;

			try
			{
				var value = currentRow.Cells[ e.ColumnIndex ].Value.ToString();
				switch( e.ColumnIndex )
				{
					case 0:
						warp_a.quest_id = Int32.Parse( value );
					break;

					case 1:
						warp_a.zone_id = Int16.Parse( value );
					break;

					case 2:
						warp_a.map_id = Int16.Parse( value );
					break;

					case 3:
						warp_a.entrance_id = Int32.Parse( value );
					break;

					case 4:
						warp_b.quest_id = Int32.Parse( value );
					break;

					case 5:
						warp_b.zone_id = Int16.Parse( value );
					break;

					case 6:
						warp_b.map_id = Int16.Parse( value );
					break;

					case 7:
						warp_b.entrance_id = Int32.Parse( value );
					break;
				}
			}
			catch( Exception )
			{

			}
			finally
			{
				xnr.WarpPairList[ currentIndex ] = Tuple.Create( warp_a, warp_b );
			}
		}

		private void DataGridViewWarpList_UserDeletingRow( object sender, DataGridViewRowCancelEventArgs e )
		{
			if( updating )
				return;

			int currentIndex = e.Row.Index;
			if( currentIndex < 0 || currentIndex > currentZone.map_list.Count )
			{
				e.Cancel = true;
				return;
			}

			currentZone.map_list.RemoveAt( currentIndex );
		}

		// REWARD ITEM
		private void DataGridViewQuestItem_RowPostPaint( object sender, DataGridViewRowPostPaintEventArgs e )
		{
			var grid = sender as DataGridView;
			var rowIdx = ( e.RowIndex + 1 ).ToString();

			var centerFormat = new StringFormat()
			{
				// right alignment might actually make more sense for numbers
				Alignment = StringAlignment.Center,
				LineAlignment = StringAlignment.Center
			};

			var headerBounds = new Rectangle( e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height );
			e.Graphics.DrawString( rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat );
		}

		private void DataGridViewQuestItem_CellEndEdit( object sender, DataGridViewCellEventArgs e )
		{
			if( updating )
				return;

			int currentIndex = e.RowIndex;
			var currentRow = dataGridViewQuestItem.Rows[ e.RowIndex ];

			if( currentRow == null )
			{
				return;
			}

			var currentCell = currentRow.Cells[ e.ColumnIndex ];

			if( currentCell == null )
			{
				return;
			}

			// New Entry, make a blank
			if( e.RowIndex >= xnr.quest_items.Count )
			{
				xnr.quest_items.Add( new QuestXNRFile.QuestItemEntry() );
				currentIndex = xnr.quest_items.Count - 1;
			}

			var itemData = xnr.quest_items[ currentIndex ];

			switch( e.ColumnIndex )
			{
				case 0:
				{
					Byte.TryParse( currentCell.Value.ToString(), out itemData.item_index );
				} break;

				case 1:
				{
					itemData.item_id = ToItemID( currentCell.Value.ToString() );
				}
				break;

				case 2:
				{
					itemData.reward_type = (byte)_quest_item_type.IndexOf( currentCell.Value.ToString() );
				}
				break;

				case 3:
				{
					itemData.element = (byte)_element_type.IndexOf( currentCell.Value.ToString() );
				}
				break;

				case 4:
				{
					UInt16.TryParse( currentCell.Value.ToString(), out itemData.element_type );
				}
				break;

				case 5:
				{
					Byte.TryParse( currentCell.Value.ToString(), out itemData.min_element_percent );
				}
				break;

				case 6:
				{
					Byte.TryParse( currentCell.Value.ToString(), out itemData.max_element_percent );
				}
				break;

				case 7:
				{
					Byte.TryParse( currentCell.Value.ToString(), out itemData.quantity );
				}
				break;

				case 8:
				{
					UInt32.TryParse( currentCell.Value.ToString(), out itemData.meseta );
				}
				break;
			}

		}

		// CONDITION DATA
		private void listBoxTrialConditions_SelectedIndexChanged( object sender, EventArgs e )
		{
			List<int> opList;
			switch( listBoxTrialConditions.SelectedIndex )
			{
				case 0: opList = xnr.trial_visible_condition; break;
				case 1: opList = xnr.trial_select_condition; break;
				case 2: opList = xnr.trial_start_condition; break;
				case 3: opList = xnr.trial_failed_condition; break;
				case 4: opList = xnr.trial_clear_condition; break;
				case 5: opList = xnr.trial_end_condition; break;

				default: return;
			}

			dataGridViewTrialCondition.Rows.Clear();
			
			for( int i = 0; i < opList.Count; i++ )
			{
				var opDefinition = _condition_op_lookup[ opList[i] ];
				int newRow = dataGridViewTrialCondition.Rows.Add( opDefinition.OpName );
			
				for( int j = 0; j < opDefinition.ArgCount; j++, i++ )
				{
					dataGridViewTrialCondition.Rows[ newRow ].Cells[ 1 + j ].Value = opList[ 1 + i ].ToString();
				}
			}
		}

		private void DataGridViewTrialCondition_CellEndEdit( object sender, DataGridViewCellEventArgs e )
		{
			if( updating )
				return;

			int errorCount = 0;
			var currentRow = dataGridViewTrialCondition.Rows[ e.RowIndex ];

			if( currentRow == null )
			{
				return;
			}

			if( currentRow.Cells[ 0 ].Value == null )
			{
				return;
			}

			ConditionOp currentOp = GetConditionOpByName( currentRow.Cells[ 0 ].Value.ToString() );

			if( null == currentOp )
			{
				return;
			}

			for( int i = 0; i < currentOp.ArgCount; i++ )
			{
				var argCell = dataGridViewTrialCondition.Rows[ e.RowIndex ].Cells[ 1 + i ];

				argCell.Style.BackColor = Color.White;

				if( null == argCell || null == argCell.Value )
				{
					argCell.Style.BackColor = Color.IndianRed;
					errorCount++;
					continue;
				}
				
				if( false == Int32.TryParse( argCell.Value.ToString(), out currentOp.Arg[ i ] ) )
				{
					argCell.Style.BackColor = Color.IndianRed;
					errorCount++;
					continue;
				}
			}

			if( errorCount > 0 )
			{
				return;
			}

			// Compile
			List<int> compileOpList = new List<int>();
			if( false == CompileTrialCondition( ref compileOpList ) )
			{
				return;
			}

			switch( listBoxTrialConditions.SelectedIndex )
			{
				case 0:
				xnr.trial_visible_condition = compileOpList;
				break;
				case 1:
				xnr.trial_select_condition = compileOpList;
				break;
				case 2:
				xnr.trial_start_condition = compileOpList;
				break;
				case 3:
				xnr.trial_failed_condition = compileOpList;
				break;
				case 4:
				xnr.trial_clear_condition = compileOpList;
				break;
				case 5:
				xnr.trial_end_condition = compileOpList;
				break;

				default:
				return;
			}
		}

		private void numMonsterLevel_ValueChanged( object sender, EventArgs e )
		{
			if( updating || null == currentZone )
			{
				return;
			}

			int curIndex = listBoxZones.SelectedIndex;
			var zone_data = xnr.ZoneData.ElementAt( curIndex ).Value;
			zone_data.monster_level = (byte)numMonsterLevel.Value;
		}

		private void numWarpEntryQuestID_ValueChanged( object sender, EventArgs e )
		{
			xnr.entrance_warp.quest_id = (int)numWarpEntryQuestID.Value;
		}

		private void numWarpExitQuestID_ValueChanged( object sender, EventArgs e )
		{
			xnr.exit_warp.quest_id = (int)numWarpExitQuestID.Value;
		}

		private void numWarpFailQuestID_ValueChanged( object sender, EventArgs e )
		{
			xnr.failed_warp.quest_id = (int)numWarpFailQuestID.Value;
		}

		private void numWarpEntryMapID_ValueChanged( object sender, EventArgs e )
		{
			xnr.entrance_warp.map_id = (short)numWarpEntryMapID.Value;
		}

		private void numWarpExitMapID_ValueChanged( object sender, EventArgs e )
		{
			xnr.exit_warp.map_id = (short)numWarpExitMapID.Value;
		}

		private void numWarpFailMapID_ValueChanged( object sender, EventArgs e )
		{
			xnr.failed_warp.map_id = (short)numWarpFailMapID.Value;
		}

		private void numWarpEntryZoneID_ValueChanged( object sender, EventArgs e )
		{
			xnr.entrance_warp.zone_id = (short)numWarpEntryZoneID.Value;
		}

		private void numWarpExitZoneID_ValueChanged( object sender, EventArgs e )
		{
			xnr.exit_warp.zone_id = (short)numWarpExitZoneID.Value;
		}

		private void numWarpFailZoneID_ValueChanged( object sender, EventArgs e )
		{
			xnr.failed_warp.zone_id = (short)numWarpFailZoneID.Value;
		}

		private void numWarpEntryEntranceID_ValueChanged( object sender, EventArgs e )
		{
			xnr.entrance_warp.entrance_id = (int)numWarpEntryEntranceID.Value;
		}

		private void numWarpExitEntranceID_ValueChanged( object sender, EventArgs e )
		{
			xnr.exit_warp.entrance_id = (int)numWarpExitEntranceID.Value;
		}

		private void numWarpFailEntranceID_ValueChanged( object sender, EventArgs e )
		{
			xnr.failed_warp.entrance_id = (int)numWarpFailEntranceID.Value;
		}
	}
}
