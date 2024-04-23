using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Compunet.YoloV8;
using Compunet.YoloV8.Plotting;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing;
using static System.Net.Mime.MediaTypeNames;
using FilePath = System.IO.Path;


namespace WpfApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            TextBlock1.Text = "Upload your image";

            var directory = FilePath.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            var tmp = FilePath.Combine(directory, "./tmp");
            if (!Directory.Exists(tmp))
                Directory.CreateDirectory(tmp);
            var tmp_file0 = FilePath.Combine(directory, "./tmp/0.jpg");
            var tmp_file1 = FilePath.Combine(directory, "./tmp/1.jpg");

            File.Delete(tmp_file0);
            File.Delete(tmp_file1);
        }

        private void Detect_Click(object sender, RoutedEventArgs e)
        {
            var directory = FilePath.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var tmp_file0 = FilePath.Combine(directory, "./tmp/0.jpg");

            if (!File.Exists(tmp_file0))
            {
                MessageBox.Show("First upload the image");
                return;
            }

            var image = SixLabors.ImageSharp.Image.Load(tmp_file0);
            var predictor = YoloV8Predictor.Create("./best.onnx");
            predictor.Configuration.Confidence = 0.8F;

            var result = predictor.Detect(image);
            var plotted = result.PlotImage(image);
            plotted.Save("./tmp/1.jpg");
            var tmp_file1 = FilePath.Combine(directory, "./tmp/1.jpg");

            BitmapImage image1 = new BitmapImage();
            image1.BeginInit();
            image1.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
            image1.CacheOption = BitmapCacheOption.OnLoad;
            image1.UriSource = new Uri(tmp_file1);
            image1.EndInit();
            Image1.Source = image1;
            TextBlock1.Text = "Detection result";
        }
        private void Upload_Click(object sender, RoutedEventArgs e)
        {
            var ofd = new Microsoft.Win32.OpenFileDialog();
            ofd.Filter = "Image Files(*.BMP; *.JPG; *.GIF; *.PNG; *.JPEG)| *.BMP; *.JPG; *.GIF; *.PNG; *.JPEG";
            string filename = "";
            if (ofd.ShowDialog() == false)
                return;
            filename = ofd.FileName;
            var directory = FilePath.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var tmp_file0 = FilePath.Combine(directory, "./tmp/0.jpg");
            File.Copy(filename, tmp_file0, true);

            BitmapImage image0 = new BitmapImage();
            image0.BeginInit();
            image0.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
            image0.CacheOption = BitmapCacheOption.OnLoad;
            image0.UriSource = new Uri(tmp_file0);
            image0.EndInit();
            Image1.Source = image0;
            TextBlock1.Text = "Press the 'Detect' button";
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            var directory = FilePath.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var tmp_file1 = FilePath.Combine(directory, "./tmp/1.jpg");
            if (!File.Exists(tmp_file1))
            {
                MessageBox.Show("First run detection");
                return;
            }

            var sfd = new Microsoft.Win32.SaveFileDialog();
            sfd.Filter = "Image Files(*.BMP; *.JPG; *.GIF; *.PNG; *.JPEG)| *.BMP; *.JPG; *.GIF; *.PNG; *.JPEG";
            string filename = "";
            if (sfd.ShowDialog() == false)
                return;
            filename = sfd.FileName;
            File.Copy(tmp_file1, filename, true);
            MessageBox.Show("Image saved");
        }
        private void Show_supported_breeds_Click(object sender, RoutedEventArgs e)
        {
            breeds breeds_window = new breeds();
            breeds_window.Show();
        }
    }
}