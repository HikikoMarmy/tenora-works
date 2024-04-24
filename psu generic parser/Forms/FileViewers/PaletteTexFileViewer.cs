using PSULib.FileClasses.Textures;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace psu_generic_parser.Forms.FileViewers
{
	public partial class PaletteTexFileViewer : UserControl
	{
		PalTextureFile currentFile;
		public PaletteTexFileViewer(PalTextureFile file)
		{
			InitializeComponent();

			currentFile = file;

			Bitmap texture = file.GetTextureBitmap();

			this.picBoxMain.BackColor = Color.Black;
			this.picBoxMain.Image = ResizeBitmap(texture, texture.Width * 2, texture.Height * 2);

			this.picBoxPalette.BackColor = Color.Black;
			this.picBoxPalette.Image = ResizeBitmap(file.GetPaletteBitmap(), 256, 256 );
			this.Update();
		}

		private Bitmap ResizeBitmap(Bitmap src, int width, int height)
		{
			Bitmap result = new Bitmap(width, height);
			using (Graphics g = Graphics.FromImage(result))
			{
				g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
				g.DrawImage(src, 0, 0, width, height);
			}
			return result;
		}

		private void btn_ImportTexture_Click(object sender, EventArgs e)
		{

		}

		private void btn_ExportTexture_Click(object sender, EventArgs e)
		{

		}

		private void btn_ImportPalette_Click(object sender, EventArgs e)
		{
			OpenFileDialog dialog = new OpenFileDialog();
			if( dialog.ShowDialog() == DialogResult.OK )
			{
				Bitmap load_bm = new Bitmap(dialog.FileName);
				Bitmap texture = currentFile.GetTextureBitmap();
				ColorPalette palette = texture.Palette;

				for (int i = 0; i < load_bm.Width; i++)
				{
					for (int j = 0; j < load_bm.Height; j++)
					{
						palette.Entries[ ( 16 * j ) + i ] = load_bm.GetPixel( i, j );
					}
				}

				texture.Palette = palette;
				picBoxMain.Image = texture;
				picBoxPalette.Image = ResizeBitmap(load_bm, 256, 256);
				Update();
			}
		}

		private void btn_ExportPalette_Click(object sender, EventArgs e)
		{
			SaveFileDialog dialog = new SaveFileDialog();
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				Bitmap bm_palette = currentFile.GetPaletteBitmap();
				bm_palette.Save(dialog.FileName, ImageFormat.Png );
			}
		}
	}
}
