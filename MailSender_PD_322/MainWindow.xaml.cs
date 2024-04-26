using System.ComponentModel;
using System.Net;
using System.Net.Mail;
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

namespace MailSender_PD_322
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string server = "smtp.gmail.com";
        int port = 587;

        string username = "dashakonopelko@gmail.com";
        string password = "ojnn init donu ugkb";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            MailMessage message = new MailMessage(fromObject.Text,toObject.Text,subject.Text,bodyObject.Text);
            SmtpClient client = new SmtpClient(server,port);
            client.Credentials = new NetworkCredential(username,password);

            message.Priority = MailPriority.High;
            message.Attachments.Add(new Attachment(@"../../../Files/nuts.jpg"));
            message.Attachments.Add(new Attachment(@"../../../Files/text.txt"));
            client.EnableSsl = true;

            client.SendCompleted += Client_SendCompleted;

            client.SendAsync(message, message);
        }
        private void Client_SendCompleted(object sender, AsyncCompletedEventArgs e)
        {
            var state = (MailMessage)e.UserState!;
            MessageBox.Show($"Message was send! Subject: {state.Subject}");
        }
    }
}