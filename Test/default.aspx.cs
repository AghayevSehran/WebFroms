using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Test
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string inputpath = Server.MapPath("~/App_Data/phoneNumbers.txt");
                string outputpath = Server.MapPath("~/App_Data/phoneNumberso.txt");
                bool fileIsEmpty = true;
                bool alreadyExist = false;
                bool added = false;
                using (var writer = new StreamWriter(outputpath))
                {
                    foreach (var line in File.ReadLines(inputpath))
                    {
                        if (line == "") continue;
                        fileIsEmpty = false;
                        if (String.Compare(txtPhone.Text, line) == 0)
                        {
                            alreadyExist = true;
                            break;
                        }
                        else if (!added && String.Compare(txtPhone.Text, line) < 0)
                        {
                            added = true;
                            writer.WriteLine();
                            writer.Write(txtPhone.Text);
                            writer.WriteLine();

                        }
                        else if (String.Compare(txtPhone.Text, line) > 0)
                        {
                            writer.WriteLine();
                        }
                        else if (added)
                        {
                            writer.WriteLine();
                        }

                        writer.Write(line);

                    }
                    if ((fileIsEmpty || !alreadyExist) && !added)
                    {
                        writer.WriteLine();
                        writer.Write(txtPhone.Text);
                    }
                }
                if (!alreadyExist)
                {
                    File.Delete(inputpath);
                    File.Move(outputpath, inputpath);
                }
                else
                {
                    File.Delete(outputpath);
                }
                if (alreadyExist)
                {
                    Label1.Visible = true;
                    Label1.Text = "Duplicated number.";
                }
                else
                {
                    Label1.Visible = false;
                }
            }


        }

        protected void phoneValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            Label1.Visible = false;
            if (txtPhone.Text == string.Empty)
            {
                phoneValidator.ErrorMessage = "Please enter valide phone number.";
                args.IsValid = false;
            }
            else if (txtPhone.Text.Length != 14)
            {
                phoneValidator.ErrorMessage = "Phone Number should be 10 digit.";
                args.IsValid = false;
            }
            else if (!Regex.IsMatch(txtPhone.Text, "^\\+?(\\d[\\d-. ]+)?(\\([\\d-. ]+\\))?[\\d-. ]+\\d$"))
            {
                phoneValidator.ErrorMessage = "Phone Number should be valid.";
                args.IsValid = false;
            }
        }
    }
}