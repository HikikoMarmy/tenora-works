﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using PSULib.FileClasses;
using PSULib.FileClasses.Enemies;
using PSULib.FileClasses.Items;
using PSULib.FileClasses.Textures;
using PSULib.FileClasses.Missions;
using PSULib.FileClasses.Bosses;
using PSULib.FileClasses.Archives;
using PSULib.FileClasses.Characters;
using PSULib.FileClasses.Models;
using PSULib.FileClasses.Maps;
using System.Collections;

namespace PSULib.FileClasses.General
{
    public class PsuFiles
    {
        public static bool parseScripts = true; //Because you don't always want to parse script files.

        public delegate PsuFile FileParser(string filename, byte[] rawData, byte[] inHeader, int[] ptrs, int baseAddr, bool bigEndian = false);

        public static FileParser ExternalFromRaw { get; set; }

        //TODO: Proper 360 support for endian-aware file formats.
        public static PsuFile FromRaw(string filename, byte[] rawData, byte[] inHeader, int[] ptrs, int baseAddr, bool bigEndian = false)
        {
            if (ExternalFromRaw != null)
            {
                PsuFile tryExternal = ExternalFromRaw(filename, rawData, inHeader, ptrs, baseAddr, bigEndian);
                if (tryExternal != null)
                {
                    return tryExternal;
                }
            }

            string fileExtension = Path.GetExtension(filename);
            string subheaderIdentifier = inHeader != null ? Encoding.ASCII.GetString(inHeader, 0, 4) : "";

            if (filename.EndsWith("xvr"))
                return new XvrTextureFile(inHeader, rawData, filename);
            else if (filename.EndsWith(".uvr"))
                return new UvrTextureFile(inHeader, rawData, filename);
            else if (filename.EndsWith(".gim") && GimSharp.GimTexture.Is(rawData))
                return new GimTextureFile(inHeader, rawData, filename);
            else if (filename.Contains("Weapon.bin") || filename.Contains("General.bin") || filename.Contains("Other.bin"))
                return new Psp2TextFile(filename, rawData);
            else if (Regex.IsMatch(filename, "itemObjectDrop\\.[xs]nr"))
                return new ObjectDropFile(filename, rawData, inHeader, ptrs, baseAddr);
            else if (filename.Equals("filelist.rel"))
                return new QuestListFile(filename, rawData, inHeader, ptrs, baseAddr);
            else if (filename.EndsWith("filelist.rel"))
                return new ListFile(filename, rawData, inHeader, ptrs, baseAddr);
            else if (Regex.IsMatch(filename, "itemEnemyDrop\\.[xs]nr"))
            {
                try
                {
                    return new EnemyDropFile(filename, rawData, inHeader, ptrs, baseAddr);
                }
                catch (Exception)
                {
                    return new PointeredFile(filename, rawData, inHeader, ptrs, baseAddr, bigEndian);
                }
            }
            else if (Regex.IsMatch(filename, "^Param.*.[xsu]nr"))
            {
                try
                {
                    return new EnemyParamFile(filename, rawData, inHeader, ptrs, baseAddr);
                }
                catch (Exception)
                {
                    return new PointeredFile(filename, rawData, inHeader, ptrs, baseAddr, bigEndian);
                }
            }
            //Enemy mot tbl files look like MotTblAgeeta.xnr. Player ones look like MotTbl_11_Something.xnr
            else if (Regex.IsMatch(filename, @"^MotTbl[A-Za-z].*\.[xsu]nr"))
            {
                try
                {
                    return new EnemyMotTblFile(filename, rawData, inHeader, ptrs, baseAddr);
                }
                catch (Exception)
                {
                    return new PointeredFile(filename, rawData, inHeader, ptrs, baseAddr, bigEndian);
                }
            }
            else if (Regex.IsMatch(filename, @"^ActData[A-Za-z0-9].*\.[xsu]nr"))
            {
                try
                {
                    return new ActDataFile(filename, rawData, inHeader, ptrs, baseAddr);
                }
                catch (Exception)
                {
                    return new PointeredFile(filename, rawData, inHeader, ptrs, baseAddr, bigEndian);
                }
            }
            else if (Regex.IsMatch(filename, @"^DamageData[A-Za-z0-9].*\.[xsu]nr"))
            {
                try
                {
                    return new DamageDataFile(filename, rawData, inHeader, ptrs, baseAddr);
                }
                catch (Exception)
                {
                    return new PointeredFile(filename, rawData, inHeader, ptrs, baseAddr, bigEndian);
                }
            }
            //As far as I can tell, the enemy name is always capitalized.
            else if (Regex.IsMatch(filename, @"^Se[A-Z]\w+.[xsu]nr"))
            {
                try
                {
                    return new EnemySoundEffectFile(filename, rawData, inHeader, ptrs, baseAddr);
                }
                catch (Exception)
                {
                    return new PointeredFile(filename, rawData, inHeader, ptrs, baseAddr, bigEndian);
                }
            }
            else if (Regex.IsMatch(filename, "^AtkDat.*\\.[xsu]nr"))
            {
                return new AtkDatFile(filename, rawData, inHeader, ptrs, baseAddr);
            }
            else if (filename.StartsWith("obj_particle_info"))
            {
                return new ObjectParticleInfoFile(filename, rawData, inHeader, ptrs, baseAddr);
            }
            else if (filename.StartsWith("obj_param") || filename.StartsWith("npc_param"))
            {
                return new ObjectParamFile(filename, rawData, inHeader, ptrs, baseAddr);
            }
            else if (filename.Equals("LndCommon.rel"))
            {
                return new LndCommonFile(filename, rawData, inHeader, ptrs, baseAddr);
            }
            else if (filename.StartsWith("set_r") && fileExtension.Equals(".rel"))
                return new SetFile(filename, rawData, inHeader, ptrs, baseAddr, bigEndian);
            else if (Regex.IsMatch(filename, "\\.[uxs]nt"))
                return new XntFile(filename, rawData, inHeader, ptrs, baseAddr);
            else if (Regex.IsMatch(filename, "\\.[uxs]na"))
                return new XnaFile(filename, rawData, inHeader, ptrs, baseAddr);
            else if (parseScripts && (filename.Contains("script.bin") || filename.Contains("Tutor.bin")))
                return new ScriptFile(filename, rawData, bigEndian);
            else if ((filename.EndsWith(".k") || filename.Contains(".bin")) && BitConverter.ToInt32(rawData, 0) == rawData.Length && new string(Encoding.ASCII.GetChars(rawData, 0, 4)) != "RIPC")
                return new TextFile(filename, rawData);
            else if (filename.Contains("item00ValueData"))
                return new ItemPriceFile(filename, rawData, inHeader, ptrs, baseAddr);
            else if (filename.Contains("itemTechParam") && !filename.Contains("EnemyB"))
                return new ItemTechParamFile(filename, rawData, inHeader, ptrs, baseAddr);
            else if (filename.Contains("itemBulletParam") && !filename.Contains("MagAt"))
                return new ItemBulletParamFile(filename, rawData, inHeader, ptrs, baseAddr);
            else if (filename.StartsWith("Think") && Regex.IsMatch(filename, ".*Dragon\\.[uxs]nr"))
                return new ThinkDragonFile(filename, rawData, inHeader, ptrs, baseAddr);
            else if (filename.Contains("itemSkillParam"))
                return new ItemSkillParamFile(filename, rawData, inHeader, ptrs, baseAddr);
            else if (filename.Contains("itemLineUnitParam"))
                return new ItemUnitParamFile(filename, rawData, inHeader, ptrs, baseAddr);
            else if (filename.Contains(".nbl") || Encoding.ASCII.GetString(rawData, 0, 4) == "NMLL")
            {
                NblLoader toReturn = new NblLoader(new MemoryStream(rawData));
                toReturn.filename = filename;
                return toReturn;
            }
            else if (Encoding.ASCII.GetString(rawData, 0, 3) == "AFS")
            {
                return new AfsLoader(filename, new MemoryStream(rawData));
            }
            else if (Regex.IsMatch(filename, "enemy.._...._r.\\.(rel|[uxs]nr)"))
            {
                return new EnemyLayoutFile(filename, rawData, inHeader, ptrs, baseAddr);
            }
            else if (filename.Contains("itemWeaponParam"))
            {
                return new WeaponParamFile(filename, rawData, inHeader, ptrs, baseAddr);
            }
            else if (Regex.IsMatch(filename, "itemCommonInfo\\.[uxs]nr"))
            {
                return new ItemCommonInfoFile(filename, rawData, inHeader, ptrs, baseAddr);
            }
            else if (filename.StartsWith("EnemyLevelBaseParam."))
            {
                return new EnemyLevelParamFile(filename, rawData, inHeader, ptrs, baseAddr);
            }
            else if (Regex.IsMatch(filename, "item(Suit|Parts)Param.[uxs]nr"))
            {
                return new ItemSuitParamFile(filename, rawData, inHeader, ptrs, baseAddr);
            }
            else if (filename.EndsWith(".nom"))
            {
                return new NomFile(filename, rawData, inHeader, ptrs, baseAddr);
            }
            else if (filename.Contains("itemBulletParam_27MagAt"))
            {
                return new RmagBulletParamFile(filename, rawData, inHeader, ptrs, baseAddr);
            }
            else if (Regex.IsMatch(filename, "partsinfo.[uxs]nr"))
            {
                return new PartsInfoFile(filename, rawData, inHeader, ptrs, baseAddr);
            }
            else if (Regex.IsMatch(subheaderIdentifier, "N[UXSY]IF"))
            {
                if (filename == "quest.xnr")
                {
                    return new QuestXNRFile(filename, rawData, inHeader, ptrs, baseAddr);
				}
                else
                {
                    return new PointeredFile(filename, rawData, inHeader, ptrs, baseAddr, bigEndian);
                }
            }
            else if( fileExtension == ".bin" )
            {
                string ident = Encoding.UTF8.GetString(rawData, 0, 4);
				
                if( ident == "RIPC" )
                {
                    return new PalTextureFile(rawData);
                }
                else
                {
					return new UnpointeredFile(filename, rawData, inHeader);
				}
			}
            return new UnpointeredFile(filename, rawData, inHeader);
        }
    }
}
