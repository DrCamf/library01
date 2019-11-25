using System;
using System.Collections.Generic;
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

namespace library01
{
    /// <summary>
    /// Interaction logic for Seek.xaml
    /// </summary>
    public partial class Seek : Page
    {
       
        public string strAbout;
        public Seek()
        {
            InitializeComponent();
            fillEmner();
            
        }

        private void btn_Seek_Click(object sender, RoutedEventArgs e)
        {
            string seekEmne = combo_SeekType.SelectedValue.ToString();
            string strSql = "";
            string seekStr = box_Seek.Text;
             


            if (seekStr != "")
            {
                if (seekEmne == "Søg i alle")
                {
                    strSql = "SELECT * FROM Medie WHERE " + strAbout + " = " + seekStr + ";";
            }
                else
                {
                    
                }
            } else
            {

            }
           
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            // ... Get RadioButton reference.
            var button = sender as RadioButton;

            // get Display button content.
            strAbout = button.Content.ToString();
            
            switch(strAbout)
            {
                case "Titel":
                    strAbout = "Medie.medie_Title";
                    break;
                case "Forfatter":
                    strAbout = strAbout + ".forfatter_name";
                    break;
                case "Year":
                    strAbout = "Medie.medie_Udgivelse_Dato";
                    break;
                case "Emne":
                    strAbout = "Emner.enme_Name";
                    break;
            }

            
        }

        private void grpSubject_Validated(object sender, EventArgs e)
        {
            
        }

        public void fillEmner()
        {
            DBhandling dbcmd = new DBhandling();
            List<string> emner = new List<string>();

            string sqlDa = "SELECT enme_Name FROM Emner;";

            emner = dbcmd.readDBNumUn(sqlDa, "enme_Name");
            combo_SeekType.Items.Add("Søg i alle");
            foreach (string s in emner)
            {
                combo_SeekType.Items.Add(s);
            }

        }

        private void combo_SeekType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
