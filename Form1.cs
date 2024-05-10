using Darknet;
using System.Diagnostics;

namespace CoolooAI.YOLOv3
{
    public partial class Form1 : Form
    {
        //global vars
        string basePath = AppDomain.CurrentDomain.BaseDirectory;
        string baseFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets");
        string imagePath = "";
        string[,] COLORS = new string[93, 2] {
            {"#DC143C", "#FFFFFF"},{"#0000FF", "#FFFFFF"},{"#8A2BE2", "#FFFFFF"},{"#7FFF00", "#1F2D3D"},{"#A52A2A", "#FFFFFF"},{"#2F4F4F", "#FFFFFF"},{"#FF1493", "#FFFFFF"},{"#D2691E", "#FFFFFF"},{"#FF7F50", "#1F2D3D"},{"#228B22", "#FFFFFF"},{"#00008B", "#FFFFFF"},{"#6495ED", "#FFFFFF"},{"#B8860B", "#FFFFFF"},{"#006400", "#FFFFFF"},{"#8B008B", "#FFFFFF"},{"#556B2F", "#FFFFFF"},{"#FF8C00", "#1F2D3D"},{"#E9967A", "#1F2D3D"},{"#483D8B", "#FFFFFF"},{"#00CED1", "#FFFFFF"},{"#9400D3", "#FFFFFF"},{"#00BFFF", "#FFFFFF"},{"#1E90FF", "#FFFFFF"},{"#B22222", "#FFFFFF"},{"#FF00FF", "#FFFFFF"},{"#FFD700", "#1F2D3D"},{"#DAA520", "#1F2D3D"},{"#808080", "#FFFFFF"},{"#008000", "#FFFFFF"},{"#ADFF2F", "#1F2D3D"},{"#FF69B4", "#1F2D3D"},{"#CD5C5C", "#FFFFFF"},{"#4B0082", "#FFFFFF"},{"#7CFC00", "#1F2D3D"},{"#ADD8E6", "#1F2D3D"},{"#F08080", "#1F2D3D"},{"#FFB6C1", "#1F2D3D"},{"#FFA07A", "#1F2D3D"},{"#20B2AA", "#FFFFFF"},{"#DEB887", "#1F2D3D"},{"#87CEFA", "#1F2D3D"},{"#778899", "#FFFFFF"},{"#778899", "#FFFFFF"},{"#32CD32", "#FFFFFF"},{"#FF00FF", "#FFFFFF"},{"#800000", "#FFFFFF"},{"#66CDAA", "#1F2D3D"},{"#0000CD", "#FFFFFF"},{"#BA55D3", "#FFFFFF"},{"#9370DB", "#FFFFFF"},{"#3CB371", "#FFFFFF"},{"#7B68EE", "#FFFFFF"},{"#00FA9A", "#1F2D3D"},{"#48D1CC", "#1F2D3D"},{"#C71585", "#FFFFFF"},{"#7FFFD4", "#1F2D3D"},{"#000080", "#FFFFFF"},{"#808000", "#FFFFFF"},{"#6B8E23", "#FFFFFF"},{"#FFA500", "#1F2D3D"},{"#FF4500", "#FFFFFF"},{"#DA70D6", "#1F2D3D"},{"#DB7093", "#FFFFFF"},{"#FFDAB9", "#1F2D3D"},{"#CD853F", "#FFFFFF"},{"#FFC0CB", "#1F2D3D"},{"#DDA0DD", "#1F2D3D"},{"#800080", "#FFFFFF"},{"#663399", "#FFFFFF"},{"#FF0000", "#FFFFFF"},{"#BC8F8F", "#1F2D3D"},{"#4169E1", "#FFFFFF"},{"#8B4513", "#FFFFFF"},{"#FA8072", "#1F2D3D"},{"#00FFFF", "#1F2D3D"},{"#F4A460", "#1F2D3D"},{"#2E8B57", "#FFFFFF"},{"#A0522D", "#FFFFFF"},{"#87CEEB", "#1F2D3D"},{"#6A5ACD", "#FFFFFF"},{"#708090", "#FFFFFF"},{"#00FF7F", "#1F2D3D"},{"#4682B4", "#FFFFFF"},{"#D2B48C", "#1F2D3D"},{"#008080", "#FFFFFF"},{"#D8BFD8", "#1F2D3D"},{"#FF6347", "#FFFFFF"},{"#40E0D0", "#1F2D3D"},{"#EE82EE", "#1F2D3D"},{"#F5DEB3", "#1F2D3D"},{"#FFFF00", "#1F2D3D"},{"#9ACD32", "#1F2D3D"},{"#000000", "#FFFFFF"}
        };
        List<string> Names;

        bool loading = false;
        YoloWrapper YOLO;
        // end global vars

        public Form1()
        {
            InitializeComponent();
        }

        public Task<bool> LoadYoloAsync(string modelName)
        {
            loading = true;
            return Task.Run(() =>
            {
                BeginInvoke(new Action(() =>
                {
                    button1.Text = "Loading model ...";
                }));

                // pre-training model
                var files = Directory.GetFiles(Path.Combine(basePath, "model", modelName));

                var ConfigFile = files.Where(p => p.EndsWith(".cfg")).FirstOrDefault();
                var WeightsFile = files.Where(p => p.EndsWith(".weights")).FirstOrDefault();
                var NamesFile = files.Where(p => p.EndsWith(".names")).FirstOrDefault();

                if (string.IsNullOrEmpty(ConfigFile) || string.IsNullOrEmpty(WeightsFile) || string.IsNullOrEmpty(NamesFile))
                {
                    BeginInvoke(new Action(() =>
                    {
                        MessageBox.Show("Missing Model files *.cfg, *.weight, *.names, all are indispensable £¡");
                        button1.Text = "Loading failed";
                    }));
                    return false;
                }

                var fileinfo = new FileInfo(WeightsFile);

                label6.BeginInvoke(new Action(() =>
                {
                    label6.Text = $"YOLOv3, RTX 2080 Ti, CUDA 10.2, {(modelName == "yolo-v3" ? "" : "Custom ")}Dataset = {fileinfo.LastWriteTime.ToString("yyyy/MM/dd")}";
                }));

                Names = File.ReadAllLines(NamesFile).ToList();

                // use GPU 0
                var GpuIndex = 0;

                YOLO = new YoloWrapper(ConfigFile, WeightsFile, GpuIndex);

                BeginInvoke(new Action(() =>
                {
                    button1.Text = "Detect";
                    pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
                    pictureBox1.Image = null;
                    if (listBox1.Items.Count > 0)
                    {
                        DetectImageAsync(Path.Combine(baseFolder, modelName, listBox1.SelectedItem.ToString()));
                    }

                }));

                loading = false;
                return true;
            });
        }

        public Task<bool> DetectImageAsync(string imagePath)
        {
            return Task.Run(() =>
            {
                if (loading) return false;
                if (YOLO == null) return false;

                BeginInvoke(new Action(() =>
                {
                    button1.Text = "Detecting...";
                    pictureBox1.ImageLocation = imagePath; // ;
                    using (var fileStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        using (var image = Image.FromStream(fileStream, false, false))
                        {
                            //if (image.Width > 800 || image.Height > 600)
                            //{
                            //    this.Width = image.Width + 400;
                            //    this.Height = image.Height + 400;
                            //}
                            //else if (image.Width < 800 && image.Height < 600)
                            //{
                            //    this.Width = 1100;
                            //    this.Height = 800;
                            //}

                            if (image.Width > dataGridView1.Width)
                            {
                                this.Width = image.Width + 300;
                            }
                            else
                            {
                                this.Width = dataGridView1.Width + 300;
                            }

                            dataGridView1.Top = image.Height + 40;
                            dataGridView1.Height = this.Height - dataGridView1.Top - 120;
                            //dataGridView1.BackgroundColor = Color.Black;
                            this.StartPosition = FormStartPosition.CenterScreen;
                        }
                    }
                }));

                var t1 = new Stopwatch();
                t1.Start();
                //var bboxes = YOLO.Detect(imagePath)?.Where(p => p.obj_id > 0 && p.prob > 0).ToList();
                var bboxes = YOLO.Detect(imagePath)?.Where(p => p.w > 0 && p.h > 0 && p.prob > 0).ToList();
                t1.Stop();

                var obj_bboxes = bboxes?.Select((p, i) => new obj_box
                {
                    row_id = i + 1,
                    obj_id = (int)p.obj_id,
                    obj_name = Names[(int)p.obj_id],
                    x = (int)p.x,
                    y = (int)p.y,
                    w = (int)p.w,
                    h = (int)p.h,
                    prob = p.prob,
                    track_id = (int)p.track_id,
                    frames_counter = (int)p.frames_counter,
                    x_3d = p.x_3d,
                    y_3d = p.y_3d,
                    z_3d = p.z_3d,
                });

                BeginInvoke(new Action(() =>
                {
                    textBox1.Clear();
                    label1.Text = $"{bboxes?.Count()} object(s)";
                    label2.Text = t1.ElapsedMilliseconds.ToString();
                    label4.Text = Math.Round((decimal)(1000 / t1.ElapsedMilliseconds), 0).ToString();
                    dataGridView1.DataSource = obj_bboxes?.ToList();
                    if (!dataGridView1.Visible) dataGridView1.Visible = true;
                }));

                DrawDrawBoxes(pictureBox1.CreateGraphics(), obj_bboxes.ToList());

                BeginInvoke(new Action(() =>
                {
                    textBox1.AutoScrollOffset = new Point(0, 0);
                    button1.Text = "Done";
                }));


                return true;
            });
        }

        void DrawDrawBoxes(Graphics g, List<obj_box> list)
        {
            if (list?.Count == 0) return;

            var pen = new Pen(Color.Yellow, 2);

            int i = 0, index = 0, color_index = 0;
            foreach (var detect in list)
            {
                index = Convert.ToInt32(detect.obj_id);
                //Console.WriteLine($"{(i + 1),4} {detect.obj_id,4} {Names[index],10} {detect.prob.ToString("P2"),8} {detect.track_id,4} [{detect.w,4} {detect.h,4} {detect.x,4} {detect.y,4}]");
                //0, pen\brush
                color_index = i % (COLORS.Length / 2);
                var color_bg = COLORS[color_index, 0];  //background color
                var color_fr = COLORS[color_index, 1];  //front color
                var brush = new SolidBrush(ColorTranslator.FromHtml(color_bg));

                //1, draw box
                pen.Color = ColorTranslator.FromHtml(color_bg);
                g.DrawRectangle(pen, detect.x, detect.y, detect.w, detect.h);

                //2, draw background of name
                var font = new Font("Tahoma", 10);
                var title = $"{i + 1} {detect.obj_name}";
                var bgSize = g.MeasureString(title, font);
                var rect = new RectangleF(detect.x, detect.y, bgSize.Width, bgSize.Height);
                g.FillRectangle(brush, rect);

                //3, draw name
                g.DrawString(
                    title,
                    font,
                    new SolidBrush(ColorTranslator.FromHtml(color_fr)),
                    new PointF(detect.x, detect.y));

                //4, textbox1
                BeginInvoke(new Action(() =>
                {
                    textBox1.AppendText($"{i + 1,-10}{detect.obj_name,-30}{detect.prob.ToString("P2"),-10}{Environment.NewLine}");
                }));

                i++;
            }

            pen.Dispose();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files (.jpg, .png)|*.jpg;*.png";
            openFileDialog1.FileName = "";

            dataGridView1.AutoGenerateColumns = false;

            ScanModelFolderAsync();
        }

        public Task<bool> ScanModelFolderAsync()
        {
            //scan model subfolders
            return Task.Run(() =>
            {
                var subfolders = Directory.GetDirectories(Path.Combine(basePath, "model"));
                Invoke(new Action(() =>
                {
                    comboBox1.DataSource = subfolders.Select(p => p.Substring(p.LastIndexOf(Path.DirectorySeparatorChar) + 1)).OrderByDescending(p => p).ToList();
                }));

                return true;
            });
        }

        public Task<bool> ScanImageAssetsFolderAsync(string path)
        {
            return Task.Run(() =>
            {
                var files = Directory.GetFiles(path, "*.*g");
                if (files.Length == 0) return false;

                Invoke(new Action(() =>
                {
                    listBox1.DataSource = files.Select(p => p.Substring(p.LastIndexOf(Path.DirectorySeparatorChar) + 1)).ToList();
                }));

                return true;
            });
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _ = ScanImageAssetsFolderAsync(Path.Combine(baseFolder, comboBox1.SelectedItem.ToString()));
            _ = LoadYoloAsync(comboBox1.SelectedItem.ToString());
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Task.Run(() =>
            {
                DetectImageAsync(openFileDialog1.FileName);
            });
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var path = Path.Combine(baseFolder, comboBox1.Text, listBox1.SelectedItem.ToString());
            DetectImageAsync(path);
        }
    }
}