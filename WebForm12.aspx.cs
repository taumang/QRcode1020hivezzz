using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using ZXing;

namespace WebApplication122
{
    public partial class WebForm12 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e){

        }

        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            GenerateCode(txtCode.Text);
        }
        //The read Button:
        protected void btnRead_Click(object sender, EventArgs e)
        {
            ReadQRCode();
        }

        protected void btnGenNumber_Click(object sender, EventArgs e)
        {
            GenerateCode2();
        }

        protected void btnWriting_Click(object sender, EventArgs e)
        {
            //create the file stream first, then write into it.
            SaveCreateFileStream();


        }



        private void SaveCreateFileStream()
        {
            //declearation of the file/folder being created:
            //STEP 1:
            //Can possibly add the filestream here along with the writing it to the file which is created.
            //Also add a if statement, to display as to whether the text has been written to the file.
            var newDirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), "DataSaved");
            //There is an exception being called in the code below:
            Directory.CreateDirectory(newDirectoryPath);

            var newFilePath = Path.Combine(newDirectoryPath, "numbers_assigned.txt");

            var fileStream = File.Create(newFilePath);

            var sw = new StreamWriter(fileStream);

            sw.WriteLine(lblQRCode.Text);


        }

        private void GenerateCode2() {
            Random rand = new Random();
            long randNum = (long)(rand.NextDouble() * 90000000000) + 100000000;
            txtCode.Text = randNum.ToString();
        }

        private void GenerateCode(string name) {

            var Bwriter = new BarcodeWriter();
            Bwriter.Format = BarcodeFormat.QR_CODE;

            var result = Bwriter.Write(name);
            string path = Server.MapPath("~/images/QRImage.jpg");
            var barcodeBitmap = new Bitmap(result);

            using (MemoryStream memory = new MemoryStream())
            {
                using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
                {
                    barcodeBitmap.Save(memory, ImageFormat.Jpeg);
                    byte[] bytes = memory.ToArray();
                    fs.Write(bytes, 0, bytes.Length);
                }
            }

            imgQRCode.Visible = true;
            imgQRCode.ImageUrl = "~/images/QRImage.jpg";

        }

        private void ReadQRCode()
        {
            //Reading of the generated barcode
            var reader = new BarcodeReader();
            string filename = Path.Combine(Request.MapPath("~/images"), "QRImage.jpg");

            //Detech and decode the barcode inside the bitmap
            var result = reader.Decode(new Bitmap(filename));



            if (result != null)
            {
                lblQRCode.Text = $"QR code:{result.Text}";
            }


            //STEP 2:
            //
        }
    }
}