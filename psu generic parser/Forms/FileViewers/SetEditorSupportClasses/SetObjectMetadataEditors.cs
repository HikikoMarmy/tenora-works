using PSULib.FileClasses.Missions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace psu_generic_parser.Forms.FileViewers.SetEditorSupportClasses
{
    class SetObjectMetadataEditors
    {
        //For speed purposes, this is going to be cached--it takes _forever_ to create a new one.
        private static HexMetadataEditor cachedHexEditor = new HexMetadataEditor();

        public static UserControl getMetadataEditor(SetFile.ObjectEntry setObject)
        {
            cachedHexEditor.SetObjectEntry(setObject);
            return cachedHexEditor;

            //  UserControl Ctl;
            //  
            //  switch (setObject.objectType)
            //  {
            //      case 12: Ctl = new TObjBreakEditor(setObject); break;
			//  	case 14: Ctl = new TObjUnitTransporter(setObject); break;
			//  	case 22: Ctl = new TObjSwitchTerminal(setObject); break;
			//  	case 31: Ctl = new TObjKey(setObject); break;
            //  
			//  	default:
            //      {
			//  		cachedHexEditor.SetObjectEntry(setObject);
			//  		Ctl = cachedHexEditor;
			//      } break;
            //  }
            //  
            //  return Ctl;
        }
    }
}
