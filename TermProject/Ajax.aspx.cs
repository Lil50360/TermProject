using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TermProject
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        List<Image> pictures = new List<Image>();
        int n = 0;
        List<String> List = new List<String>();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Random rand = new Random();
            List.Add("https://upload.wikimedia.org/wikipedia/en/0/0b/Nickelodeon_SpongeBob_SquarePants_Characters_Cast.png");
            List.Add("http://i3.mirror.co.uk/incoming/article129219.ece/ALTERNATES/s615/the-flintstones-pic-hanna-barbera-881281892.jpg");
            List.Add("https://myanimelist.cdn-dena.com/images/anime/10/78745.jpg");
            List.Add("https://upload.wikimedia.org/wikipedia/en/2/28/SamuraiJack.png");
            List.Add("http://best-animation-software.net/wp-content/uploads/2011/02/Animations-300x288.png");
            List.Add("https://static.comicvine.com/uploads/scale_small/11/111746/4352030-bugs.jpg");

            Random rand = new Random();

            int num = rand.Next(0, 6);
            Image1.ImageUrl = List[num];
            if (num == 0)
            {
                lblDisplay.Text = "Who lives in the Pinapple under the sea?<br>SPONGBOB SQUAREPANTS!";
            }
            else if (num == 1)
            {
                lblDisplay.Text = "yabba dabba doo!";
            }
            else if (num == 2)
            {
                lblDisplay.Text = "My Hero Academia";
            }
            else if (num == 3)
            {
                lblDisplay.Text = "Samurai Jack!";
            }
            else if (num == 4)
            {
                lblDisplay.Text = "Yes. Can I Help you?";
            }
            else if (num == 5)
            {
                lblDisplay.Text = "ehhh What's up doc?";
            }
        }

        protected void btnImage_Click(object sender, EventArgs e)
        {
            
        }
    }
    }
