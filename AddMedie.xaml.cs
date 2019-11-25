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
    /// Interaction logic for AddMedie.xaml
    /// </summary>
    public partial class AddMedie : Page
    {
        List<string> emneList = new List<string>();
        List<string> genreList = new List<string>();
        public AddMedie()
        {
            InitializeComponent();
            fillCombo(comboAddEmne, "emne");
            fillCombo(comboAddGenre, "genre");
            fillCombo(comboAddType, "type");
        }

        private void btn_AddMedieInto_Click(object sender, RoutedEventArgs e)
        {
            string outDate, opDate, title;

            if (box_AddTitle.Text != "" && box_AddTitle.Text != "Title") {
                title = box_AddTitle.Text;
            } else
            {
                MessageBox.Show("Du skal skrive en titel");
            }
            outDate = editDate(box_AddOutDate.SelectedDate.ToString());
            opDate = editDate(box_AddOpretDate.SelectedDate.ToString());

            box_AddTest.Text = outDate;
        }

        private void btn_AddEmne_Click(object sender, RoutedEventArgs e)
        {
            emneList.Add(comboAddEmne.SelectedItem.ToString());
        }

        private void btn_AddGenre_Click(object sender, RoutedEventArgs e)
        {
            genreList.Add(comboAddGenre.SelectedItem.ToString());
        }

        private void btn_AddNewEmne_Click(object sender, RoutedEventArgs e)
        {
            string em = box_NewEmne.Text;
            if (em != "" && em != "Nyt emne")
            {
                emneList.Add(em);
                box_NewEmne.Text = "";
            }
            else
            {
                MessageBox.Show("Du skal skrive et nyt emne");
            }
           
        }

        private void btn_AddNewGenre_Click(object sender, RoutedEventArgs e)
        {
            string em = box_NewGenre.Text;
            if (em != "" && em != "Nyt emne")
            {
                emneList.Add(em);
                box_NewGenre.Text = "";
            }
            else
            {
                MessageBox.Show("Du skal skrive et nyt emne");
            }

        }

        public void fillCombo(ComboBox combo, string inf)
        {
            string sqlDa = "";
            DBhandling dbcmd = new DBhandling();

            List<string> subjects = new List<string>();

            switch (inf)
            {
                case "emne":
                    sqlDa = "SELECT enme_Name FROM Emner;";
                    subjects = dbcmd.readDBNumUn(sqlDa, "enme_Name");
                    break;
                case "genre":
                    sqlDa = "SELECT genre_Name FROM Genre;";
                    subjects = dbcmd.readDBNumUn(sqlDa, "genre_Name");
                    break;
                case "type":
                    sqlDa = "SELECT type_Name FROM MedieType;";
                    subjects = dbcmd.readDBNumUn(sqlDa, "type_Name");
                    break;
                case "postnr":
                    sqlDa = "SELECT postNr_ID, city FROM PostnummerBy;";
                    subjects = dbcmd.readDBNumUn(sqlDa, "postNr_ID");
                    break;
            }

            foreach (string s in subjects)
            {
                combo.Items.Add(s);
            }

        }

        public string editDate(string datePick)
        {
            string temp;
            datePick = datePick.Remove(10, 9);
            temp = datePick.Remove(0, 6);
            datePick = temp + "-" + datePick.Remove(5, 5);

            return datePick;
        }

       
    }
}
