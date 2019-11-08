using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {

        List<string> nonWords = new List<string>();

        public Login()
        {
            InitializeComponent();
            nonWords.Add("drop");
            nonWords.Add("database");
            nonWords.Add("update");
            nonWords.Add("insert");
            nonWords.Add("table");
            
        }

        private void btn_Login_Click(object sender, RoutedEventArgs e)
        {
            HashAndSalt hSalt = new HashAndSalt();
            DBhandling dbcmd = new DBhandling();

            int userName;
            string userPass = "";


            if (int.TryParse(box_BrugerName.Text, out userName))
            {
                if (box_Password.Text != "")
                {
                    userPass = box_Password.Text;
                }else
                {
                    MessageBox.Show("You must write your password");
                    return;
                }
                
            } else
            {
                MessageBox.Show("There is only numbers in the login");
                return;
            }
           

            /*if(testUserName(userName))
            {
                MessageBox.Show("Welcome");
            } else
            {
                MessageBox.Show("Your name contain illegal characters");
                return;
            }*/
            string salt = hSalt.CreateSalt(10);
            string hashedpassword = hSalt.GenerateSHA256Hash(userPass, salt);

            box_Reveal.Text = hashedpassword;
        }

        private bool testUserName(string input)
        {
            bool isLegal = false;
            Regex rex = new Regex("^[-'a-zA-Z]*$", RegexOptions.IgnoreCase);

            bool result = rex.IsMatch(input);
            foreach (string s in nonWords)
            {
                if (input.Contains(s) || input.Contains(s.ToUpper()) || input == "" || result == false )
                {
                    isLegal = false;
                }
                else
                {
                    isLegal = true;
                }
            }
            return isLegal;
        }


        
    }
}
