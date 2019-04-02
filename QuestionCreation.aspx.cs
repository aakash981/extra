using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuesPaperGenerator
{
    public partial class QuestionCreation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedIndex==1) {
                CheckBoxList1.Visible = true;
                Label2.Visible = true;
                DropDownList4.Visible = false;
                Label1.Visible = false;
                Button1.Visible = true;
                Button2.Visible=false;
                Label3.Text = "";
           

            }
            else if (DropDownList1.SelectedIndex == 0)
            {
                CheckBoxList1.Visible = false;
                DropDownList4.Visible = true;
                Label2.Visible = false;
                
                Label1.Visible = true;
                Button1.Visible=false;
              Button2.Visible=true;
              Label3.Text = "";
              
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            int i = 0;
            foreach (ListItem item in CheckBoxList1.Items)
            {
                if (item.Selected)
                    sb.Append(i + 1);
                i++;
            }
          
            Label3.Text = sb.ToString();
           
           // string abc = DropDownList4.SelectedValue;
        
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Label3.Text = DropDownList4.SelectedValue;
        }

        public void myMessage(string msg)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload = function(){");
            sb.Append("alert('");
            sb.Append(msg);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
        }

   

        protected void Button3_Click1(object sender, EventArgs e)
        {
            
              SqlConnection con = new SqlConnection(@"Data Source=(localdb)\v11.0;Initial Catalog=QPGdb;Integrated Security=True;Pooling=False");
                con.Open();
               
                string insert ="insert into questions(question_creator,selection,question,choice1,choice2,choice3,choice4,answer,skill_set,competency_level,marks) values('admin',@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11)"; 
                 SqlCommand cmd = new SqlCommand(insert, con);
                
                cmd.Parameters.AddWithValue("@p2", DropDownList1.Text);
                cmd.Parameters.AddWithValue("@p3", TextBox1.Text);
                cmd.Parameters.AddWithValue("@p4", TextBox2.Text);
                cmd.Parameters.AddWithValue("@p5", TextBox3.Text);
                cmd.Parameters.AddWithValue("@p6", TextBox4.Text);
                cmd.Parameters.AddWithValue("@p7", TextBox5.Text);
                cmd.Parameters.AddWithValue("@p8", Label3.Text);
                cmd.Parameters.AddWithValue("@p9", DropDownList2.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@p10", DropDownList3.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@p11", TextBox6.Text);
                cmd.ExecuteNonQuery();
                Response.Write("aa");
            
                con.Close();
            }
        }
          
        }

        
    
