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

        

        public Login()
        {
            InitializeComponent();
           
            
        }

        private void btn_Login_Click(object sender, RoutedEventArgs e)
        {
            HashAndSalt hSalt = new HashAndSalt();
            DBhandling dbcmd = new DBhandling();

            int userName;
            string userPass = "";
            string salt, hashedpassword, mere;
            string mereud;

            if (int.TryParse(box_BrugerName.Text, out userName))
            {
                if (box_Password.Text != "")
                {
                    mereud = dbcmd.returnFromSPLoginTjeck(userName);
                    salt = hSalt.CreateSalt(10);
                    hashedpassword = hSalt.GenerateSHA256Hash(userPass, salt);
                    mere = hSalt.GenerateSHA256Hash(mereud, salt);
                    
                    if (hashedpassword == mere)
                    {
                        MessageBox.Show("You were correct");
                    } else
                    {
                        MessageBox.Show("Wrong Wrong Wrong");
                    }
                    
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




            box_Reveal2.Text = mere;
            box_Reveal.Text = hashedpassword;
        }

       /* private bool testUserName(string input)
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
        }*/


        
    }
}
