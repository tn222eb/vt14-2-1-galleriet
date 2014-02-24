using Galleriet.Model;
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

        private string Message
        {
            get
            {
                return Session["Message"] as string;
            }
            set
            {
                Session["Message"] = value;
            }
        }

        private Gallery _gallery;

        private Gallery Gallery
        {
            get { return _gallery ?? (_gallery = new Gallery()); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var imageName = Request.QueryString["name"];

        
            if (imageName != null && Gallery.ImageExists(imageName))
            {
                BigImage.Visible = true;
                BigImage.ImageUrl = "/Pictures/" + imageName;
            }

            if (Message != null)
            {
                ClosePanel.Visible = true;
                SuccessLabel.Text = Message;
                Session.Clear();
            }
        }

        public IEnumerable<Galleriet.Model.ThumbPic> ThumbRepeater_GetData()
        {
            return Gallery.GetImageNames();
        }

        protected void UploadButton_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {

                if (FileUpload.HasFile)
                {
                    try
                    {
                        Gallery.SaveImage(FileUpload.FileContent, FileUpload.FileName);
                        Message = String.Format("Uppladdningen av '{0}' lyckades", FileUpload.FileName);
                        Response.Redirect(String.Format("?name=" + FileUpload.FileName));
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", ex);
                    }
                }
            }
        }

        protected void ImageCloseButton_Click(object sender, ImageClickEventArgs e)
        {
            ClosePanel.Visible = false;
        }
    }
}
