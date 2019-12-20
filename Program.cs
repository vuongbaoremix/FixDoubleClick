using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MKManager;
using MouseButtons = MKManager.MouseButtons;

namespace FixDoubleClick
{
    class Program
    {
        static int _timeClick = 0;

        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MouseHook m = new MouseHook();

            m.MouseDown += M_MouseDown;
            m.MouseUp += M_MouseUp;

            m.Start();

            //System.Threading.Thread t = new System.Threading.Thread((delegate ()
            //{
            //    MouseHook m = new MouseHook();

            //    m.MouseDown += M_MouseDown;
            //    m.MouseUp += M_MouseUp;

            //    m.Start();
            //    Console.ReadLine();

            //}));
            //t.SetApartmentState(System.Threading.ApartmentState.STA);
            //t.IsBackground = true;
            //t.Start(); 

            Application.Run();
        }

        private static bool M_MouseUp(MouseButtons button, int x, int y)
        {
           // if (button == MouseButtons.Right)
            {
                _timeClick = Environment.TickCount;
            }


            return false;

        }

        private static bool M_MouseDown(MouseButtons button, int x, int y)
        {
           // if (button == MouseButtons.Right || button == MouseButtons.Left)
            {
                if (Environment.TickCount - _timeClick <= 40)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
