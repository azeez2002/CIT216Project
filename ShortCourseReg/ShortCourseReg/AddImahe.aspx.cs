﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Windows.Forms;
using FreeTextBoxControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using static System.Windows.Forms.LinkLabel;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Web.Security;
using System.Diagnostics;
using System.Reflection.Emit;
using System.Web.Services;
using System.Drawing;
using System.Text;
//using static System.Net.WebRequestMethods;


namespace ShortCourseReg
{
    public partial class AddImahe : System.Web.UI.Page
    {
        byte[] image_byte = null;
        string File_name = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            image_byte = (byte[])Session["ImageValue"];
            File_name = (String)Session["File_name"];
        }

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
        SqlCommand cmd = new SqlCommand();
        protected void Save_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string SQL_Command = "insert into Items(ItemName, ItemDescription, Software, ItemCreator, ItemImage, ProjectFile) Values(@ItemName, @ItemDescription, @Software, @ItemCreator, @ItemImage, @ProjectFile)";
                cmd = new SqlCommand(SQL_Command, con);
                cmd.Parameters.AddWithValue("@ItemName", Name.Text);
                cmd.Parameters.AddWithValue("@ItemDescription", Description.Text);
                cmd.Parameters.AddWithValue("@Software", Category.Text);
                cmd.Parameters.AddWithValue("@ItemCreator", Creator.Text);
                cmd.Parameters.AddWithValue("@ItemImage", image_byte);
                cmd.Parameters.AddWithValue("@ProjectFile", File_name);
                FileUpload1.SaveAs(File_name);
                FileUpload1.SaveAs((String)Session["DatabaseFile_name"]);
                cmd.ExecuteNonQuery();
                con.Close();
                saved.Text = "Saved successfully";
                Clear_Contrils();
            }
            catch (Exception ex)
            {
                saved.Text = "Error, " + ex;
            } 

        }
         protected void Edit_Click(object sender, EventArgs e)
         {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Items set ItemDescription =@ItemDescription, Software =@Software, ItemCreator =@ItemCreator, ItemImage =@ItemImage  where ItemName= @ItemName", con);
                cmd.Parameters.AddWithValue("@ItemName", Name.Text);
                cmd.Parameters.AddWithValue("@ItemDescription", Description.Text);
                cmd.Parameters.AddWithValue("@Software", Category.Text);
                cmd.Parameters.AddWithValue("@ItemCreator", Creator.Text);
                cmd.Parameters.AddWithValue("@ItemImage", image_byte);
                cmd.ExecuteNonQuery();
            con.Close();
                saved.Text = "--- Table Updated Successfully ---";
                Clear_Contrils();
            }
            catch (Exception ex)
            {
                saved.Text = "Error, " + ex;
            }
        }

        protected void View_Click(object sender, EventArgs e)
        {
            try
            {
                string SQL_Command = "SELECT * from Items where ItemName = @ItemName";
                con.Open();
                cmd = new SqlCommand(SQL_Command, con);
                cmd.Parameters.AddWithValue("@ItemName", Name.Text);
                SqlDataReader R = cmd.ExecuteReader();
                if (R.Read())
                {
                    Name.Text = Convert.ToString(R["ItemName"]);
                    Description.Text = Convert.ToString(R["ItemDescription"]);
                    Category.Text = Convert.ToString(R["Software"]);
                    Creator.Text = Convert.ToString(R["ItemCreator"]);
                    Session["ImageValue"] = (byte[])R["ItemImage"];
                    string imge_string = Convert.ToBase64String((byte[])Session["ImageValue"]);
                    string imge = "data:Image/png;base64," + imge_string;
                    Image1.ImageUrl = imge;
                }
                con.Close();
            }
            catch (Exception ex)
            {
                saved.Text = "Error, " + ex;
            }
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            try
            {

                string SQL_Command = "DELETE from Items where ItemName = @ItemName";
                con.Open();
                cmd = new SqlCommand(SQL_Command, con);
                cmd.Parameters.AddWithValue("@ItemName", Name.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                saved.Text = "Item has Deleted successfully";
                Clear_Contrils();
            }
            catch (Exception ex)
            {
                saved.Text = "Error, " + ex;
            }
        }

        public void Show_Image_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile) {
                HttpPostedFile posted_File = FileUpload1.PostedFile;
                string File_Name = Path.GetFileName(posted_File.FileName);
                string File_path = Path.GetFullPath(posted_File.FileName);
                string File_Extension = Path.GetExtension(File_Name);

                if (File_Extension.ToLower() == ".jpg" || File_Extension.ToLower() == ".gif" || File_Extension.ToLower() == ".png" || File_Extension.ToLower() == ".bmp")
                {
                    Stream stream = posted_File.InputStream;
                    BinaryReader br = new BinaryReader(stream);
                    image_byte = br.ReadBytes((int)stream.Length);
                    Session["ImageValue"] = image_byte;
                    image_uplod.Text = File_Name;
                    image_uplod.BackColor = Color.Green;

                    string imge_string = Convert.ToBase64String(image_byte);
                    string img = "data:Image/png;base64," + imge_string;
                    Image1.ImageUrl = img;
                }
                if (File_Extension.ToLower() == ".exe")
                {
                    StringBuilder B = new StringBuilder();
                    string file_save = @"C:\Users\alaze\Desktop\DCC Term 3\CIT216-Web Authoring II\Web project\CIT216Project\ShortCourseReg\ShortCourseReg\Projects saves\"+Creator.Text+"_"+ Name.Text + "\\";
                    
                        if (!Directory.Exists(file_save))
                        {
                            if (Name.Text != "" && Creator.Text != "")
                            {
                                Directory.CreateDirectory(file_save);
                                Session["File_name"] = file_save + FileUpload1.FileName;
                                ProjectFile_Uplod.Text = FileUpload1.FileName;
                                ProjectFile_Uplod.BackColor = Color.Green;
                        }
                            else
                            {
                                saved.Text = "Name is Creator for Uploding the file";
                            }
                            
                        }
                        else
                        {
                            if (Name.Text != "" && Creator.Text != "")
                            {
                                Session["File_name"] = file_save + FileUpload1.FileName;
                                ProjectFile_Uplod.Text = FileUpload1.FileName;
                                ProjectFile_Uplod.BackColor = Color.Green;
                            }
                            else
                            {
                                saved.Text = "Name is Creator for Uploding the file";
                            }

                        }
                    }
                
                if (File_Extension.ToLower() == ".mdf" || File_Extension.ToLower() == ".accdb")
                {
                    StringBuilder B = new StringBuilder();
                    string file_save = @"C:\Users\alaze\Desktop\DCC Term 3\CIT216-Web Authoring II\Web project\CIT216Project\ShortCourseReg\ShortCourseReg\Projects saves\" + Creator.Text + "_" + Name.Text + "\\";
                    Debug.WriteLine("DatabaseFile_Uplode0");
                    if (!Directory.Exists(file_save))
                    {
                        if (Name.Text != "" && Creator.Text != "")
                        {
                            Directory.CreateDirectory(file_save);
                            Session["DatabaseFile_name"] = file_save + FileUpload1.FileName;
                            DatabaseFile_Uplode.Text = FileUpload1.FileName;
                            DatabaseFile_Uplode.BackColor = Color.Green;
                            Debug.WriteLine("DatabaseFile_Uplode1");
                        }
                        else
                        {
                            saved.Text = "Name is Creator for Uploding the file";
                        }

                    }
                    else
                    {
                        if (Name.Text != "" && Creator.Text != "")
                        {
                            Session["DatabaseFile_name"] = file_save + FileUpload1.FileName;
                            DatabaseFile_Uplode.Text = FileUpload1.FileName;
                            DatabaseFile_Uplode.BackColor = Color.Green;
                            Debug.WriteLine("DatabaseFile_Uplode2");
                        }
                        else
                        {
                            saved.Text = "Name is Creator for Uploding the file";
                        }
                    }
                }
                Debug.WriteLine("Datab");

            }
        }
        private void Clear_Contrils()
        {
            Name.Text = "";
            Description.Text = "";
            Category.Text = "";
            Creator.Text = "";
            Image1.ImageUrl = null;
            image_byte = null;
            Session["ImageValue"] = null;
            image_vale.Text = "";
        }
        
    }

}