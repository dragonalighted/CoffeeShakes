using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;
using CoffeeShakes.Properties;
using Microsoft.Win32;

namespace CoffeeShakes
{
    public partial class MainForm : Form
    {
        private JitterBug jitterBug = new JitterBug();
        private Timer timer = new Timer();

        private NotifyIcon notificationIcon;
        private MenuItem mnuJitter;
        private MenuItem mnuAudio;
        private MenuItem mnuLastJitter;

        SoundPlayer audioCue = new System.Media.SoundPlayer(@"C:\Windows\Media\Speech On.wav");

        public MainForm()
        {
            InitializeComponent();
            SetupNotificationIcon();


            this.jitterBug.OnJitter += JitterBug_OnJitter;
            this.jitterBug.OnRelax += JitterBug_OnRelax;
            btnJitter.Text = cbEnable.Text;

            timer.SleepDuration = 200;
            timer.OnTick += Timer_OnTick;
            SystemEvents.SessionSwitch += SystemEvents_SessionSwitch;

            audioCue.Load();

        }

        public bool DoPlayAudioCue = false; 

        private void DisposeMore()
        {
            notificationIcon.Visible = false;
            notificationIcon.Dispose();

            audioCue.Dispose();
            
        }
        private void SetupNotificationIcon()
        {
            notificationIcon = new System.Windows.Forms.NotifyIcon();
            notificationIcon.Icon = Resources.CoffeeCup;
            notificationIcon.Visible = true;
            notificationIcon.DoubleClick += NotificationIcon_DoubleClick;

            mnuJitter = new MenuItem("Jitter", (sender, e) => { btnJitter_Click(btnJitter, EventArgs.Empty); });
            mnuLastJitter = new MenuItem("Last Jittered: -- Never" , (sender, e) => jitterBug.Poke());
            mnuAudio = new MenuItem("Play Audio", (sender, e) =>
            {
                DoPlayAudioCue = !DoPlayAudioCue;
                mnuAudio.Text = DoPlayAudioCue ? "Stop Audio" : "Start Audio";
                if(DoPlayAudioCue ) 
                    PlayAudioCue();
            }); 
            var contextMenu = new ContextMenu( new MenuItem[]
            {
               mnuJitter,
               mnuAudio,
               mnuLastJitter,
               new MenuItem("Exit", (sender, e) => this.Close()),
            });
            notificationIcon.ContextMenu = contextMenu;


        }

        private void NotificationIcon_DoubleClick(object sender, EventArgs e)
        {
            this.Activate();
        }

        private void SystemEvents_SessionSwitch(object sender, SessionSwitchEventArgs e)
        {
            if (cbEnable.Checked)
            {
                switch (e.Reason)
                {
                    case SessionSwitchReason.SessionLock:
                        jitterBug.Relax();
                        break;
                    case SessionSwitchReason.SessionUnlock:
                        jitterBug.Jitter(false);
                        break;
                    default:
                        jitterBug.Relax();
                        break;
                }
            }
        }

        private void Timer_OnTick(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                try
                {
                    this.Invoke(new Action(() => Timer_OnTick(null, e)));
                }
                catch
                {
                }
            }
            else
            {
//                btnJitter.BackColor = Color.FromArgb(Math.Max(0, btnJitter.BackColor.A - 1), btnJitter.BackColor);


                if (!jitterBug.IsRunning)
                {
                    lblNextJitter.Text = $"{lblNextJitter.Tag} -- Never";
                    btnJitter.BackColor = Color.FromArgb(0, btnJitter.BackColor);
                }
                else
                {
                    var sleepDuration = jitterBug.SleepDuration;
                    var delta = TimeSpan.FromMilliseconds(
                        Math.Min(Math.Max(0, sleepDuration - (DateTime.Now - lastJitter).TotalMilliseconds), sleepDuration)
                        );

                    string deltaText;

                    if (delta.Minutes == 0 && delta.Seconds == 0)
                        deltaText = "Now!";
                    else
                        deltaText = $"{delta.Minutes} mins {delta.Seconds} seconds";
                    lblNextJitter.Text = $"{lblNextJitter.Tag}{deltaText}";

                    int deltaColor = (int)(delta.TotalMilliseconds * 255) / sleepDuration;
                    btnJitter.BackColor = Color.FromArgb(deltaColor, btnJitter.BackColor);
                }


            }

        }

        private void JitterBug_OnRelax(object sender, EventArgs e)
        {
            JitterBug_OnJitter(null,null);
        }

        private DateTime? _lastJitter; 
        private DateTime lastJitter
        {
            get => _lastJitter ?? DateTime.MinValue;
            set
            {
                _lastJitter = value;
                mnuLastJitter.Text = lblLastJittered.Text = $"{lblLastJittered.Tag}{_lastJitter.ToString()}";
            }
        } 



        private void JitterBug_OnJitter(object sender, JitterBug.JitterEventArg e)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action( () => JitterBug_OnJitter(null, e)));
            }
            else
            {
                if (e == null)
                    lblZen.Text = Resources.txt_NotZen; 
                else if (e.DeltaX == 0)
                    lblZen.Text = Resources.txt_Zen;
                else
                    lblZen.Text = Resources.txt_AlmostZen;
                lblDeltaX.Text = $"{lblDeltaX.Tag}{e?.DeltaX.ToString() ?? string.Empty}";
                lblJitterPause.Text = $"{lblJitterPause.Tag}{e?.Pause.ToString() ?? string.Empty}";


                if (e != null)
                    lastJitter = e.Time;

                btnJitter.BackColor = Color.FromArgb(e == null ? 0 : 255, btnJitter.BackColor);

                if (e != null && DoPlayAudioCue)
                {
                    PlayAudioCue();
                }
            }
        }

        private void PlayAudioCue()
        {
            if(audioCue.IsLoadCompleted)
                audioCue.Play();
        }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == NativeMethods.WM_SHOWME)
            {
                ShowMe();
            }
            base.WndProc(ref m);
        }
        private void ShowMe()
        {
            if (WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Normal;
            }
            // get our current "TopMost" value (ours will always be false though)
            bool top = TopMost;
            // make our form jump to the top of everything
            TopMost = true;
            // set it back to whatever it was
            TopMost = top;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Icon = Resources.CoffeeCup;
            cbEnableChanged(null, null);
        }

        private void cbEnableChanged(object sender, EventArgs e)
        {
            cbEnable.Text = cbEnable.Checked ? Resources.txt_StopJitters : Resources.txt_GetJitters;
            mnuJitter.Text = cbEnable.Checked ? Resources.mnu_Relax : Resources.mnu_Jitter;
            if (cbEnable.Checked)
            {
                timer.Start();
                jitterBug.Jitter();
            }
            else
            {
                timer.Stop();
                jitterBug.Relax();
            }


            btnJitter.Text = cbEnable.Text;
            
        }

        private void MainForm_FormClosed(object sender, EventArgs e)
        {

            SystemEvents.SessionSwitch -= SystemEvents_SessionSwitch;
            jitterBug.Relax();
            timer.Stop();

            jitterBug.Dispose();
            timer.Dispose();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnJitter_Click(object sender, EventArgs e)
        {
            cbEnable.Checked = !cbEnable.Checked;
        }

    }


}
