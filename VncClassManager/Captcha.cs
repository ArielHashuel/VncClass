using System;
using System.Drawing;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VncClassManager
{ /// <summary>
  /// <see cref="UserControl"/> which implements pazzle captcha
  /// </summary>
    public partial class Captcha : UserControl
    {
        private const string ImageURI = "https://picsum.photos/200/300";
        private Bitmap? GuidelinedCrop;
        private Bitmap? OriginalCrop;
        private bool GuideToggle = true;
        private int CropX;
        private int count = 0;
        private readonly Random rnd;

        private bool passCaptcha;
        /// <summary>
        /// Did The user passed captcha.
        /// </summary>
        public bool PassCaptcha => passCaptcha;

        /// <summary>
        /// Creates new instance of <see cref="Captcha"/>.
        /// </summary>
        public Captcha()
        {
            InitializeComponent();
            rnd = new();
        }

        /// <summary>
        /// <inheritdoc cref="OnHandleCreated(EventArgs)"/>
        /// <br>Overrided in oreder to load Captcha image</br>
        /// </summary>
        /// <param name="e"></param>
        protected async override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
#if DEBUG
            passCaptcha = true;
#else
            await LoadImg();
#endif
        }

        /// <summary>
        /// Loads image and cropped image.
        /// </summary>
        public async Task LoadImg()
        {
            using HttpClient client = new();
            using System.IO.Stream? imgstream = await client.GetStreamAsync(ImageURI);
            Image? src = Image.FromStream(imgstream);
            src.RotateFlip(RotateFlipType.Rotate90FlipXY);

            CropX = rnd.Next(45, 195);
            int y = rnd.Next(35, 100);
            Rectangle cropRect = new(CropX, y, (int)((40F / 240F) * src.Width), (int)((30F / 135F) * src.Height));
            OriginalCrop = new(cropRect.Width + 1, cropRect.Height + 1);

            using Graphics crop = Graphics.FromImage(OriginalCrop);
            crop.DrawImage(src, new RectangleF(0, 0, OriginalCrop.Width, OriginalCrop.Height),
                             cropRect,
                             GraphicsUnit.Pixel);

            RectangleF guidecropRect = new(0, 0, OriginalCrop.Width + .25F, OriginalCrop.Height + .25F);
            GuidelinedCrop = OriginalCrop.Clone(guidecropRect, OriginalCrop.PixelFormat);
            using Graphics Guidecrop = Graphics.FromImage(OriginalCrop);
            using Pen p = new(Color.White, .25F);
            Guidecrop.DrawRectangle(p, 0, 0, GuidelinedCrop.Width + .25F, GuidelinedCrop.Height + .25F);
            using Graphics drop = Graphics.FromImage(src);
            drop.FillRectangle(Brushes.White, CropX, y, 40, 30);
            pictureBox1.Image = src;
            pictureBox2.Location = new(3, y + 3);
            pictureBox2.Image = GuidelinedCrop;
            pictureBox2.BringToFront();
        }

        /// <summary>
        /// Fired when the horizontal scroll bar scrolled, handles pazzle movement.
        /// </summary>
        /// <param name="sender"><inheritdoc cref="HScrollBar"/></param>
        /// <param name="e"><inheritdoc cref="ScrollEventHandler"/></param>
        private void HScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            int x = (int)((e.NewValue / 100F) * 240F);
            pictureBox2.Location = new(x, pictureBox2.Location.Y);

            if (e.Type == ScrollEventType.EndScroll && Math.Abs(CropX - x) < 5)
            {
                MessageBox.Show("Solved");
                passCaptcha = true;
                Enabled = false;
            }
        }

        /// <summary>
        /// Shows or removes white guidline from the cropped image.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Toggle_Click(object sender, EventArgs e)
        {
            GuideToggle = !GuideToggle;
            pictureBox2.Image = GuideToggle ? GuidelinedCrop : OriginalCrop;
        }

        /// <summary>
        /// Allows the user to reload the pazzle.
        /// <br>Only 3 times allowed.</br>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ReloadIMG(object sender, EventArgs e)
        {
            if (count < 3)
            {
                hScrollBar1.Value = 0;
                await LoadImg();
                count++;
                button2.Text = $"Reload ({3 - count})";
            }
            else
            {
                MessageBox.Show("Can't reload more than 3 times");
            }
        }
    }
}
