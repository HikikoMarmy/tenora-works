using System;
using PSULib.FileClasses.General;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace PSULib.FileClasses.Textures
{
	// Support file for RIPC
	public class PalTextureFile : PsuFile
	{
		int unk_a;
		int file_chunks;
		int file_size;

		// Palette?
		short unk_b;
		short palette_size;
		short unk_c;
		short palette_color_depth;


		// Texture
		int image_header_offset;
		int unk_d;

		short unk_e;
		short image_width;
		short image_height;
		short image_depth;
		int image_length;
		int unk_f;

		PixelFormat image_format;
		Bitmap bm_palette;
		Bitmap bm_texture;

		ColorPalette palette;

		byte[] rawData;

		public PalTextureFile( byte[] rawData )
		{
			this.rawData = rawData;

			MemoryStream stream = new MemoryStream( rawData );
			BinaryReader reader = new BinaryReader( stream );

			string ident = new string(reader.ReadChars(4));

			switch (ident)
			{
				case "RIPC":
					{
						ReadRIPCFile(stream, reader);
					} break;

				default:
					{
						MessageBox.Show("Unhandled File Identity " + ident);
					} break;
			}
		}

		private void ReadRIPCFile( MemoryStream stream, BinaryReader reader )
		{
			unk_a = reader.ReadInt32();
			file_chunks = reader.ReadInt32();
			file_size = reader.ReadInt32();
			unk_b = reader.ReadInt16();
			palette_size = reader.ReadInt16();
			unk_c = reader.ReadInt16();
			palette_color_depth = reader.ReadInt16();
			image_header_offset = reader.ReadInt32();
			unk_d = reader.ReadInt32();

			palette = new Bitmap(1, 1, PixelFormat.Format8bppIndexed).Palette;

			bm_palette = new Bitmap(16, 16);

			for (int index = 0; index < palette_size && stream.Position < (image_header_offset + 16); ++index)
			{
				palette.Entries[index] = Color.FromArgb(reader.ReadInt32());
				Graphics.FromImage(bm_palette).FillRectangle(
					new SolidBrush(palette.Entries[index]),
					(index % 16) * 1, (index / 16) * 1, 1, 1);
			}

			if (image_header_offset != 0 && image_header_offset + 16 < file_size && (file_chunks & 1) != 0)
			{
				stream.Seek((image_header_offset + 16), SeekOrigin.Begin);
				unk_e = reader.ReadInt16();
				image_width = reader.ReadInt16();
				image_height = reader.ReadInt16();
				image_depth = reader.ReadInt16();
				image_length = reader.ReadInt32();
				unk_f = reader.ReadInt32();

				switch (image_depth)
				{
					case 4: image_format = PixelFormat.Format4bppIndexed; break;
					case 8: image_format = PixelFormat.Format8bppIndexed; break;
					default:
						{
							image_format = PixelFormat.Format8bppIndexed;
						}
						break;
				}

				bm_texture = new Bitmap(image_width, image_height, image_format)
				{
					Palette = palette
				};

				byte[] source = reader.ReadBytes(image_length);

				BitmapData texture_data = bm_texture.LockBits(
					new Rectangle(0, 0, image_width, image_height),
					ImageLockMode.ReadWrite, image_format);

				Marshal.Copy(source, 0, texture_data.Scan0, image_length - 16);

				bm_texture.UnlockBits(texture_data);
			}
		}

		public Bitmap GetTextureBitmap()
		{
			return bm_texture;
		}

		public Bitmap GetPaletteBitmap()
		{
			return bm_palette;
		}

		public override byte[] ToRaw()
		{
			return rawData;
		}
	}
}
