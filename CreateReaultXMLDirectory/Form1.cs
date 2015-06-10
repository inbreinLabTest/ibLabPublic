using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace CreateReaultXMLDirectory
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }




        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (this.txtPath.Text == "")
            {
                MessageBox.Show("결과 파일이 없습니다 경로로 바꿔주세요~TestCode1");
                return;
            }


            string resultXMLPath = this.txtPath.Text;

            DirectoryInfo resultPathDirectory = new DirectoryInfo(resultXMLPath);


            foreach (System.IO.FileInfo f in resultPathDirectory.GetFiles())
            {
                string resultFileName = f.Name;

                string projectNum = resultFileName.Replace("Result_", "").Replace(f.Extension, "");

                if (f.Extension == ".xml")
                { 
                    //
                    string projectPath = f.DirectoryName + "\\"+projectNum;

                    if (File.Exists(projectPath) == false)
                        System.IO.Directory.CreateDirectory(projectPath);

                    string projectSimPath = projectPath + "\\SimXml";

                    if (File.Exists(projectSimPath) == false)
                        System.IO.Directory.CreateDirectory(projectSimPath);

                    //경로에서 읽어와서
                    FileInfo resultFile = new FileInfo(f.FullName);

                    if (File.Exists(projectSimPath + "\\" + resultFileName) == false)
                        resultFile.MoveTo(projectSimPath + "\\" + resultFileName);
                    else
                        resultFile.MoveTo(projectSimPath + "\\" + resultFileName + ".bak");
                }
            }

            MessageBox.Show("끝");
        }

       
    }
}
