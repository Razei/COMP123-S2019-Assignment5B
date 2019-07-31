using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using COMP123_S2019_Assignment5B.Models;
using COMP123_S2019_Assignment5B.Views;

namespace COMP123_S2019_Assignment5B
{
    public static class Program
    {

        public static OrderForm orderForm;
        public static SelectForm selectForm;
        public static StartForm startForm;
        public static ProductInfoForm productInfoForm;
        public static AboutForm aboutForm;
        public static SplashForm splashForm;

        //generated database class
        public static Product product;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            orderForm = new OrderForm();
            selectForm = new SelectForm();
            startForm = new StartForm();
            productInfoForm = new ProductInfoForm();
            aboutForm = new AboutForm();
            splashForm = new SplashForm();
            product = new Product();


            Application.Run(selectForm);
        }
    }
}
