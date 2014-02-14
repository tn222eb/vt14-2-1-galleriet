using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Galleriet
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IEnumerable<Galleriet.Model.ThumbPic> ThumbRepeater_GetData()
        {
            return null;
        }

        protected void UploadButton_Click(object sender, EventArgs e)
        {

        }
    }
}