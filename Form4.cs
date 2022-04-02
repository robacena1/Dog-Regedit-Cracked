using System;
using System.ComponentModel;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace DOGREGEDIT22
{
	// Token: 0x02000005 RID: 5
	public partial class Form4 : Form
	{
		// Token: 0x0600003D RID: 61 RVA: 0x0000207D File Offset: 0x0000027D
		public Form4()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600003E RID: 62 RVA: 0x0000476C File Offset: 0x0000296C
		private void Form4_Load(object sender, EventArgs e)
		{
			object[] array = new object[]
			{
				this,
				sender,
				e
			};
			object obj = <Module>.Execute(39893, array);
		}

		// Token: 0x0600003F RID: 63 RVA: 0x000047CC File Offset: 0x000029CC
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			object[] array = new object[]
			{
				this,
				sender,
				e
			};
			object obj = <Module>.Execute(39904, array);
		}

		// Token: 0x04000041 RID: 65
		private IContainer components;

		// Token: 0x04000042 RID: 66
		private Guna2DragControl guna2DragControl1;

		// Token: 0x04000043 RID: 67
		private Guna2Elipse guna2Elipse1;

		// Token: 0x04000044 RID: 68
		private Guna2Button guna2Button1;

		// Token: 0x04000045 RID: 69
		private Guna2PictureBox guna2PictureBox2;

		// Token: 0x04000046 RID: 70
		private Guna2PictureBox guna2PictureBox1;

		// Token: 0x04000047 RID: 71
		private Guna2PictureBox guna2PictureBox3;

		// Token: 0x04000048 RID: 72
		private Guna2PictureBox guna2PictureBox8;

		// Token: 0x04000049 RID: 73
		private Guna2PictureBox guna2PictureBox6;

		// Token: 0x0400004A RID: 74
		private Guna2PictureBox guna2PictureBox4;

		// Token: 0x0400004B RID: 75
		private Guna2PictureBox guna2PictureBox10;
	}
}
