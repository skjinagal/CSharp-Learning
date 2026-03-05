namespace OffloadLongTasks
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(() => ChangeMessage("Processing...", TimeSpan.FromSeconds(3)));
            thread.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(() => ChangeMessage("Processing...", TimeSpan.FromSeconds(3)));
            thread.Start();
        }

        private void ChangeMessage(string message, TimeSpan delay)
        {
            Thread.Sleep(delay);
            if(lblMessage.InvokeRequired) // Check if we need to invoke the UI thread , i.e. are we on a different thread than ui thread
            {
                Invoke(new Action(() => lblMessage.Text = message));
            }
            else
            {
                lblMessage.Text = message; // If we are already on the UI thread, we can directly update the label
            }
        }
    }
}
