using System;
using System.ComponentModel;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace DOGREGEDIT22
{
	// Token: 0x02000006 RID: 6
	public partial class Form5 : Form
	{
		// Token: 0x06000042 RID: 66 RVA: 0x0000208B File Offset: 0x0000028B
		public Form5()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000043 RID: 67 RVA: 0x000048BC File Offset: 0x00002ABC
		private void guna2GradientButton1_Click(object sender, EventArgs e)
		{
			object[] array = new object[]
			{
				this,
				sender,
				e
			};
			object obj = <Module>.Execute(44827, array);
		}

		// Token: 0x06000044 RID: 68 RVA: 0x0000491C File Offset: 0x00002B1C
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			object[] array = new object[]
			{
				this,
				sender,
				e
			};
			object obj = <Module>.Execute(44838, array);
		}

		// Token: 0x0400004C RID: 76
		private IContainer components;

		// Token: 0x0400004D RID: 77
		private Guna2DragControl guna2DragControl1;

		// Token: 0x0400004E RID: 78
		private Guna2Elipse guna2Elipse1;

		// Token: 0x0400004F RID: 79
		private Guna2PictureBox guna2PictureBox1;

		// Token: 0x04000050 RID: 80
		private Guna2PictureBox guna2PictureBox2;

		// Token: 0x04000051 RID: 81
		private Guna2PictureBox guna2PictureBox8;

		// Token: 0x04000052 RID: 82
		private Guna2PictureBox guna2PictureBox3;

		// Token: 0x04000053 RID: 83
		private Guna2Button guna2Button1;

		// Token: 0x04000054 RID: 84
		private Guna2PictureBox guna2PictureBox5;

		// Token: 0x04000055 RID: 85
		private Guna2PictureBox guna2PictureBox14;

		// Token: 0x04000056 RID: 86
		private Guna2PictureBox guna2PictureBox4;

		// Token: 0x04000057 RID: 87
		private Guna2PictureBox guna2PictureBox9;
	}
}
